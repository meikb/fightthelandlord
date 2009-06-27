using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 牌之算法研究
{
    /// <summary>
    /// 表示一张牌（由高到低：状态, 张数，花色，点数，每个占 1 byte）
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4, CharSet = CharSet.Ansi)]
    public struct 牌
    {
        [FieldOffset(0)]
        public int 整个;
        [FieldOffset(0)]
        public ushort 花点;
        [FieldOffset(3)]
        public byte 态;
        [FieldOffset(2)]
        public byte 张;
        [FieldOffset(1)]
        public byte 花;
        [FieldOffset(0)]
        public byte 点;

        public override string ToString()
        {
            string 花显示, 点显示;
            switch (花)
            {
                case 1:
                    花显示 = "黑桃"; break;
                case 2:
                    花显示 = "红桃"; break;
                case 3:
                    花显示 = "樱花"; break;
                case 4:
                    花显示 = "方块"; break;
                case 5:
                    花显示 = "小丑"; break;
                default:
                    花显示 = 花.ToString(); break;
            }
            if (花 == 5) 点显示 = 点 == 1 ? "大王" : "小王";
            else
            {
                if (点 == 1) 点显示 = "A";
                else if (点 == 11) 点显示 = "J";
                else if (点 == 12) 点显示 = "Q";
                else if (点 == 13) 点显示 = "K";
                else 点显示 = 点.ToString();
            }
            return string.Format("{1} {2} x {0}", 张, 花显示, 点显示);
        }
    }

    public class 扑克
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
            new 牌 { 整个 = 0x010501 }, 
            new 牌 { 整个 = 0x010502 }, 
        };
    }
}
