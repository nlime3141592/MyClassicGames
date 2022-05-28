using System;

namespace MyClassicGame
{    
    partial class Program
    {
        static void Main_MineSweeper(GameMode mode)
        {
            string[] words;
            int width;
            int height;
            int mines;

            Console.WriteLine("Enter the width, height and mines each separated by Spaces.");
            Console.WriteLine("\tex) 12 10 15");
            words = Console.ReadLine().Split(' ');

            try
            {
                if(words.Length != 3)
                {
                    throw new Exception("Command Error.");
                }
                else
                {
                    width = int.Parse(words[0]);
                    height = int.Parse(words[1]);
                    mines = int.Parse(words[2]);

                    MineSweeper instance = new MineSweeper();
                    IMineSweeper implementation = (IMineSweeper)instance;

                    implementation.OnStart(width, height, mines);
                    implementation.PrintBoard(mode);

                    GameLoop_MineSweeper(implementation, mode);
                }
            }
            catch(Exception e)
            {
                if(mode == GameMode.DEVELOP)
                        Console.WriteLine("Command Error. : {0}\n{1}", e.Message, e.StackTrace);
                    else if(mode == GameMode.RELEASE)
                        Console.WriteLine("Command Error.");
            }
        }

        static void GameLoop_MineSweeper(IMineSweeper game, GameMode mode)
        {
            string line = null;
            string[] inputs;
            int x, y;

            while(line != "q" && !game.IsGameEnd)
            {
                try
                {
                    line = Console.ReadLine();
                    inputs = line.Split(' ');

                    if(inputs[0] == "q")
                    {
                        return;
                    }
                    else if(inputs.Length != 3)
                    {
                        throw new Exception("Command Error.");
                    }
                    else if(inputs[0] == "0")
                    {
                        x = int.Parse(inputs[1]);
                        y = int.Parse(inputs[2]);

                        game.OnCheck(x, y);
                        game.PrintBoard(mode);
                    }
                    else if(inputs[0] == "1")
                    {
                        x = int.Parse(inputs[1]);
                        y = int.Parse(inputs[2]);

                        game.OnClickCell(x, y);
                        game.PrintBoard(mode);
                    }
                    else
                    {
                        throw new Exception("Command Error.");
                    }
                }
                catch(Exception e)
                {
                    if(mode == GameMode.DEVELOP)
                        Console.WriteLine("Command Error. : {0}\n{1}", e.Message, e.StackTrace);
                    else if(mode == GameMode.RELEASE)
                        Console.WriteLine("Command Error.");
                }
            }
        }
    }
}