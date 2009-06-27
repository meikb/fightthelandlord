namespace 牌之算法研究
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {

        static void Main(string[] args)
        {
            var ps = 扑克.ExtendMethods.转为点计数牌序列(扑克.Handler.一副牌);
            for (int i = 0; i < ps.Length; i++)
            {
                var p = ps[i];
                Console.WriteLine(扑克.ExtendMethods.ToDisplayString(p));
            }

            Console.WriteLine();

            var ms = 麻将.Handler.一副牌.转为单张序列().转为计数牌序列();

            for (int i = 0; i < ms.Length; i++)
            {
                var m = ms[i];
                Console.WriteLine(麻将.ExtendMethods.ToDisplayString(m));
            }

            Console.ReadLine();

        }
    }
}
