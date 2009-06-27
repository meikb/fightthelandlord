using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 扑克
{
    public static class ExtendMethods
    {
        public static readonly string[][] _牌显示 = new string[][]
        {
            new string[] { "", "Ａ", "２", "３", "４", "５", "６", "７", "８", "９", "⒑", "Ｊ", "Ｑ", "Ｋ", "小鬼", "大鬼" },
	        new string[] { "", "黑桃Ａ", "黑桃２", "黑桃３", "黑桃４", "黑桃５", "黑桃６", "黑桃７", "黑桃８", "黑桃９", "黑桃⒑", "黑桃Ｊ", "黑桃Ｑ", "黑桃Ｋ" },
	        new string[] { "", "红桃Ａ", "红桃２", "红桃３", "红桃４", "红桃５", "红桃６", "红桃７", "红桃８", "红桃９", "红桃⒑", "红桃Ｊ", "红桃Ｑ", "红桃Ｋ" },
	        new string[] { "", "樱花Ａ", "樱花２", "樱花３", "樱花４", "樱花５", "樱花６", "樱花７", "樱花８", "樱花９", "樱花⒑", "樱花Ｊ", "樱花Ｑ", "樱花Ｋ" },
            new string[] { "", "方块Ａ", "方块２", "方块３", "方块４", "方块５", "方块６", "方块７", "方块８", "方块９", "方块⒑", "方块Ｊ", "方块Ｑ", "方块Ｋ" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "小鬼", "大鬼" },
        };

        public static string ToDisplayString(this 牌 p)
        {
            return string.Format("{0} x {1}", _牌显示[p.花][p.点], p.张);
        }


        /// <summary>
        /// 按点数（忽略花色），从小到大排列元素，统计并 Resize 数组本身
        /// </summary>
        /// <param name="ps">目标数组</param>
        public static 牌[] 转为点计数牌序列(this 牌[] ps)
        {
            int lastIdx = ps.Length - 1;
            牌 temp;
            // 对比是否有重复并计数，移动到最后
            for (int i = 0; i < lastIdx; i++)
            {
                ps[i].张 = 1;
                ps[i].花 = 0;
                for (int j = i + 1; j <= lastIdx; j++)
                {
                    if (ps[i].点 == ps[j].点)
                    {
                        temp = ps[j];
                        ps[j] = ps[lastIdx];
                        ps[lastIdx] = temp;
                        ps[i].张++;
                        lastIdx--;
                        j--;
                    }
                }
            }
            // resize
            Array.Resize<牌>(ref ps, lastIdx + 1);
            // 按花色从小到大排序
            Array.Sort<牌>(ps, (p1, p2) => { return p1.点.CompareTo(p2.点); });
            return ps;
        }


        /// <summary>
        /// 按点数（忽略花色），从小到大排列元素，返回统计结果数据
        /// </summary>
        /// <param name="ps">目标数组</param>
        /// <returns>计数牌数组</returns>
        public static 牌[] 获取点计数牌序列(this IEnumerable<牌> ps)
        {
            var result = from p in ps
                         group p by p.点 into g
                         orderby g.Key
                         select new 牌 { 花点 = g.Key, 张 = (byte)g.Count() };
            return result.ToArray();
        }

    }

    public class Handler
    {
        public static readonly 牌[] 一副牌 = new 牌[] {
            // 黑
            new 牌 { 整个 = 0x010101u },   // A
            new 牌 { 整个 = 0x010102u }, 
            new 牌 { 整个 = 0x010103u }, 
            new 牌 { 整个 = 0x010104u }, 
            new 牌 { 整个 = 0x010105u }, 
            new 牌 { 整个 = 0x010106u }, 
            new 牌 { 整个 = 0x010107u }, 
            new 牌 { 整个 = 0x010108u }, 
            new 牌 { 整个 = 0x010109u }, 
            new 牌 { 整个 = 0x01010Au },   // 10
            new 牌 { 整个 = 0x01010Bu },   // J
            new 牌 { 整个 = 0x01010Cu },   // Q
            new 牌 { 整个 = 0x01010Du },   // K
            // 红
            new 牌 { 整个 = 0x010201u },   // A
            new 牌 { 整个 = 0x010202u }, 
            new 牌 { 整个 = 0x010203u }, 
            new 牌 { 整个 = 0x010204u }, 
            new 牌 { 整个 = 0x010205u }, 
            new 牌 { 整个 = 0x010206u }, 
            new 牌 { 整个 = 0x010207u }, 
            new 牌 { 整个 = 0x010208u }, 
            new 牌 { 整个 = 0x010209u }, 
            new 牌 { 整个 = 0x01020Au },   // 10
            new 牌 { 整个 = 0x01020Bu },   // J
            new 牌 { 整个 = 0x01020Cu },   // Q
            new 牌 { 整个 = 0x01020Du },   // K
            // 樱
            new 牌 { 整个 = 0x010301u },   // A
            new 牌 { 整个 = 0x010302u }, 
            new 牌 { 整个 = 0x010303u }, 
            new 牌 { 整个 = 0x010304u }, 
            new 牌 { 整个 = 0x010305u }, 
            new 牌 { 整个 = 0x010306u }, 
            new 牌 { 整个 = 0x010307u }, 
            new 牌 { 整个 = 0x010308u }, 
            new 牌 { 整个 = 0x010309u }, 
            new 牌 { 整个 = 0x01030Au },   // 10
            new 牌 { 整个 = 0x01030Bu },   // J
            new 牌 { 整个 = 0x01030Cu },   // Q
            new 牌 { 整个 = 0x01030Du },   // K
            // 方
            new 牌 { 整个 = 0x010401u },   // A
            new 牌 { 整个 = 0x010402u }, 
            new 牌 { 整个 = 0x010403u }, 
            new 牌 { 整个 = 0x010404u }, 
            new 牌 { 整个 = 0x010405u }, 
            new 牌 { 整个 = 0x010406u }, 
            new 牌 { 整个 = 0x010407u }, 
            new 牌 { 整个 = 0x010408u }, 
            new 牌 { 整个 = 0x010409u }, 
            new 牌 { 整个 = 0x01040Au },   // 10
            new 牌 { 整个 = 0x01040Bu },   // J
            new 牌 { 整个 = 0x01040Cu },   // Q
            new 牌 { 整个 = 0x01040Du },   // K
            // 小鬼，大鬼
            new 牌 { 整个 = 0x01050Eu },   // 小鬼
            new 牌 { 整个 = 0x01050Fu },   // 大鬼
        };
    }
}
