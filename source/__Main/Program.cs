using System;

namespace MyClassicGame
{    
    partial class Program
    {
        static void Main(string[] args)
        {
            GameMode mode = GameMode.DEVELOP;

            try
            {
                int gameCode = int.Parse(args[0]);
                Hub(gameCode, mode);
            }
            catch(Exception e)
            {
                Console.WriteLine("Command Error. : {0}", e.Message);
            }

            Console.WriteLine("Program Ends.");
            Console.WriteLine("\nPress Any Key to Close Program..");
            Console.ReadKey();
        }

        static void Hub(int gameCode, GameMode mode)
        {
            switch(gameCode)
            {
                case 1:
                    Main_MineSweeper(mode);
                    break;
                default:
                    throw new Exception("Game Code Error.");
            }
        }
    }
}