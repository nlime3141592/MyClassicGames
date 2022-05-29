using System;
using System.IO;

namespace MyClassicGame
{
    abstract class InputModule : IOModule
    {
        private static readonly string c_NOT_IMPLEMENTED_MESSAGE = "The module doesn't support input type you called.";

        protected InputModule(CharacterSet set) : base(set)
        {
            
        }

        public virtual byte[] ReadBytes() { throw new InputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual char[] ReadChars() { throw new InputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual string ReadString() { throw new InputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual string[] ReadWords(params char[] separators) { throw new InputException(c_NOT_IMPLEMENTED_MESSAGE); }
    }
}