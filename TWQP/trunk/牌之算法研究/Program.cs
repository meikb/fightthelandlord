using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using 扑克;

namespace 牌之算法研究
{
    class Program
    {

        static void Main(string[] args)
        {
            var ps = 扑克.Handler.一副牌;
            for (int i = 0; i < ps.Length; i++)
            {
                var p = ps[i];
                Console.WriteLine(p.ToDisplayString());
            }

            Console.ReadLine();


        }
    }
}
