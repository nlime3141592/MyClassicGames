using System;
using System.Text;

namespace MyClassicGame
{
    public partial class MineSweeper
    {
        private static readonly int c_MAX_WIDTH = 32767;
        private static readonly int c_MAX_HEIGHT = 32767;

        // L, R, D, U, LD, LU, RD, RU
        private static readonly int[] c_NEIGHBORS = {-1, 0, 1, 0, 0, -1, 0, 1, -1, -1, -1, 1, 1, -1, 1, 1};

        // !@+O#012345678
        private static readonly char[] c_DEVELOP_CELL_CHARS = new char[]{'!','@','+','O','#','0','1','2','3','4','5','6','7','8'};

        // @@+OO012345678
        private static readonly char[] c_RELEASE_CELL_CHARS = new char[]{'@','@','+','O','O','0','1','2','3','4','5','6','7','8'};

        // CL: closed
        // OP: opened
        // CK: checked
        // UC: unchecked
        private enum m_CellState : int
        {
            CL_CK_Mine = -2,
            CL_CK_Empty = -1,
            OP_Mine = 0,
            CL_UC_Empty = 1,
            CL_UC_Mine = 2,
            OP_Count_0 = 3,
            OP_Count_1 = 4,
            OP_Count_2 = 5,
            OP_Count_3 = 6,
            OP_Count_4 = 7,
            OP_Count_5 = 8,
            OP_Count_6 = 9,
            OP_Count_7 = 10,
            OP_Count_8 = 11,
        }

        private static readonly char c_ERROR_CELL_CHAR = '*';

        private int m_width;
        private int m_height;
        private int m_capacity;
        private int m_initMineCount;
        private int m_leftCellCount;
        private int[] m_board;
        private Random m_rnd;
        private StringBuilder m_stringBuffer;
        private bool mb_GameStart;
        private bool mb_GameEnd;
        private int m_playTime;
        
        public event MineSweeperEvent OnGameStart;
        public event MineSweeperEvent OnOpenCell;
        public event MineSweeperEvent OnCheckCell;
        public event MineSweeperEvent OnGameOver;

