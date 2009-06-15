using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TestThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Go();
            Console.ReadLine();
            _isLoop = false;
            Console.WriteLine("xxx");
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
