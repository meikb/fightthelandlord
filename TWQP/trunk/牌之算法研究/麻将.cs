using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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

        /// <summary>
        /// 返回一个随机数（0 ~ m-1）（线程安全）
        /// </summary>
        public static int Rnd(int m)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rndBytes = new byte[4];
            rng.GetBytes(rndBytes);
            int rand = BitConverter.ToInt32(rndBytes, 0);
            return Math.Abs(rand % m);
        }

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
            return (from kv in ps
                    where kv.张 >= 3
                    select new 牌[] { 
                        new 牌{ 花点=kv.花点, 张=1},
                        new 牌{ 花点=kv.花点, 张=1},
                        new 牌{ 花点=kv.花点, 张=1} 
                    }).ToArray();
        }

        /// <summary>
        /// 判断并返回一手牌中的所有的“对子”（两张一样的），如果有 4 张，只取 2 张，无重复
        /// </summary>
        public static 牌[][] 获取所有对子(this 牌[] ps)
        {
            return (from kv in ps
                    where kv.张 >= 2
                    select new 牌[] { 
                        new 牌{ 花点=kv.花点, 张=1},
                        new 牌{ 花点=kv.花点, 张=1} 
                    }).ToArray();
        }

        /// <summary>
        /// 从一个牌数组中 减去 另一个牌数组 并返回剩下的牌（表现为 张 变化，结果不含 张 为 0 的）
        /// </summary>
        public static 牌[] Remove(this 牌[] source, 牌[] target)
        {
            // 1. 找到 source 中的 target 第一张的位置, 
            // 2. 做减法之后判断下一张牌是否相同，
            // 3. 相同则做减法，如果减法结果为 0，则从 source 中剔除该牌
            // 4. 之后判断 s & t 中的下一张牌是否相同，跳到 2
            // 5. 不同则从 s 的下一张开始找到 t 中的下一张的位置，跳到 2
            // 6. 如果 target 没有下一张牌，则执行完成并返回

            int sIdx = 0, tIdx = 0, sCount = source.Length, tCount = target.Length;
            while (sIdx < sCount && tIdx < tCount)
            {
                if (source[sIdx].花点 == target[tIdx].花点)
                {
                    source[sIdx].张 -= target[tIdx].张;
                    if (source[sIdx].张 == 0)
                    {
                        sCount--;
                        if (sIdx < sCount)
                        {
                            Array.Copy(source, sIdx + 1, source, sIdx, sCount - sIdx);
                        }
                    }
                    sIdx++; tIdx++;
                    continue;
                }
                else
                {
                    sIdx++;
                    continue;
                }
            }
            if (sIdx == sCount) throw new Exception("数组中没有足够的牌做减法");
            Array.Resize<牌>(ref source, sCount);
            return source;
        }


        public static List<规则组> 按每组第一张的花点排序(this List<规则组> gs)
        {
            gs.Sort(new Comparison<规则组>((a, b) =>
            {
                if (a.分组规则 == b.分组规则)
                    return a.计数牌数组[0].花点.CompareTo(b.计数牌数组[0].花点);
                return a.分组规则.CompareTo(b.分组规则);
            }));
            return gs;
        }

        //public static List<Result> SortByRank(this List<Result> results)
        //{
        //    results.Sort(new Comparison<Result>((b, a) =>
        //    {
        //        if (a.Rank == b.Rank)
        //            if (a.Gs.Count == b.Gs.Count)
        //                return b.LeftTPs.Length.CompareTo(a.LeftTPs.Length);
        //            else return a.Gs.Count.CompareTo(b.Gs.Count);
        //        else return a.Rank.CompareTo(b.Rank);
        //    }));
        //    return results;
        //}

        //public static bool CheckExists(this List<Result> results, List<Group> groups)
        //{
        //    int count = groups.Count, idx;
        //    foreach (var result in results)
        //    {
        //        var gs = result.Gs;
        //        if (gs.Count < count) continue;
        //        idx = 0;
        //        for (idx = 0; idx < count; idx++)
        //            if (gs[idx].HashCode != groups[idx].HashCode) break;
        //        if (idx == count) return true;
        //    }
        //    return false;
        //}


    }

    /// <summary>
    /// 根据麻将规则所归纳出来的，包括 一对（两张一样的），顺子（三张连续的），刻子（三张一样的）
    /// </summary>
    public enum 分组规则枚举 : int
    {
        Get11 = 1,
        Get123 = 2,
        Get111 = 3,
    }

    /// <summary>
    /// 按麻将分组规则将一手牌存为数个“小组合”，该类实例用于描述其中之一
    /// </summary>
    public class 规则组
    {
        public 牌[] 计数牌数组;
        public 分组规则枚举 分组规则;
        public int 计数牌数组哈希码;
        public 规则组(牌[] ps, 分组规则枚举 gr)
        {
            this.计数牌数组 = ps;
            this.分组规则 = gr;
            if (ps.Length == 1)
            {
                // 同样花色的牌，直接过滤掉状态信息即为 hash
                this.计数牌数组哈希码 = (int)(ps[0].数据 & 0x00FFFFFFu);
            }
            else
            {
                // 因为麻将的情况不可能超过 3bit 的存放能力
                // 3 张则各占 9bit , 即：张, 花, 点 = 3 + 3 + 3,  9 * 3 = 27bit
                var p1 = ps[0];
                var p2 = ps[1];
                var p3 = ps[2];
                this.计数牌数组哈希码 =
                        ((p1.张 << 6) | (p1.花 << 3) | p1.点) |
                        (((p2.张 << 6) | (p2.花 << 3) | p2.点) << 9) |
                        (((p3.张 << 6) | (p3.花 << 3) | p3.点) << 18);
            }
        }
    }

    /// <summary>
    /// 规则组的数组 + 剩下的牌（没办法用规则去匹配的散牌） 的组合体，含 对规则组的数组 的等级（用于判断牌的好坏，是否胡牌( > 1000 )）
    /// </summary>
    public class 分组结果
    {
        public int 等级;
        public List<规则组> 规则组数组;
        public 牌[] 剩下的计数牌数组;

        public 分组结果(List<规则组> groups, 牌[] left)
        {
            this.规则组数组 = groups;
            this.剩下的计数牌数组 = left;
            if (groups != null && groups.Count > 0)
            {
                this.等级 = groups.Sum(o => (int)o.分组规则);
            }
            else this.等级 = 0;
            if (left == null || left.Length == 0) this.等级 += 1000;    // const 1000
        }
    }


    public class Handler
    {
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
    }
}
