using System;
using System.Text;

namespace MyClassicGame
{
    public partial class MineSweeper : IMineSweeper
    {
        bool IMineSweeper.IsGameEnd
        {
            get => mb_GameEnd;
        }

        void IMineSweeper.OnStart(int width, int height, int mines)
        {
            if(mb_GameStart ^ mb_GameEnd == true)
            {
                Console.WriteLine("Game is already keep going.");
                return;
            }
            else
            {
                mb_GameStart = true;
                mb_GameEnd = false;

                NewGame(width, height, mines);
                OnGameStart();
            }
        }

        void IMineSweeper.OnClickCell(int x, int y)
        {
            if(mb_GameStart == false || mb_GameEnd == true)
                return;

            int index;

            index = m_GetIndex(x, y);

            if(m_board[index] != 0 && m_board[index] % 9 == 0)
            {
                mb_GameEnd = true;

                OpenAll();
                OnGameOver();
            }
            else
            {
                OpenCell(x, y);
                OnOpenCell();
            }
        }

        void IMineSweeper.OnCheck(int x, int y)
        {
            if(mb_GameStart == false || mb_GameEnd == true)
                return;

            Check(x, y);
            OnCheckCell();
        }

        void IMineSweeper.PrintBoard(GameMode mode)
        {
            string log = this.ToString(mode);

            foreach(char c in log)
            {
                switch(c)
                {
                    case '0': Console.ForegroundColor = ConsoleColor.DarkGray; break;
                    case '1': Console.ForegroundColor = ConsoleColor.Blue; break;
                    case '2': Console.ForegroundColor = ConsoleColor.Red; break;
                    case '3': Console.ForegroundColor = ConsoleColor.Green; break;
                    case '4': Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    case '5': Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                    case '6': Console.ForegroundColor = ConsoleColor.DarkRed; break;
                    case '7': Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                    case '8': Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case '+': Console.ForegroundColor = ConsoleColor.Black; break;
                    case '#': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case 'O': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case '!': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case '@': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case ' ': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case '\n': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case ']': Console.ForegroundColor = ConsoleColor.Gray; break;
                    case '[': Console.ForegroundColor = ConsoleColor.Gray; break;
                    default: break;
                }

                Console.Write("{0}", c);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine();
        }
    }
}