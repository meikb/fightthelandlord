namespace 牌之算法研究
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

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


            var 一组牌 = new 牌[] { 
                            // 黑
            new 牌 { 数据 = 0x090101u },   // A
            new 牌 { 数据 = 0x090102u }, 
            new 牌 { 数据 = 0x010103u }, 
            new 牌 { 数据 = 0x010104u }, 
            new 牌 { 数据 = 0x010105u }, 
            new 牌 { 数据 = 0x010106u }, 
            new 牌 { 数据 = 0x010107u }, 
            new 牌 { 数据 = 0x010108u }, 
            new 牌 { 数据 = 0x010109u }, 
            new 牌 { 数据 = 0x01010Au },   // 10
            new 牌 { 数据 = 0x01010Bu },   // J
            new 牌 { 数据 = 0x01010Cu },   // Q
            new 牌 { 数据 = 0x01010Du },   // K
            };
            var 另一组牌 = new 牌[] {            
            new 牌 { 数据 = 0x070101u },   // A
            new 牌 { 数据 = 0x070102u }, 
            new 牌 { 数据 = 0x010103u }, 
            new 牌 { 数据 = 0x010104u }, 
            new 牌 { 数据 = 0x010105u }, 
            new 牌 { 数据 = 0x010106u }, 
            new 牌 { 数据 = 0x010107u }, 
            };

            一组牌.按花点排序();
            另一组牌.按花点排序();
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            牌[] Result1 = null;
            牌[] Result2 = null;
            stopwatch1.Start();
            for (int i = 0; i < 1; i++)
            {
                Result1 = ExtendMethods.Remove(一组牌, 另一组牌);
            }
            stopwatch1.Stop();
            stopwatch2.Start();
            for (int i = 0; i < 1; i++)
            {
                Result2 = 麻将.ExtendMethods.Remove(一组牌, 另一组牌);
            }
            stopwatch2.Stop();
            foreach (var single in Result1)
            {
                Console.WriteLine(扑克.ExtendMethods.ToDisplayString(single));
            }
            foreach (var single in Result2)
            {
                Console.WriteLine("\r\n四核的算法" + 扑克.ExtendMethods.ToDisplayString(single));
            }
            Console.WriteLine(stopwatch1.ElapsedTicks + "\r\n" + stopwatch2.ElapsedTicks);
            Console.ReadLine();
        }
    }
}
