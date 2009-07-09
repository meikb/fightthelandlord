#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
#endregion

namespace 麻将
{
    #region 分组规则 枚举

    /// <summary>
    /// 根据麻将规则所归纳出来的，包括 一对（两张一样的），顺子（三张连续的），刻子（三张一样的）
    /// </summary>
    public enum 分组规则 : int
    {
        对子 = 1,
        顺子 = 2,
        刻子 = 3,
    }

    #endregion

    #region 组牌 类

    /// <summary>
    /// 按麻将分组规则将一手牌存为数个“组牌”，该类实例用于描述其中之一
    /// </summary>
    public class 组牌
    {
        public 牌[] 牌数组;
        public 分组规则 分组规则;
        //public int 哈希码;
        public 组牌(牌[] ps, 分组规则 gr)
        {
            this.牌数组 = ps;
            this.分组规则 = gr;

            //// 因为麻将的情况不可能超过 每张牌 10bit 的存放能力
            //// 3 张共占 10bit , 即：张, 花, 点 = 3 + 3 + 4,  10 * 3 = 30bit
            //if (ps.Length == 1)
            //{
            //    var p1 = ps[0];
            //    this.哈希码 = ((p1.张 << 7) | (p1.花 << 4) | p1.点);
            //}
            //else if (ps.Length == 2)
            //{
            //    var p1 = ps[0];
            //    var p2 = ps[1];
            //    this.哈希码 =
            //            ((p1.张 << 7) | (p1.花 << 4) | p1.点) |
            //            (((p2.张 << 7) | (p2.花 << 4) | p2.点) << 10);
            //}
            //else
            //{
            //    var p1 = ps[0];
            //    var p2 = ps[1];
            //    var p3 = ps[2];
            //    this.哈希码 =
            //            ((p1.张 << 7) | (p1.花 << 4) | p1.点) |
            //            (((p2.张 << 7) | (p2.花 << 4) | p2.点) << 10) |
            //            (((p3.张 << 7) | (p3.花 << 4) | p3.点) << 20);
            //}
        }
    }

    #endregion

    #region 分组结果 类

    /// <summary>
    /// 组牌的数组 + 剩下的牌（没办法用规则去匹配的散牌） 的组合体，含 对组牌的数组 的等级（用于判断牌的好坏，是否胡牌( > 1000 )）
    /// </summary>
    public class 分组结果
    {
        public int 等级;
        public List<组牌> 组牌集合;
        public 牌[] 剩牌数组;

        public 分组结果(List<组牌> groups, 牌[] left)
        {
            this.组牌集合 = groups;
            this.剩牌数组 = left;
            if (groups != null && groups.Count > 0)
            {
                this.等级 = groups.Sum(o => (int)o.分组规则);
            }
            else this.等级 = 0;
            if (left == null || left.Length == 0) this.等级 += 1000;    // const 1000
        }
    }

    #endregion

    public static class Handler
    {
        #region 牌显示 相关
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

        public static string 获取显示字串(this 牌 p)
        {
            return string.Format("{0} x {1}", _牌显示[p.花][p.点], p.张);
        }
        #endregion

        #region 随机数 相关

        /// <summary>
        /// 返回一个随机数（0 ~ m-1）（线程安全）
        /// </summary>
        public static int 获取随机数(int m)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rndBytes = new byte[4];
            rng.GetBytes(rndBytes);
            int rand = BitConverter.ToInt32(rndBytes, 0);
            return Math.Abs(rand % m);
        }
        #endregion

        #region 按麻将规则获取牌 相关

        /// <summary>
        /// 判断并返回一手牌中的所有的“顺子”（三张连续的）
        /// </summary>
        public static 牌[][] 获取所有顺子(this 牌[] ps)
        {
            var maxCount = ps.Length - 2;
            if (maxCount <= 0) return new 牌[0][];
            var result = new 牌[maxCount][];
            int idx = 0;
            for (int i = 0; i < maxCount; i++)
            {
                var 花点 = ps[i].花点;
                if (花点 + 1 == ps[i + 1].花点 &&
                    花点 + 2 == ps[i + 2].花点)
                {
                    result[idx++] = new 牌[] {
                        new 牌 { 花点 = 花点, 张 = 1 }, 
                        new 牌 { 花点 = (ushort)(花点 + 1), 张 = 1 }, 
                        new 牌 { 花点 = (ushort)(花点 + 2), 张 = 1 } 
                    };
                }
            }
            if (idx < maxCount) Array.Resize<牌[]>(ref result, idx);
            if (idx == 0) return new 牌[0][];
            return result;
        }

        /// <summary>
        /// 判断并返回一手牌中的所有的“刻子”（三张一样的）
        /// </summary>
        public static 牌[][] 获取所有刻子(this 牌[] ps)
        {
            return (from p in ps
                    where p.张 >= 3
                    select new 牌[] { 
                        new 牌{ 花点 = p.花点, 张 = 3}
                    }).ToArray();
        }

