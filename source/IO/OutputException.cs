using System;
using System.IO;

namespace MyClassicGame
{
    class OutputException : IOException
    {
        public OutputException(string message) : base(message)
        {
            
        }
    }
}