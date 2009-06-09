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

        private static object _syncObj = new object();

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
        private Writer() { }

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
            RL(ConsoleColor.Green, ConsoleColor.Black, "按回车继续...");
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
        /// 往控制台的某坐标输出一段彩色文本（指定前背景色）
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="isRestoreLocation">是否于显示完之后恢复上次的坐标</param>
        /// <param name="fc">前景色</param>
        /// <param name="bc">背景色</param>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void W(int x, int y, bool isRestoreLocation, ConsoleColor fc, ConsoleColor bc, string s, params object[] args)
        {
            lock (_syncObj)
            {
                int ox = 0, oy = 0;
                if (isRestoreLocation)
                {
                    ox = Console.CursorLeft;
                    oy = Console.CursorTop;
                }

                Console.SetCursorPosition(Console.WindowLeft + x, Console.WindowTop + y);
                Console.ForegroundColor = fc;
                Console.BackgroundColor = bc;
                Console.Write(s, args);
                Console.ForegroundColor = _defaultForegroundColor;
                Console.BackgroundColor = _defaultBackgroundColor;
                if (isRestoreLocation)
                {
                    Console.SetCursorPosition(ox, oy);
                }
            }
        }

        /// <summary>
        /// 往控制台输出一段彩色文本（指定前背景色）
        /// </summary>
        /// <param name="fc">前景色</param>
        /// <param name="bc">背景色</param>
        /// <param name="s">格式化文本</param>
        /// <param name="args">格式化参数</param>
        public void W(ConsoleColor fc, ConsoleColor bc, string s, params object[] args)
        {
            lock (_syncObj)
            {
                Console.ForegroundColor = fc;
                Console.BackgroundColor = bc;
                Console.Write(s, args);
                Console.ForegroundColor = _defaultForegroundColor;
                Console.BackgroundColor = _defaultBackgroundColor;
            }
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
            W(Environment.NewLine);
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
                    W("{0}：{1}\t\t", dc.Caption, dr[dc].ToString());
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