        /// <summary>
        /// 判断并返回一手牌中的所有的“对子”（两张一样的），如果有 4 张，只取 2 张，无重复
        /// </summary>
        public static 牌[][] 获取所有对子(this 牌[] ps)
        {
            return (from p in ps
                    where p.张 >= 2
                    select new 牌[] { 
                        new 牌{ 花点 = p.花点, 张 = 2} 
                    }).ToArray();
        }

        #endregion

        #region 排序 相关

        /// <summary>
        /// 按每组第一张的花点排序
        /// </summary>
        public static List<组牌> 排序(this List<组牌> gs)
        {
            gs.Sort(new Comparison<组牌>((a, b) =>
            {
                if (a.分组规则 == b.分组规则)
                    return a.牌数组[0].花点.CompareTo(b.牌数组[0].花点);
                return a.分组规则.CompareTo(b.分组规则);
            }));
            return gs;
        }

        public static List<分组结果> 排序(this List<分组结果> rs)
        {
            rs.Sort(new Comparison<分组结果>((b, a) =>
            {
                if (a.等级 == b.等级)
                    if (a.组牌集合.Count == b.组牌集合.Count)
                        return b.剩牌数组.Length.CompareTo(a.剩牌数组.Length);
                    else return a.组牌集合.Count.CompareTo(b.组牌集合.Count);
                else return a.等级.CompareTo(b.等级);
            }));
            return rs;
        }

        #endregion

        #region 检查 分组结果 相关

        public static bool 检查是否存在(this List<分组结果> rs, List<组牌> groups)
        {
            int count = groups.Count, idx;
            foreach (var r in rs)
            {
                var gs = r.组牌集合;
                if (gs.Count < count) continue;
                idx = 0;
                for (idx = 0; idx < count; idx++)
                {
                    if (gs[idx].分组规则 != groups[idx].分组规则 ||
                        gs[idx].牌数组[0].数据 != groups[idx].牌数组[0].数据
                        ) break;
                }
                if (idx == count) return true;
            }
            return false;
        }

        #endregion

        #region 分组结果集合 计算 相关

        /// <summary>
        /// 暂时采用的算法：第一次先 拿出一个 对子，之后持续拿三张的顺子或刻子
        /// </summary>
        public static List<分组结果> 计算分组结果集合(this 牌[] 手牌)
        {
            var 分组结果集合 = new List<分组结果>();
            if (手牌 == null || 手牌.Length == 0) return 分组结果集合;

            //var 所有刻子 = 手牌.获取所有刻子();
            //foreach (var 刻子 in 所有刻子)
            //{
            //    var 组牌集合 = new List<组牌>();
            //    组牌集合.Add(new 组牌(刻子, 分组规则.刻子));
            //    var 剩牌 = ((牌[])手牌.Clone()).移走(刻子);
            //    if (剩牌 != null && 剩牌.Length > 0)
            //        计算分组结果集合(分组结果集合, 组牌集合, 剩牌);
            //    else
            //        分组结果集合.Add(new 分组结果(组牌集合, 剩牌));
            //}

            //var 所有顺子 = 手牌.获取所有顺子();
            //foreach (var 顺子 in 所有顺子)
            //{
            //    var 组牌集合 = new List<组牌>();
            //    组牌集合.Add(new 组牌(顺子, 分组规则.顺子));
            //    var 剩牌 = ((牌[])手牌.Clone()).移走(顺子);
            //    if (剩牌 != null && 剩牌.Length > 0)
            //        计算分组结果集合(分组结果集合, 组牌集合, 剩牌);
            //    else
            //        分组结果集合.Add(new 分组结果(组牌集合, 剩牌));
            //}

            var 所有对子 = 手牌.获取所有对子();
            foreach (var 对子 in 所有对子)
            {
                var 组牌集合 = new List<组牌>();
                组牌集合.Add(new 组牌(对子, 分组规则.对子));
                var 剩牌 = ((牌[])手牌.Clone()).移走(对子);
                if (剩牌 != null && 剩牌.Length > 0)
                    计算分组结果集合(分组结果集合, 组牌集合, 剩牌);
                else
                    分组结果集合.Add(new 分组结果(组牌集合, 剩牌));
            }

            if (
                //所有刻子.Length == 0 && 
                //所有顺子.Length == 0 && 
                所有对子.Length == 0
            )
            {
                分组结果集合.Add(new 分组结果(new List<组牌>(), 手牌));
            }

            return 分组结果集合;
        }

