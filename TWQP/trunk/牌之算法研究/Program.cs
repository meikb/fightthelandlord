using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 牌之算法研究
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int i = 0; i < 扑克.一副牌.Length; i++)
            {
                var p = 扑克.一副牌[i];
                Console.WriteLine(p);
            }

            Console.ReadLine();


        }
    }
}
