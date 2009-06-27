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
            new string[] {},
	        new string[] { "", "黑桃Ａ", "黑桃２", "黑桃３", "黑桃４", "黑桃５", "黑桃６", "黑桃７", "黑桃８", "黑桃９", "黑桃Ｊ", "黑桃Ｑ", "黑桃Ｋ" },
	        new string[] { "", "红桃Ａ", "红桃２", "红桃３", "红桃４", "红桃５", "红桃６", "红桃７", "红桃８", "红桃９", "红桃Ｊ", "红桃Ｑ", "红桃Ｋ" },
	        new string[] { "", "樱花Ａ", "樱花２", "樱花３", "樱花４", "樱花５", "樱花６", "樱花７", "樱花８", "樱花９", "樱花Ｊ", "樱花Ｑ", "樱花Ｋ" },
            new string[] { "", "方块Ａ", "方块２", "方块３", "方块４", "方块５", "方块６", "方块７", "方块８", "方块９", "方块Ｊ", "方块Ｑ", "方块Ｋ" },
            new string[] { "", "大王", "小王" },
        };

        public static string ToDisplayString(this 牌 p)
        {
            return string.Format("{0} x {1}", _牌显示[p.花][p.点], p.张);
        }

    }

    public class Handler
    {
        public static readonly 牌[] 一副牌 = new 牌[] {
            // 黑
            new 牌 { 整个 = 0x010101 },   // A
            new 牌 { 整个 = 0x010102 }, 
            new 牌 { 整个 = 0x010103 }, 
            new 牌 { 整个 = 0x010104 }, 
            new 牌 { 整个 = 0x010105 }, 
            new 牌 { 整个 = 0x010106 }, 
            new 牌 { 整个 = 0x010107 }, 
            new 牌 { 整个 = 0x010108 }, 
            new 牌 { 整个 = 0x010109 }, 
            new 牌 { 整个 = 0x01010A },   // 10
            new 牌 { 整个 = 0x01010B },   // J
            new 牌 { 整个 = 0x01010C },   // Q
            new 牌 { 整个 = 0x01010D },   // K
            // 红
            new 牌 { 整个 = 0x010201 },   // A
            new 牌 { 整个 = 0x010202 }, 
            new 牌 { 整个 = 0x010203 }, 
            new 牌 { 整个 = 0x010204 }, 
            new 牌 { 整个 = 0x010205 }, 
            new 牌 { 整个 = 0x010206 }, 
            new 牌 { 整个 = 0x010207 }, 
            new 牌 { 整个 = 0x010208 }, 
            new 牌 { 整个 = 0x010209 }, 
            new 牌 { 整个 = 0x01020A },   // 10
            new 牌 { 整个 = 0x01020B },   // J
            new 牌 { 整个 = 0x01020C },   // Q
            new 牌 { 整个 = 0x01020D },   // K
            // 樱
            new 牌 { 整个 = 0x010301 },   // A
            new 牌 { 整个 = 0x010302 }, 
            new 牌 { 整个 = 0x010303 }, 
            new 牌 { 整个 = 0x010304 }, 
            new 牌 { 整个 = 0x010305 }, 
            new 牌 { 整个 = 0x010306 }, 
            new 牌 { 整个 = 0x010307 }, 
            new 牌 { 整个 = 0x010308 }, 
            new 牌 { 整个 = 0x010309 }, 
            new 牌 { 整个 = 0x01030A },   // 10
            new 牌 { 整个 = 0x01030B },   // J
            new 牌 { 整个 = 0x01030C },   // Q
            new 牌 { 整个 = 0x01030D },   // K
            // 方
            new 牌 { 整个 = 0x010401 },   // A
            new 牌 { 整个 = 0x010402 }, 
            new 牌 { 整个 = 0x010403 }, 
            new 牌 { 整个 = 0x010404 }, 
            new 牌 { 整个 = 0x010405 }, 
            new 牌 { 整个 = 0x010406 }, 
            new 牌 { 整个 = 0x010407 }, 
            new 牌 { 整个 = 0x010408 }, 
            new 牌 { 整个 = 0x010409 }, 
            new 牌 { 整个 = 0x01040A },   // 10
            new 牌 { 整个 = 0x01040B },   // J
            new 牌 { 整个 = 0x01040C },   // Q
            new 牌 { 整个 = 0x01040D },   // K
            // 王
            new 牌 { 整个 = 0x010501 },   // 大
            new 牌 { 整个 = 0x010502 },   // 小
        };
    }
}