        public static void 计算分组结果集合(List<分组结果> 分组结果集合, List<组牌> 原组牌集合, 牌[] 原剩牌)
        {
            var 所有刻子 = 原剩牌.获取所有刻子();
            if (所有刻子 != null)
            {
                foreach (var 刻子 in 所有刻子)
                {
                    var 新组牌 = new List<组牌>(原组牌集合);
                    新组牌.Add(new 组牌(刻子, 分组规则.刻子));

                    新组牌.排序();
                    if (分组结果集合.检查是否存在(新组牌)) return;

                    var 剩牌 = ((牌[])原剩牌.Clone()).移走(刻子);
                    if (剩牌 != null && 剩牌.Length > 0)
                        计算分组结果集合(分组结果集合, 新组牌, 剩牌);
                    else
                        分组结果集合.Add(new 分组结果(新组牌, 剩牌));
                }
            }

            var 所有顺子 = 原剩牌.获取所有顺子();
            if (所有顺子 != null)
            {
                foreach (var 顺子 in 所有顺子)
                {
                    var 新组牌 = new List<组牌>(原组牌集合);
                    新组牌.Add(new 组牌(顺子, 分组规则.顺子));

                    新组牌.排序();
                    if (分组结果集合.检查是否存在(新组牌)) return;

                    var 剩牌 = ((牌[])原剩牌.Clone()).移走(顺子);
                    if (剩牌 != null && 剩牌.Length > 0)
                        计算分组结果集合(分组结果集合, 新组牌, 剩牌);
                    else
                        分组结果集合.Add(new 分组结果(新组牌, 剩牌));
                }
            }

            //var 所有对子 = 原剩牌.获取所有对子();
            //if (所有对子 != null)
            //{
            //    foreach (var 对子 in 所有对子)
            //    {
            //        var 新组牌 = new List<组牌>(原组牌集合);
            //        新组牌.Add(new 组牌(对子, 分组规则.对子));

            //        新组牌.排序();
            //        if (分组结果集合.检查是否存在(新组牌)) return;

            //        var 剩牌 = ((牌[])原剩牌.Clone()).移走(对子);
            //        if (剩牌 != null && 剩牌.Length > 0)
            //            计算分组结果集合(分组结果集合, 新组牌, 剩牌);
            //        else
            //            分组结果集合.Add(new 分组结果(新组牌, 剩牌));
            //    }
            //}

            if (
                所有刻子.Length == 0 &&
                所有顺子.Length == 0// &&
                //所有对子.Length == 0
                )
            {
                分组结果集合.Add(new 分组结果(new List<组牌>(原组牌集合), 原剩牌));
                return;
            }
        }


        #endregion

        #region 一副牌的数据

        public static readonly 牌[] 一副牌 = new 牌[] {
            // 万
            new 牌 { 数据 = 0x040101u }, 
            new 牌 { 数据 = 0x040102u }, 
            new 牌 { 数据 = 0x040103u }, 
            new 牌 { 数据 = 0x040104u }, 
            new 牌 { 数据 = 0x040105u }, 
            new 牌 { 数据 = 0x040106u }, 
            new 牌 { 数据 = 0x040107u }, 
            new 牌 { 数据 = 0x040108u }, 
            new 牌 { 数据 = 0x040109u }, 
            // 条
            new 牌 { 数据 = 0x040201u }, 
            new 牌 { 数据 = 0x040202u }, 
            new 牌 { 数据 = 0x040203u }, 
            new 牌 { 数据 = 0x040204u }, 
            new 牌 { 数据 = 0x040205u }, 
            new 牌 { 数据 = 0x040206u }, 
            new 牌 { 数据 = 0x040207u }, 
            new 牌 { 数据 = 0x040208u }, 
            new 牌 { 数据 = 0x040209u }, 
            // 筒
            new 牌 { 数据 = 0x040301u }, 
            new 牌 { 数据 = 0x040302u }, 
            new 牌 { 数据 = 0x040303u }, 
            new 牌 { 数据 = 0x040304u }, 
            new 牌 { 数据 = 0x040305u }, 
            new 牌 { 数据 = 0x040306u }, 
            new 牌 { 数据 = 0x040307u }, 
            new 牌 { 数据 = 0x040308u }, 
            new 牌 { 数据 = 0x040309u }, 
            // 字
            new 牌 { 数据 = 0x040410u }, 
            new 牌 { 数据 = 0x040420u }, 
            new 牌 { 数据 = 0x040430u }, 
            // 风
            new 牌 { 数据 = 0x040510u }, 
            new 牌 { 数据 = 0x040520u }, 
            new 牌 { 数据 = 0x040530u }, 
            new 牌 { 数据 = 0x040540u }, 
            // 花
            new 牌 { 数据 = 0x010601u }, 
            new 牌 { 数据 = 0x010602u }, 
            new 牌 { 数据 = 0x010603u }, 
            new 牌 { 数据 = 0x010604u }, 
            new 牌 { 数据 = 0x010605u }, 
            new 牌 { 数据 = 0x010606u }, 
            new 牌 { 数据 = 0x010607u }, 
            new 牌 { 数据 = 0x010608u }, 
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
                            _一副牌单张序列[counter++].数据 = p.花点 | 0x010000u;
                        }
                    }
                }
                return _一副牌单张序列;
            }
        }

        #endregion
    }

}
