namespace 牌之算法研究
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    using 麻将;

    class Program
    {

        static void Main(string[] args)
        {
            //var ps = 扑克.ExtendMethods.转为点计数牌序列(扑克.Handler.一副牌);
            //for (int i = 0; i < ps.Length; i++)
            //{
            //    var p = ps[i];
            //    Console.WriteLine(扑克.ExtendMethods.ToDisplayString(p));
            //}

            //Console.WriteLine();

            //var ms = 麻将.Handler.一副牌.转为单张序列().转为计数牌序列();

            //for (int i = 0; i < ms.Length; i++)
            //{
            //    var m = ms[i];
            //    Console.WriteLine(麻将.ExtendMethods.ToDisplayString(m));
            //}

            //Console.ReadLine();


            //var 一组牌 = new 牌[] { 
            //                // 黑
            //new 牌 { 数据 = 0x010106u }, 
            //new 牌 { 数据 = 0x010107u }, 
            //new 牌 { 数据 = 0x010108u }, 
            //new 牌 { 数据 = 0x090101u },   // A
            //new 牌 { 数据 = 0x090102u }, 
            //new 牌 { 数据 = 0x010103u }, 
            //new 牌 { 数据 = 0x010104u }, 
            //new 牌 { 数据 = 0x010105u }, 
            //new 牌 { 数据 = 0x010109u }, 
            //new 牌 { 数据 = 0x01010Au },   // 10
            //new 牌 { 数据 = 0x01010Bu },   // J
            //new 牌 { 数据 = 0x01010Cu },   // Q
            //new 牌 { 数据 = 0x01010Du },   // K
            //};
            //var 另一组牌 = new 牌[] {            
            //new 牌 { 数据 = 0x010103u }, 
            //new 牌 { 数据 = 0x010104u }, 
            //new 牌 { 数据 = 0x010105u }, 
            //new 牌 { 数据 = 0x070101u },   // A
            //new 牌 { 数据 = 0x070102u }, 
            //new 牌 { 数据 = 0x010106u }, 
            //new 牌 { 数据 = 0x010107u }, 
            //};

            //一组牌.按花点排序();
            //另一组牌.按花点排序();

            //Stopwatch stopwatch1 = new Stopwatch();
            //Stopwatch stopwatch2 = new Stopwatch();

            //牌[] Result1 = null;
            //牌[] Result2 = null;

            //stopwatch1.Start();
            //for (int i = 0; i < 5000000; i++)
            //{
            //    牌[] ps1 = (牌[])一组牌.Clone();
            //    牌[] ps2 = (牌[])另一组牌.Clone();

            //    Result1 = ps1.LinqRemove(ps2);
            //}
            //stopwatch1.Stop();

            //stopwatch2.Start();
            //for (int i = 0; i < 5000000; i++)
            //{
            //    牌[] ps1 = (牌[])一组牌.Clone();
            //    牌[] ps2 = (牌[])另一组牌.Clone();

            //    Result2 = ps1.移走牌数组(ps2);
            //}
            //stopwatch2.Stop();

            //foreach (var p in Result1)
            //{
            //    Console.WriteLine(扑克.ExtendMethods.ToDisplayString(p));
            //}
            //foreach (var p in Result2)
            //{
            //    Console.WriteLine("\r\n四核的算法" + 扑克.ExtendMethods.ToDisplayString(p));
            //}
            //Console.WriteLine(stopwatch1.ElapsedTicks + "\r\n" + stopwatch2.ElapsedTicks);
            //Console.ReadLine();

            //MainClass.RunSnippet();
            //Console.ReadLine();




            // 九莲宝灯
            var ps = new 牌[]{
                new 牌{ 数据=0x030101u },
                new 牌{ 数据=0x010102u },
                new 牌{ 数据=0x010103u },
                new 牌{ 数据=0x010104u },
                new 牌{ 数据=0x020105u },
                new 牌{ 数据=0x010106u },
                new 牌{ 数据=0x010107u },
                new 牌{ 数据=0x010108u },
                new 牌{ 数据=0x030109u },
            };
            ps.排序();

            System.Diagnostics.Stopwatch w = new System.Diagnostics.Stopwatch();
            w.Start();

            for (int i = 0; i < 3000; i++)
            {
                var results = ps.计算分组结果集合().排序();

                if (i == 0)
                {
                    Console.WriteLine("结果数 = " + results.Count);
                    for (int j = 0; j < 1; j++)
                    {
                        var result = results[j];
                        Console.WriteLine("\n结果" + j);
                        Console.WriteLine("等级 = " + result.等级);
                        foreach (var zp in result.组牌集合)
                        {
                            Console.WriteLine(zp.分组规则.ToString());
                            foreach (var p in zp.牌数组)
                            {
                                Console.WriteLine(p.获取显示字串());
                            }
                        }
                        Console.WriteLine("剩牌 = ");
                        foreach (var p in result.剩牌数组)
                        {
                            Console.WriteLine(p.获取显示字串());
                        }
                    }

                }
            }
            w.Stop();

            Console.WriteLine("算 3000 次 用时：" + w.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }

    class Foo
    {
        public int ID;
        public int Count;
        public Foo(int id, int count)
        {
            this.ID = id;
            this.Count = count;
        }
        public override string ToString()
        {
            return string.Format("ID={0}, Count={1}\r\n", this.ID, this.Count);
        }
    }

    public class MainClass
    {
        public static void RunSnippet()
        {
            var foos1 = new Foo[] { new Foo(1, 1), new Foo(2, 3), new Foo(5, 2) };
            var foos2 = new Foo[] { new Foo(2, 3), new Foo(5, 1) };

            var result = from foo1 in foos1
                         join foo2 in foos2 on foo1.ID equals foo2.ID
                         where foo1.Count > foo2.Count
                         select new Foo(foo1.ID, foo1.Count - foo2.Count);

            result = result.Concat(from foo1 in foos1
                                   where !foos2.Any(foo => { return foo.ID == foo1.ID; })
                                   select foo1);
            foreach (var foo in result) Console.Write(foo);
        }
    }
}
