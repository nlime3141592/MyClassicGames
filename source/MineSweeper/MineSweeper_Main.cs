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
        private static readonly char[] c_DEVELOP_CELL_CHARS = new char[]{'0','1','2','3','4','5','6','7','8','#','O','+','.','.','.','.','.','.','!','.','@'}; // 012345678#O+......!.@
        private static readonly char[] c_RELEASE_CELL_CHARS = new char[]{'0','1','2','3','4','5','6','7','8','O','O','+','.','.','.','.','.','.','@','.','@'}; // 012345678OO+......@.@
        private static readonly char c_ERROR_CELL_CHAR = '*';

        private int m_width;
        private int m_height;
        private int m_capacity;
        private int m_mines;
        private int[] m_board;
        private Random m_rnd;
        private StringBuilder m_printBuffer;
        private bool mb_GameStart;
        private bool mb_GameEnd;

        public event MineSweeperEvent OnGameStart;
        public event MineSweeperEvent OnOpenCell;
        public event MineSweeperEvent OnCheckCell;
        public event MineSweeperEvent OnGameOver;

        public MineSweeper()
        {
            m_width = 0;
            m_height = 0;
            m_capacity = 0;
            m_mines = 0;
            m_board = null;
            m_rnd = new Random();
            m_printBuffer = new StringBuilder();
            mb_GameStart = false;
            mb_GameEnd = false;

            OnGameStart += () => Console.WriteLine("Game Start!");
            OnOpenCell += () => Console.WriteLine("Open Cell.");
            OnCheckCell += () => Console.WriteLine("Check Cell.");
            OnGameOver += () => Console.WriteLine("Game Over!");
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void NewGame(int width, int height, int mines)
        {
            if(width < 1 || height < 1 || width > c_MAX_WIDTH || height > c_MAX_HEIGHT)
                throw new ArgumentException("Board Size Exception.");
            else if(mines < 1 || mines >= width * height)
                throw new ArgumentException("Mine Count Exception.");

            int beforeCapacity;

            beforeCapacity = m_capacity;
            m_width = width;
            m_height = height;
            m_capacity = width * height;
            m_mines = mines;

            if(m_capacity > beforeCapacity)
                m_board = new int[m_capacity];

            Fill(mines);
            Mix();
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void OpenCell(int x, int y)
        {
            int i;
            int index;
            int mines;

            if(m_IsInvalidPosition(x, y))
                return;

            index = m_GetIndex(x, y);

            if(m_board[index] != 0 && Math.Abs(m_board[index]) % 10 == 0)
            {
                mines = CountMines(x, y);

                m_board[index] = mines;

                if(mines > 0)
                    return;

                for(i = 0; i < c_NEIGHBORS.Length; i += 2)
                {
                    OpenCell(x + c_NEIGHBORS[i], y + c_NEIGHBORS[i + 1]);
                }
            }
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private void Check(int x, int y)
        {
            int index;
            int rest;

            index = m_GetIndex(x, y);
            rest = Math.Abs(m_board[index]) / 9;

            if(rest > 0)
                m_board[index] = m_board[index] * ((rest % 2) + 1) / rest;
        }

        // NOTE: Set access specifier to private if it doesn't implement IMineSweeper interface, else public.
        private string ToString(GameMode mode)
        {
            int i, j;

            m_printBuffer.Clear();

            for(i = 0; i < m_height; i++)
            {
                m_printBuffer.Append("]");

                for(j = 0; j < m_width; j++)
                {
                    if(mode == GameMode.DEVELOP)
                        m_printBuffer.AppendFormat(" {0}", c_DEVELOP_CELL_CHARS[m_board[m_GetIndex(i, j)]]);
                    else if(mode == GameMode.RELEASE)
                        m_printBuffer.AppendFormat(" {0}", c_RELEASE_CELL_CHARS[m_board[m_GetIndex(i, j)]]);
                    else
                        m_printBuffer.AppendFormat(" {0}", c_ERROR_CELL_CHAR);
                }
                
                m_printBuffer.Append(" [");

                if(i < m_height - 1)
                    m_printBuffer.Append("\n");
            }

            return m_printBuffer.ToString();
        }

        private void Fill(int mines)
        {
            int i;

            for(i = 0; i < m_capacity; i++)
                m_board[i] = i < mines ? 9 : 10;
        }

        private void Mix()
        {
            int i;

            for(i = 0; i < m_capacity - 1; i++)
                m_Swap(ref m_board[i], ref m_board[m_rnd.Next(i, m_capacity - 1)]);
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

                if(m_board[index] == 11 || (m_board[index] != 0 && Math.Abs(m_board[index]) % 9 == 0))
                    count++;
            }

            return count;
        }

        private void OpenAll()
        {
            int i;

            for(i = 0; i < m_capacity; i++)
            {
                if(m_board[i] / 9 == 0)
                {
                    continue;
                }
                else if(Math.Abs(m_board[i]) % 9 == 0)
                {
                    m_board[i] = 11;
                }
                else if(Math.Abs(m_board[i]) % 10 == 0)
                {
                    m_board[i] = CountMines(m_GetPositionX(i), m_GetPositionY(i));
                }
            }
        }

        private int m_GetIndex(int x, int y) => x * m_width + y;
        private int m_GetPositionX(int index) => index / m_width;
        private int m_GetPositionY(int index) => index % m_width;

        private bool m_IsInvalidPosition(int x, int y) => x < 0 || x >= m_height || y < 0 || y >= m_width;
        private bool m_IsInvalidIndex(int index) => index < 0 || index >= m_capacity;

        private void m_Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}