using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 麻将
{
    public static class ExtendMethods
    {
        public static string ToDisplayString(this 牌 p)
        {
            string 花显示, 点显示;
            switch (p.花)
            {
                case 1:
                    花显示 = "万"; break;
                case 2:
                    花显示 = "条"; break;
                case 3:
                    花显示 = "筒"; break;
                case 4:
                    花显示 = ""; break;
                case 5:
                    花显示 = "风"; break;
                case 6:
                    花显示 = ""; break;
                default:
                    花显示 = p.花.ToString(); break;
            }
            if (p.花 == 4)
            {
                switch (p.点)
                {
                    case 0x10:
                        点显示 = "红中"; break;
                    case 0x20:
                        点显示 = "发财"; break;
                    case 0x30:
                        点显示 = "白板"; break;
                    default:
                        点显示 = p.点.ToString(); break;
                }
            }
            else if (p.花 == 5)
            {
                switch (p.点)
                {
                    case 0x10:
                        点显示 = "东"; break;
                    case 0x20:
                        点显示 = "南"; break;
                    case 0x30:
                        点显示 = "西"; break;
                    case 0x40:
                        点显示 = "北"; break;
                    default:
                        点显示 = p.点.ToString(); break;
                }
            }//春夏秋冬梅兰竹菊
            else if (p.花 == 6)
            {
                switch (p.点)
                {
                    case 0x10:
                        点显示 = "春"; break;
                    case 0x20:
                        点显示 = "夏"; break;
                    case 0x30:
                        点显示 = "秋"; break;
                    case 0x40:
                        点显示 = "冬"; break;
                    case 0x11:
                        点显示 = "梅"; break;
                    case 0x21:
                        点显示 = "兰"; break;
                    case 0x31:
                        点显示 = "竹"; break;
                    case 0x41:
                        点显示 = "菊"; break;
                    default:
                        点显示 = p.点.ToString(); break;
                }
            }
            else
            {
                switch (p.点)
                {
                    case 1:
                        点显示 = "一"; break;
                    case 2:
                        点显示 = "二"; break;
                    case 3:
                        点显示 = "三"; break;
                    case 4:
                        点显示 = "四"; break;
                    case 5:
                        点显示 = "五"; break;
                    case 6:
                        点显示 = "六"; break;
                    case 7:
                        点显示 = "七"; break;
                    case 8:
                        点显示 = "八"; break;
                    case 9:
                        点显示 = "九"; break;
                    default:
                        点显示 = p.点.ToString(); break;
                }
            }

            return string.Format("{2}{1} x {0}", p.张, 花显示, 点显示);
        }
    }

    public class Handler
    {
        public static readonly 牌[] 一副牌 = new 牌[] {
            // 万
            new 牌 { 整个 = 0x040101 }, 
            new 牌 { 整个 = 0x040102 }, 
            new 牌 { 整个 = 0x040103 }, 
            new 牌 { 整个 = 0x040104 }, 
            new 牌 { 整个 = 0x040105 }, 
            new 牌 { 整个 = 0x040106 }, 
            new 牌 { 整个 = 0x040107 }, 
            new 牌 { 整个 = 0x040108 }, 
            new 牌 { 整个 = 0x040109 }, 
            // 条
            new 牌 { 整个 = 0x040201 }, 
            new 牌 { 整个 = 0x040202 }, 
            new 牌 { 整个 = 0x040203 }, 
            new 牌 { 整个 = 0x040204 }, 
            new 牌 { 整个 = 0x040205 }, 
            new 牌 { 整个 = 0x040206 }, 
            new 牌 { 整个 = 0x040207 }, 
            new 牌 { 整个 = 0x040208 }, 
            new 牌 { 整个 = 0x040209 }, 
            // 筒
            new 牌 { 整个 = 0x040301 }, 
            new 牌 { 整个 = 0x040302 }, 
            new 牌 { 整个 = 0x040303 }, 
            new 牌 { 整个 = 0x040304 }, 
            new 牌 { 整个 = 0x040305 }, 
            new 牌 { 整个 = 0x040306 }, 
            new 牌 { 整个 = 0x040307 }, 
            new 牌 { 整个 = 0x040308 }, 
            new 牌 { 整个 = 0x040309 }, 
            // 字
            new 牌 { 整个 = 0x040410 }, 
            new 牌 { 整个 = 0x040420 }, 
            new 牌 { 整个 = 0x040430 }, 
            // 风
            new 牌 { 整个 = 0x040510 }, 
            new 牌 { 整个 = 0x040520 }, 
            new 牌 { 整个 = 0x040530 }, 
            new 牌 { 整个 = 0x040540 }, 
            // 花
            new 牌 { 整个 = 0x010610 }, 
            new 牌 { 整个 = 0x010611 }, 
            new 牌 { 整个 = 0x010620 }, 
            new 牌 { 整个 = 0x010621 }, 
            new 牌 { 整个 = 0x010630 }, 
            new 牌 { 整个 = 0x010631 }, 
            new 牌 { 整个 = 0x010640 }, 
            new 牌 { 整个 = 0x010641 }, 
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
                            _一副牌单张序列[counter++].花点 = p.花点;
                        }
                    }
                }
                return _一副牌单张序列;
            }
        }
    }
}