        public MineSweeper()
        {
            m_width = 0;
            m_height = 0;
            m_capacity = 0;
            m_initMineCount = 0;
            m_leftCellCount = 0;
            m_board = null;
            m_rnd = new Random();
            m_stringBuffer = new StringBuilder();

            mb_GameStart = false;
            mb_GameEnd = false;

            OnGameStart += () => Console.WriteLine("Game Start!");
            OnOpenCell += () => Console.WriteLine("Open Cell.");
            OnCheckCell += () => Console.WriteLine("Check Cell.");
            OnGameOver += () => Console.WriteLine("Game Over!");
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void NewGame(int width, int height, int mineCount)
        {
            SetBoardScale(width, height, mineCount);
            Fill(mineCount);
            Mix();
        }

        private void SetBoardScale(int width, int height, int mineCount)
        {
            int beforeCapacity;

            beforeCapacity = m_capacity;
            m_width = width;
            m_height = height;
            m_capacity = width * height;
            m_initMineCount = mineCount;
            m_leftCellCount = width * height - mineCount;

            if(m_capacity > beforeCapacity)
                m_board = new int[m_capacity];
        }

        private void Fill(int mineCount)
        {
            int i;

            for(i = 0; i < m_capacity; i++)
            {
                if(i < mineCount)
                    m_board[i] = (int)m_CellState.CL_UC_Mine;
                else
                    m_board[i] = (int)m_CellState.CL_UC_Empty;
            }
        }

        private void Mix()
        {
            int i, j;
            int t;

            for(i = 0; i < m_capacity - 1; i++)
            {
                j = m_rnd.Next(i, m_capacity - 1);

                t = m_board[i];
                m_board[i] = m_board[j];
                m_board[j] = t;
            }
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void OpenCell(int x, int y)
        {
            int i;
            int index;
            int mineCount;

            if(m_IsInvalidPosition(x, y))
                return;

            index = m_GetIndex(x, y);

            // if(m_board[index] == (int)m_CellState.CL_CK_Empty || m_board[index] == (int)m_CellState.CL_UC_Empty)
            if(Math.Abs(m_board[index]) == 1)
            {
                mineCount = CountMines(x, y);

                m_board[index] = mineCount + 3;
                m_leftCellCount--;

                if(mineCount == 0)
                {
                    for(i = 0; i < c_NEIGHBORS.Length; i += 2)
                    {
                        OpenCell(x + c_NEIGHBORS[i], y + c_NEIGHBORS[i + 1]);
                    }
                }
            }
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void Check(int x, int y)
        {
            int index;

            index = m_GetIndex(x, y);

            m_board[index] *= -1;
        }

        private int CountMines(int x, int y)
        {
            int i;
            int index;
            int count;
            int xdx, ydy;

            count = 0;

            for(i = 0; i < c_NEIGHBORS.Length; i += 2)
            {
                xdx = x + c_NEIGHBORS[i];
                ydy = y + c_NEIGHBORS[i + 1];

                if(m_IsInvalidPosition(xdx, ydy))
                    continue;
                
                index = m_GetIndex(xdx, ydy);

                // if(m_board[index] == (int)m_CellState.OP_Mine || m_board[index] == (int)m_CellState.CL_CK_Mine || m_board[index] == (int)m_CellState.CL_UC_Mine)
                if(Math.Abs(m_board[index]) == 2 || m_board[index] == (int)m_CellState.OP_Mine)
                    count++;
            }

            return count;
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void OpenAll()
        {
            int i;
            int x, y;

            for(i = 0; i < m_capacity; i++)
            {
                // if(m_board[index] == (int)m_CellState.CL_CK_Empty || m_board[index] == (int)m_CellState.CL_UC_Empty)
                if(Math.Abs(m_board[i]) == 1)
                {
                    x = m_GetPositionX(i);
                    y = m_GetPositionY(i);
                    m_board[i] = CountMines(x, y) + 3;
                }
                // else if(m_board[index] == (int)m_CellState.CL_CK_Mine || m_board[index] == (int)m_CellState.CL_UC_Mine)
                else if(Math.Abs(m_board[i]) == 2)
                {
                    m_board[i] = (int)m_CellState.OP_Mine;
                }
            }

            m_leftCellCount = m_initMineCount;
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private string ToString(GameMode mode)
        {
            int i, j;
            int index;
            int cellState;

            m_stringBuffer.Clear();

            for(i = 0; i < m_height; i++)
            {
                m_stringBuffer.Append("]");

                for(j = 0; j < m_width; j++)
                {
                    index = m_GetIndex(i, j);
                    cellState = m_board[index] + 2;

                    if(mode == GameMode.DEVELOP)
                        m_stringBuffer.AppendFormat(" {0}", c_DEVELOP_CELL_CHARS[cellState]);
                    else if(mode == GameMode.RELEASE)
                        m_stringBuffer.AppendFormat(" {0}", c_RELEASE_CELL_CHARS[cellState]);
                    else
                        m_stringBuffer.AppendFormat(" {0}", c_ERROR_CELL_CHAR);
                }
                
                m_stringBuffer.Append(" [");

                if(i < m_height - 1)
                    m_stringBuffer.Append("\n");
            }

            return m_stringBuffer.ToString();
        }

        private int m_GetIndex(int x, int y) => x * m_width + y;
        private int m_GetPositionX(int index) => index / m_width;
        private int m_GetPositionY(int index) => index % m_width;

        private bool m_IsInvalidPosition(int x, int y) => x < 0 || x >= m_height || y < 0 || y >= m_width;
        private bool m_IsInvalidIndex(int index) => index < 0 || index >= m_capacity;
    }
}