using System;
using System.IO;

namespace MyClassicGame
{
    class InputException : IOException
    {
        public InputException(string message) : base(message)
        {
            
        }
    }
}