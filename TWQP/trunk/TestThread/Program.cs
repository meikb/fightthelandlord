using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TestThread
{
    class Program
    {

        // 用异步委托的方式启动一个线程（貌似很方便很快）

        public static void Main(string[] args)
        {

            Go();
            Console.ReadLine();
            _isLoop = false;
            Console.WriteLine("xxx");
            Console.WriteLine("҉");
        }

        static bool _isLoop = true;
        static void Go()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (sender, ea) =>
            {
                while (_isLoop)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(1);
                }
                throw new Exception("xxx"); //报个错看看
            };
            bw.RunWorkerAsync();
        }
    }
}
