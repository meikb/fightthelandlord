using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 麻将
{
    public static class ExtendMethods
    {
        public static readonly string[][] _牌显示 = new string[][]
        {
            new string[] {},
	        new string[] { "", "一万", "二万", "三万", "四万", "五万", "六万", "七万", "八万", "九万" },
	        new string[] { "", "一条", "二条", "三条", "四条", "五条", "六条", "七条", "八条", "九条" },
	        new string[] { "", "一筒", "二筒", "三筒", "四筒", "五筒", "六筒", "七筒", "八筒", "九筒" },
	        new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "红中", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 
                "发财", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "白板" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "东风", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "南风", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "西风", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                "北风" },
            new string[] { "", "春", "夏", "秋", "冬", "梅", "兰", "竹", "菊" },
        };

        public static string ToDisplayString(this 牌 p)
        {
            return string.Format("{0} x {1}", _牌显示[p.花][p.点], p.张);
        }
    }

    public class Handler
    {
        public static readonly 牌[] 一副牌 = new 牌[] {
            // 万
            new 牌 { 整个 = 0x040101u }, 
            new 牌 { 整个 = 0x040102u }, 
            new 牌 { 整个 = 0x040103u }, 
            new 牌 { 整个 = 0x040104u }, 
            new 牌 { 整个 = 0x040105u }, 
            new 牌 { 整个 = 0x040106u }, 
            new 牌 { 整个 = 0x040107u }, 
            new 牌 { 整个 = 0x040108u }, 
            new 牌 { 整个 = 0x040109u }, 
            // 条
            new 牌 { 整个 = 0x040201u }, 
            new 牌 { 整个 = 0x040202u }, 
            new 牌 { 整个 = 0x040203u }, 
            new 牌 { 整个 = 0x040204u }, 
            new 牌 { 整个 = 0x040205u }, 
            new 牌 { 整个 = 0x040206u }, 
            new 牌 { 整个 = 0x040207u }, 
            new 牌 { 整个 = 0x040208u }, 
            new 牌 { 整个 = 0x040209u }, 
            // 筒
            new 牌 { 整个 = 0x040301u }, 
            new 牌 { 整个 = 0x040302u }, 
            new 牌 { 整个 = 0x040303u }, 
            new 牌 { 整个 = 0x040304u }, 
            new 牌 { 整个 = 0x040305u }, 
            new 牌 { 整个 = 0x040306u }, 
            new 牌 { 整个 = 0x040307u }, 
            new 牌 { 整个 = 0x040308u }, 
            new 牌 { 整个 = 0x040309u }, 
            // 字
            new 牌 { 整个 = 0x040410u }, 
            new 牌 { 整个 = 0x040420u }, 
            new 牌 { 整个 = 0x040430u }, 
            // 风
            new 牌 { 整个 = 0x040510u }, 
            new 牌 { 整个 = 0x040520u }, 
            new 牌 { 整个 = 0x040530u }, 
            new 牌 { 整个 = 0x040540u }, 
            // 花
            new 牌 { 整个 = 0x010601u }, 
            new 牌 { 整个 = 0x010602u }, 
            new 牌 { 整个 = 0x010603u }, 
            new 牌 { 整个 = 0x010604u }, 
            new 牌 { 整个 = 0x010605u }, 
            new 牌 { 整个 = 0x010606u }, 
            new 牌 { 整个 = 0x010607u }, 
            new 牌 { 整个 = 0x010608u }, 
        };

        private static 牌[] _一副牌单张序列 = null;
        public static 牌[] 一副牌单张序列
        {
            get
            {
                if (_一副牌单张序列 == null)
                {
                    _一副牌单张序列 = new 牌[(144)]; // 9 * 4 * 3 + 3 * 4 + 4 * 4 + 8 * 1
                    var counter = 0;
                    foreach (var p in 一副牌)
                    {
                        for (int i = 0; i < p.张; i++)
                        {
                            _一副牌单张序列[counter++].整个 = p.花点 | 0x010000u;
                        }
                    }
                }
                return _一副牌单张序列;
            }
        }
    }
}
