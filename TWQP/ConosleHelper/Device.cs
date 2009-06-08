using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHelper
{
	/// <summary>
	/// 以 40x24 的双字节显示模式往 Console 控制台单色高速输出（要求所有输出字符为双字节）
	/// </summary>
	public static class Device
	{
		static StringBuilder[] _sbs = new StringBuilder[] { 
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),

            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),

            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　"),
            new StringBuilder("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　") };

		public static void Clear()
		{
			for (int i = 0; i < _sbs.Length; i++)
			{
				_sbs[i].Remove(0, 40);
				_sbs[i].Append("　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　");
			}
		}

		public static void Flush()
		{
			lock (Console.Out)
			{
				Console.CursorTop = Console.CursorLeft = 0;
				for (int i = 0; i < _sbs.Length; i++)
				{
					Console.Write(_sbs[i]);
				}
			}
		}

		public static void Write(int x, int y, char c)
		{
			if (x >= 0 && x <= 39 && y >= 0 && y <= 23)
			{
				_sbs[y][x] = c;
			}
		}


		public static void Write(int x, int y, string s)
		{
			string str = Microsoft.VisualBasic.Strings.StrConv(s, Microsoft.VisualBasic.VbStrConv.Wide, 0);

			for (int i = 0; i < str.Length; i++)
			{
				Write(x + i, y, str[i]);
			}
		}
	}
}
