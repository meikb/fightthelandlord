/**
 * 
 * java <=> sharp 
 * 
 * @author nile
 */
using System;
using System.Text;
using System.IO;

namespace JavaSharp
{
    public class Converter
    {
        public static Int32 GetBigEndian(Int32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return swapByteOrder(value);
            }
            else
            {
                return value;
            }
        }

        public static UInt16 GetBigEndian(UInt16 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return swapByteOrder(value);
            }
            else
            {
                return value;
            }
        }

        public static UInt32 GetBigEndian(UInt32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return swapByteOrder(value);
            }
            else
            {
                return value;
            }
        }

        public static Int64 GetBigEndian(Int64 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return swapByteOrder(value);
            }
            else
            {
                return value;
            }
        }

        public static Double GetBigEndian(Double value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return swapByteOrder(value);
            }
            else
            {
                return value;
            }
        }

        public static float GetBigEndian(float value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return swapByteOrder(value);

            }
            else
            {
                return value;
            }
        }

        public static Int32 GetLittleEndian(Int32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return value;
            }
            else
            {
                return swapByteOrder(value);
            }
        }

        public static UInt32 GetLittleEndian(UInt32 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return value;
            }
            else
            {
                return swapByteOrder(value);
            }
        }

        public static UInt16 GetLittleEndian(UInt16 value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return value;
            }
            else
            {
                return swapByteOrder(value);
            }
        }

        public static Double GetLittleEndian(Double value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return value;
            }
            else
            {
                return swapByteOrder(value);
            }
        }

        private static Int32 swapByteOrder(Int32 value)
        {
            Int32 swap = (Int32)((0x000000FF) & (value >> 24)
                | (0x0000FF00) & (value >> 8)
                | (0x00FF0000) & (value << 8)
                | (0xFF000000) & (value << 24));
            return swap;
        }

        private static Int64 swapByteOrder(Int64 value)
        {
            UInt64 uvalue = (UInt64)value;
            UInt64 swap = ((0x00000000000000FF) & (uvalue >> 56)
            | (0x000000000000FF00) & (uvalue >> 40)
            | (0x0000000000FF0000) & (uvalue >> 24)
            | (0x00000000FF000000) & (uvalue >> 8)
            | (0x000000FF00000000) & (uvalue << 8)
            | (0x0000FF0000000000) & (uvalue << 24)
            | (0x00FF000000000000) & (uvalue << 40)
            | (0xFF00000000000000) & (uvalue << 56));

            return (Int64)swap;
        }

        private static UInt16 swapByteOrder(UInt16 value)
        {
            return (UInt16)((0x00FF & (value >> 8))
                | (0xFF00 & (value << 8)));
        }

        private static UInt32 swapByteOrder(UInt32 value)
        {
            UInt32 swap = ((0x000000FF) & (value >> 24)
                | (0x0000FF00) & (value >> 8)
                | (0x00FF0000) & (value << 8)
                | (0xFF000000) & (value << 24));
            return swap;
        }

        private static float swapByteOrder(float value)
        {
            Byte[] buffer = BitConverter.GetBytes(value);
            Array.Reverse(buffer, 0, buffer.Length);
            return BitConverter.ToSingle(buffer, 0);
        }

        private static Double swapByteOrder(Double value)
        {
            Byte[] buffer = BitConverter.GetBytes(value);
            Array.Reverse(buffer, 0, buffer.Length);
            return BitConverter.ToDouble(buffer, 0);
        }
        public static byte[] toJavaStringByte(string str)
        {
            byte[] theString = Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            writer.Write(Converter.GetBigEndian((ushort)theString.Length));
            writer.Write(theString);
            return ms.ToArray();
        }
        public static String fromJavaString(byte[] b)
        {
            MemoryStream ms = new MemoryStream(b);
            BinaryReader reader = new BinaryReader(ms);
            ushort len = ReadShort(reader);
            byte[] bytes = reader.ReadBytes(len);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        public static String ReadJavaString(BinaryReader reader)
        {
            ushort len = ReadShort(reader);
            byte[] bytes = reader.ReadBytes(len);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }

        public static void WriteJavaString(BinaryWriter writer, string s)
        {
            byte[] theString = Encoding.UTF8.GetBytes(s);
            writer.Write(Converter.GetBigEndian((ushort)theString.Length));
            writer.Write(theString);
        }

        public static ushort ReadShort(BinaryReader reader)
        {
            return Converter.GetBigEndian(reader.ReadUInt16());
        }

        public static void WriteShort(BinaryWriter writer, ushort s)
        {
            writer.Write(Converter.GetBigEndian(s));
        }

        public static int ReadInt(BinaryReader reader)
        {
            return Converter.GetBigEndian(reader.ReadInt32());
        }

        public static void WriteInt(BinaryWriter writer, int i)
        {
            writer.Write(Converter.GetBigEndian(i));
        }


        public static long ReadLong(BinaryReader reader)
        {
            return Converter.GetBigEndian(reader.ReadInt64());
        }

        public static void WriteLong(BinaryWriter writer, long l)
        {
            writer.Write(Converter.GetBigEndian(l));
        }

        public static void WriteFloat(BinaryWriter writer, float f)
        {
            writer.Write(Converter.GetBigEndian(f));
        }

        public static float ReadFloat(BinaryReader reader)
        {
            return (float)Converter.GetBigEndian(reader.ReadUInt32());
        }
    }
}
