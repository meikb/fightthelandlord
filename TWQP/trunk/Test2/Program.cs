using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleHelper;

namespace Test2
{
    public static class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            new ContactCenterCallback(new Handler(1));
            w.WE();
        }
    }
}
