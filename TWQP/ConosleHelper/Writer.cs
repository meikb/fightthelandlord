using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

namespace ConsoleHelper
{
    /// <summary>
    /// 用于方便的往控制台输出彩色文字
    /// </summary>
    public class Writer
    {
        #region Properties

        /// <summary>
        /// 当前对象的实例
        /// </summary>
        public static readonly Writer Instance = new Writer();

        private ConsoleColor _defaultForegroundColor = ConsoleColor.White;
        /// <summary>
        /// 获取或设置输出文字默认颜色
        /// </summary>
        public ConsoleColor DefaultForegroundColor
        {
            get { return _defaultForegroundColor; }
            set { _defaultForegroundColor = value; }
        }

        private ConsoleColor _defaultBackgroundColor = ConsoleColor.Black;
        /// <summary>
        /// 获取或设置输出文字默认颜色
        /// </summary>
        public ConsoleColor DefaultBackgroundColor
        {
            get { return _defaultBackgroundColor; }
            set { _defaultBackgroundColor = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 创建默认颜色为白色的控制台输出器
        /// </summary>
        public Writer() { }
        /// <summary>
        /// 创建指定文本颜色的控制台输出器
        /// </summary>
        /// <param name="defaultForegroundColor">默认的前景色</param>
        public Writer(ConsoleColor defaultForegroundColor)
        {
            _defaultForegroundColor = defaultForegroundColor;
        }
        /// <summary>
        /// 创建指定文本前后景颜色的控制台输出器
        /// </summary>
        /// <param name="defaultForegroundColor">默认的前景色</param>
        /// <param name="defaultBackgroundColor">默认的背景色</param>
        public Writer(ConsoleColor defaultForegroundColor, ConsoleColor defaultBackgroundColor)
        {
            _defaultForegroundColor = defaultForegroundColor;
            _defaultBackgroundColor = defaultBackgroundColor;
        }

        #endregion

        #region Beep method

        public void B(int frequency)
        {
            Thread t = new Thread(delegate() { Console.Beep(frequency, 100); });
            t.Start();
        }

        #endregion

        #region base ReadLine methods

        public string RL()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// 输出等待用户回车继续
        /// </summary>
        public void WE()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("按回车继续...");
            Console.ForegroundColor = _defaultForegroundColor;
            Console.BackgroundColor = _defaultBackgroundColor;
            RL();
        }
        /// <summary>
        /// 附加文字显示功能（指定前背景色）等待用户输入信息回车继续
        /// </summary>
        public string RL(ConsoleColor fc, ConsoleColor bc, string s, params object[] args)
        {
            WL(fc, bc, s, args);
            return RL();
        }
        /// <summary>
        /// 附加文字显示功能（指定前背景色）等待用户输入信息回车继续
        /// </summary>
        public string RL(ConsoleColor fc, string s, params object[] args)
        {
            WL(fc, s, args);
            return RL();
        }
        /// <summary>
        /// 附加文字显示功能（指定前背景色）等待用户输入信息回车继续
        /// </summary>
        public string RL(string s, params object[] args)
        {
            WL(s, args);
            return RL();
        }

        #endregion

        #region base Write / WriteLine Methods

        /// <summary>
        /// 往控制台输出一段彩色文本（指定前背景色）
        /// </summary>
        /// <param name="fc">前景色</param>
        /// <param name="bc">背景色</param>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void W(ConsoleColor fc, ConsoleColor bc, string s, params object[] args)
        {
            Console.ForegroundColor = fc;
            Console.BackgroundColor = bc;
            Console.Write(s, args);
            Console.ForegroundColor = _defaultForegroundColor;
            Console.BackgroundColor = _defaultBackgroundColor;
        }
        /// <summary>
        /// 往控制台输出一段彩色文本（指定前景色）
        /// </summary>
        /// <param name="fc">前景色</param>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void W(ConsoleColor fc, string s, params object[] args)
        {
            W(fc, _defaultBackgroundColor, s, args);
        }
        /// <summary>
        /// 往控制台输出一段彩色文本（用默认颜色）
        /// </summary>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void W(string s, params object[] args)
        {
            W(_defaultForegroundColor, _defaultBackgroundColor, s, args);
        }


        /// <summary>
        /// 往控制台输出一段彩色文本（带换行，指定前背景色）
        /// </summary>
        /// <param name="fc">前景色</param>
        /// <param name="bc">背景色</param>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void WL(ConsoleColor fc, ConsoleColor bc, string s, params object[] args)
        {
            W(fc, bc, s + Environment.NewLine, args);
        }
        /// <summary>
        /// 往控制台输出一段彩色文本（带换行，指定前景色）
        /// </summary>
        /// <param name="fc">前景色</param>
        /// <param name="bc">背景色</param>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void WL(ConsoleColor fc, string s, params object[] args)
        {
            W(fc, _defaultBackgroundColor, s + Environment.NewLine, args);
        }
        /// <summary>
        /// 往控制台输出一段彩色文本（带换行，用默认颜色）
        /// </summary>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void WL(string s, params object[] args)
        {
            W(_defaultForegroundColor, _defaultBackgroundColor, s + Environment.NewLine, args);
        }

        /// <summary>
        /// 往控制台输出一个空行
        /// </summary>
        public void WL()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// 输出颜色表
        /// </summary>
        public void WCT()
        {
            W(ConsoleColor.Blue, "Blue");
            W(ConsoleColor.Cyan, "Cyan");
            W(ConsoleColor.DarkBlue, "DarkBlue");
            W(ConsoleColor.DarkCyan, "DarkCyan");
            W(ConsoleColor.DarkGray, "DarkGray");
            W(ConsoleColor.DarkGreen, "DarkGreen");
            W(ConsoleColor.DarkMagenta, "DarkMagenta");
            W(ConsoleColor.DarkRed, "DarkRed");
            W(ConsoleColor.DarkYellow, "DarkYellow");
            W(ConsoleColor.Gray, "Gray");
            W(ConsoleColor.Green, "Green");
            W(ConsoleColor.Magenta, "Magenta");
            W(ConsoleColor.Red, "Red");
            W(ConsoleColor.White, "White");
            W(ConsoleColor.Yellow, "Yellow");
        }

        #endregion

        #region Write Methods

        public void W(DataTable dt)
        {
            if (dt == null) return;
            W(dt, 0, dt.Rows.Count - 1);
        }
        public void W(DataView dv)
        {
            if (dv == null) return;
            W(dv, 0, dv.Count - 1);
        }
        public void W(DataTable dt, int startIndex, int endIndex)
        {
            if (dt == null) return;
            if (startIndex > endIndex) { int tmp = endIndex; endIndex = startIndex; startIndex = tmp; }
            if (startIndex > dt.Rows.Count - 1) startIndex = dt.Rows.Count - 1;
            if (endIndex > dt.Rows.Count - 1) endIndex = dt.Rows.Count - 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    DataColumn dc = dt.Columns[j];
                    Console.Write("{0}：{1}\t\t", dc.Caption, dr[dc].ToString());
                }
                W("\n");
            }
            W("\n");
        }
        public void W(DataView dv, int startIndex, int endIndex)
        {
            if (dv == null) return;
            if (startIndex > endIndex) { int tmp = endIndex; endIndex = startIndex; startIndex = tmp; }
            if (startIndex > dv.Count - 1) startIndex = dv.Count - 1;
            if (endIndex > dv.Count - 1) endIndex = dv.Count - 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                DataRow dr = dv[i].Row;
                for (int j = 0; j < dv.Table.Columns.Count; j++)
                {
                    DataColumn dc = dv.Table.Columns[j];
                    W("{0}：{1}\t\t", dc.Caption, dr[dc].ToString());
                }
                W("\n");
            }
            W("\n");
        }

        public void W<T>(IEnumerable<T> os)
        {
            bool isFirst = true;
            foreach (var o in os)
            {
                if (isFirst)
                {
                    W(o.ToString());
                    isFirst = false;
                }
                else W(", " + o.ToString());
            }
        }

        #endregion
    }
}
