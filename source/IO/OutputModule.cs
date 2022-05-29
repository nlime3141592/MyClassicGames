using System;

namespace MyClassicGame
{
    abstract class OutputModule : IOModule
    {
        private static readonly string c_NOT_IMPLEMENTED_MESSAGE = "The module doesn't support output type you called.";

        protected OutputModule(CharacterSet set) : base(set)
        {
            
        }

        public virtual bool WriteByte(byte value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteBytes(byte[] bytes) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteSbyte(sbyte value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteSbytes(sbyte[] sbytes) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteChar(char value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteChars(char[] chars) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteString(string value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteWords(string[] words) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteBool(bool value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteBools(bool[] bools) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteInt(int value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteInts(int[] ints) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteUint(uint value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteUints(uint[] uints) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteLong(long value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteLongs(long[] longs) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteUlong(ulong value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteUlongs(ulong[] ulongs) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteShort(short value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteShorts(short[] shorts) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteUshort(ushort value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteUshorts(ushort[] ushorts) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteSingle(float value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteSingles(float[] singles) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteDouble(double value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteDoubles(double[] doubles) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteDecimal(decimal value) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
        public virtual bool WriteDecimals(decimal[] decimals) { throw new OutputException(c_NOT_IMPLEMENTED_MESSAGE); }
    }
}