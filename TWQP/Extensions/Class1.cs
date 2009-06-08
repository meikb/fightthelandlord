using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Extensions
{
    public static class Class1
    {
        public static BinaryFormatter _binaryFormatter = new BinaryFormatter();

        public static byte[] ToBinary<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                _binaryFormatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        public static T ToObject<T>(this byte[] bs)
        {
            using (var ms = new MemoryStream(bs, 0, bs.Length))
            {
                return (T)_binaryFormatter.Deserialize(ms);
            }
        }
    }
}
