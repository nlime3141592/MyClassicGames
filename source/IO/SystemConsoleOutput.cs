using System;

namespace MyClassicGame
{
    sealed class SystemConsoleOutput : OutputModule
    {
        public SystemConsoleOutput(CharacterSet set) : base(set)
        {

        }

        public override bool WriteByte(byte value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteBytes(byte[] bytes)
        {
            if(bytes == null)
                throw new OutputException("reference is null.");
            else if(bytes.Length == 0)
                throw new OutputException("any byte elements.");

            int i;

            Console.Write("[{0}", bytes[0]);
            for(i = 1; i < bytes.Length; i++)
                Console.Write(", {0}", bytes[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteSbyte(sbyte value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteSbytes(sbyte[] sbytes)
        {
            if(sbytes == null)
                throw new OutputException("reference is null.");
            else if(sbytes.Length == 0)
                throw new OutputException("any sbyte elements.");

            int i;

            Console.Write("[{0}", sbytes[0]);
            for(i = 1; i < sbytes.Length; i++)
                Console.Write(", {0}", sbytes[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteChar(char value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteChars(char[] chars)
        {
            if(chars == null)
                throw new OutputException("reference is null.");
            else if(chars.Length == 0)
                throw new OutputException("any char elements.");

            int i;

            Console.Write("[{0}", chars[0]);
            for(i = 1; i < chars.Length; i++)
                Console.Write(", {0}", chars[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteString(string value)
        {
            if(value == null)
                throw new OutputException("reference is null.");

            Console.Write(value);
            return true;
        }

        public override bool WriteWords(string[] words)
        {
            if(words == null)
                throw new OutputException("reference is null.");
            else if(words.Length == 0)
                throw new OutputException("any word elements.");

            int i;

            Console.Write("[{0}", words[0]);
            for(i = 1; i < words.Length; i++)
                Console.Write(", {0}", words[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteBool(bool value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteBools(bool[] bools)
        {
            if(bools == null)
                throw new OutputException("reference is null.");
            else if(bools.Length == 0)
                throw new OutputException("any bool elements.");

            int i;

            Console.Write("[{0}", bools[0]);
            for(i = 1; i < bools.Length; i++)
                Console.Write(", {0}", bools[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteInt(int value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteInts(int[] ints)
        {
            if(ints == null)
                throw new OutputException("reference is null.");
            else if(ints.Length == 0)
                throw new OutputException("any int elements.");

            int i;

            Console.Write("[{0}", ints[0]);
            for(i = 1; i < ints.Length; i++)
                Console.Write(", {0}", ints[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteUint(uint value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteUints(uint[] uints)
        {
            if(uints == null)
                throw new OutputException("reference is null.");
            else if(uints.Length == 0)
                throw new OutputException("any uint elements.");

            int i;

            Console.Write("[{0}", uints[0]);
            for(i = 1; i < uints.Length; i++)
                Console.Write(", {0}", uints[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteLong(long value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteLongs(long[] longs)
        {
            if(longs == null)
                throw new OutputException("reference is null.");
            else if(longs.Length == 0)
                throw new OutputException("any long elements.");

            int i;

            Console.Write("[{0}", longs[0]);
            for(i = 1; i < longs.Length; i++)
                Console.Write(", {0}", longs[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteUlong(ulong value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteUlongs(ulong[] ulongs)
        {
            if(ulongs == null)
                throw new OutputException("reference is null.");
            else if(ulongs.Length == 0)
                throw new OutputException("any ulong elements.");

            int i;

            Console.Write("[{0}", ulongs[0]);
            for(i = 1; i < ulongs.Length; i++)
                Console.Write(", {0}", ulongs[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteShort(short value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteShorts(short[] shorts)
        {
            if(shorts == null)
                throw new OutputException("reference is null.");
            else if(shorts.Length == 0)
                throw new OutputException("any short elements.");

            int i;

            Console.Write("[{0}", shorts[0]);
            for(i = 1; i < shorts.Length; i++)
                Console.Write(", {0}", shorts[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteUshort(ushort value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteUshorts(ushort[] ushorts)
        {
            if(ushorts == null)
                throw new OutputException("reference is null.");
            else if(ushorts.Length == 0)
                throw new OutputException("any ushort elements.");

            int i;

            Console.Write("[{0}", ushorts[0]);
            for(i = 1; i < ushorts.Length; i++)
                Console.Write(", {0}", ushorts[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteSingle(float value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteSingles(float[] singles)
        {
            if(singles == null)
                throw new OutputException("reference is null.");
            else if(singles.Length == 0)
                throw new OutputException("any single elements.");

            int i;

            Console.Write("[{0}", singles[0]);
            for(i = 1; i < singles.Length; i++)
                Console.Write(", {0}", singles[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteDouble(double value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteDoubles(double[] doubles)
        {
            if(doubles == null)
                throw new OutputException("reference is null.");
            else if(doubles.Length == 0)
                throw new OutputException("any double elements.");

            int i;

            Console.Write("[{0}", doubles[0]);
            for(i = 1; i < doubles.Length; i++)
                Console.Write(", {0}", doubles[i]);
            Console.Write("]");

            return true;
        }

        public override bool WriteDecimal(decimal value)
        {
            Console.Write("{0}", value);
            return true;
        }

        public override bool WriteDecimals(decimal[] decimals)
        {
            if(decimals == null)
                throw new OutputException("reference is null.");
            else if(decimals.Length == 0)
                throw new OutputException("any decimal elements.");

            int i;

            Console.Write("[{0}", decimals[0]);
            for(i = 1; i < decimals.Length; i++)
                Console.Write(", {0}", decimals[i]);
            Console.Write("]");

            return true;
        }

        public bool NextLine()
        {
            Console.WriteLine();
            return true;
        }
    }
}