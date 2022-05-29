using System;

namespace MyClassicGame
{
    sealed class SystemConsoleInput : InputModule
    {
        public SystemConsoleInput(CharacterSet set) : base(set)
        {

        }

        public override byte[] ReadBytes()
        {
            string line;
            byte[] bytes;
            
            line = Console.ReadLine();
            bytes = encoding.GetBytes(line);

            return bytes;
        }

        public override char[] ReadChars()
        {
            string line;
            byte[] bytes;
            char[] chars;

            line = Console.ReadLine();
            bytes = encoding.GetBytes(line);
            chars = encoding.GetChars(bytes);

            return chars;
        }

        public override string ReadString()
        {
            return Console.ReadLine();
        }

        public override string[] ReadWords(params char[] separators)
        {
            string line;
            line = Console.ReadLine();

            if(line == "")
                return null;
            else if(separators == null || separators.Length == 0)
                return line.Split(' ');
            else
                return line.Split(separators);
        }
    }
}