using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

namespace ConsoleApplication2
{
    /// <summary>
    /// adsfasdfasdf
    /// </summary>
    public class Scaner
    {
        public static void RunSnippet()
        {
            var tps = new int[]{
                0x0101, 0x0101, 0x0101,
                0x0102, 0x0103, 0x0104,
                0x0105, 0x0106, 0x0107,
                0x0108, 0x0108,
                0x0109, 0x0109, 0x0109,
                0x0102, 0x0103, 0x0104,
            };

            var tpcs = tps.GetTPCs();

            System.Diagnostics.Stopwatch w = new System.Diagnostics.Stopwatch();

            w.Start();

            for (int i = 0; i < 1000; i++)
            {
                var results = Calc(tpcs).SortByRank();
            }

            WL(w.ElapsedMilliseconds);

            w.Stop();

            //WL(results.ToString());

            return;

            #region test

            //System.Diagnostics.Stopwatch w = new System.Diagnostics.Stopwatch();

            //w.Start();

            //int c = 0;
            //for (int i = 0; i < 100000; i++)
            //{
            //    var tpcs = Ext.TPs.RandomGet(108, 14).GetTPCs();
            //    //c += tpcs.Count(o => o.C == 4);
            //    var result = tpcs.Get123();
            //    if (result != null) c += result.Length;
            //}
            //WL("{0}:{1}", 100000, c);

            //w.Stop();

            //WL("Elapsed Milliseconds: {0}", w.ElapsedMilliseconds);

            #endregion

        }

        public static List<Result> Calc(TPC[] tpcs)
        {
            var results = new List<Result>();
            if (tpcs == null || tpcs.Length == 0) return results;

            //var get111_results = tpcs.Get111();
            //foreach (var tps in get111_results)
            //{
            //    var groups = new List<Group>();
            //    groups.Add(new Group(tps, CheckTypes.Get111));
            //    var left = tpcs.Remove(tps);
            //    if (left != null && left.Length > 0)
            //        Calc(results, groups, left);
            //    else
            //        results.Add(new Result(groups, left));
            //}
            //var get123_results = tpcs.Get123();
            //foreach (var tps in get123_results)
            //{
            //    var groups = new List<Group>();
            //    groups.Add(new Group(tps, CheckTypes.Get123));
            //    var left = tpcs.Remove(tps);
            //    if (left != null && left.Length > 0)
            //        Calc(results, groups, left);
            //    else
            //        results.Add(new Result(groups, left));
            //}
            var get11_results = tpcs.Get11();
            foreach (var tps in get11_results)
            {
                var groups = new List<Group>();
                groups.Add(new Group(tps, CheckTypes.Get11));
                var left = tpcs.Remove(tps);
                if (left != null && left.Length > 0)
                    Calc(results, groups, left);
                else
                    results.Add(new Result(groups, left));
            }

            if (
                //get111_results.Length == 0 && 
                //get123_results.Length == 0 && 
                get11_results.Length == 0
                )
            {
                results.Add(new Result(new List<Group>(), tpcs));
            }

            return results;
        }
        public static void Calc(List<Result> results, List<Group> groups, TPC[] leftTPCs)
        {
            var get111_results = leftTPCs.Get111();
            if (get111_results != null) foreach (var tps in get111_results)
                {
                    var new_groups = new List<Group>(groups);
                    new_groups.Add(new Group(tps, CheckTypes.Get111));

                    new_groups.SortByCT();
                    if (results.CheckExists(new_groups)) return;

                    var left = leftTPCs.Remove(tps);
                    if (left != null && left.Length > 0)
                        Calc(results, new_groups, left);
                    else
                        results.Add(new Result(new_groups, left));
                }
            var get123_results = leftTPCs.Get123();
            if (get123_results != null) foreach (var tps in get123_results)
                {
                    var new_groups = new List<Group>(groups);
                    new_groups.Add(new Group(tps, CheckTypes.Get123));

                    new_groups.SortByCT();
                    if (results.CheckExists(new_groups)) return;

                    var left = leftTPCs.Remove(tps);
                    if (left != null && left.Length > 0)
                        Calc(results, new_groups, left);
                    else
                        results.Add(new Result(new_groups, left));
                }
            //var get11_results = leftTPCs.Get11();
            //if (get11_results != null) foreach (var tps in get11_results)
            //    {
            //        var new_groups = new List<Group>(groups);
            //        new_groups.Add(new Group(tps, CheckTypes.Get11));

            //        new_groups.SortByCT();
            //        if (results.CheckExists(new_groups)) return;

            //        var left = leftTPCs.Remove(tps);
            //        if (left != null && left.Length > 0)
            //            Calc(results, new_groups, left);
            //        else
            //            results.Add(new Result(new_groups, left));
            //    }
            if (
                get111_results.Length == 0 &&
                get123_results.Length == 0// &&
                //get11_results.Length == 0
                )
            {
                results.Add(new Result(new List<Group>(groups), leftTPCs));
                return;
            }
        }


        #region Helper methods

        public static void Main()
        {
            try
            {
                RunSnippet();
            }
            catch (Exception e)
            {
                string error = string.Format("---\nThe following error occurred while executing the snippet:\n{0}\n---", e.ToString());
                Console.WriteLine(error);
            }
            finally
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void WL(object text, params object[] args)
        {
            Console.WriteLine(text.ToString(), args);
        }

        private static void RL()
        {
            Console.ReadLine();
        }

        private static void Break()
        {
            System.Diagnostics.Debugger.Break();
        }

        #endregion
    }

    #region Ext

    #region Class Declare

    public struct TPC
    {
        public int TP;
        public int Count;
    }
    public enum CheckTypes
    {
        Get11,
        Get123,
        Get111,
    }
    public class Group
    {
        public int[] TPs;
        public CheckTypes CheckType;
        public int HashCode;
        public Group(int[] tps, CheckTypes ct)
        {
            this.TPs = tps;
            this.CheckType = ct;
            switch (tps.Length)
            {
                case 1:
                    this.HashCode = tps[0];
                    break;
                case 2:
                    this.HashCode = tps[0] | (tps[1] << 10);
                    break;
                case 3:
                    this.HashCode = tps[0] | (tps[1] << 10) | (tps[2] << 20);
                    break;
            }
        }
    }
    public class Result
    {
        public int Rank;
        public List<Group> Gs;
        public int[] LeftTPs;

        public Result(List<Group> groups, TPC[] left)
        {
            this.Gs = groups;
            this.LeftTPs = left.GetTPs();
            if (groups != null && groups.Count > 0)
            {
                this.Rank = groups.Sum(o => (int)o.CheckType);
            }
            else this.Rank = 0;
            if (left == null || left.Length == 0) this.Rank += 1000;    // const 1000
        }
    }

    #endregion

    public static partial class Ext
    {
        #region True Random ??
        public static int Rnd(int m)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] rndBytes = new byte[4];
            rng.GetBytes(rndBytes);
            int rand = BitConverter.ToInt32(rndBytes, 0);
            return Math.Abs(rand % m);
        }
        #endregion

        #region Convert

        public static int P(this int i)
        {
            return i & 0x000000ff;
        }
        public static int T(this int i)
        {
            return (i & 0x0000ff00) >> 8;
        }
        public static int TP(this int i)
        {
            return i & 0x0000ffff;
        }
        //public static int C(this int i)
        //{
        //    return (i & 0x00ff0000) >> 16;
        //}
        public static string ToHexString(this int i)
        {
            return "" + i.ToString("x3");
        }
        public static int NewTP(int t, int p)
        {
            return t << 8 | p;
        }
        //public static int NewTPC(int tp, int c)
        //{
        //    return tp | (c << 16);
        //}

        #endregion

        #region TPs Declare
        public static int[] TPs = new int[] {
            0x0101, 0x0102, 0x0103, 0x0104, 0x0105, 0x0106, 0x0107, 0x0108, 0x0109,
            0x0101, 0x0102, 0x0103, 0x0104, 0x0105, 0x0106, 0x0107, 0x0108, 0x0109,
            0x0101, 0x0102, 0x0103, 0x0104, 0x0105, 0x0106, 0x0107, 0x0108, 0x0109,
            0x0101, 0x0102, 0x0103, 0x0104, 0x0105, 0x0106, 0x0107, 0x0108, 0x0109,

            0x0201, 0x0202, 0x0203, 0x0204, 0x0205, 0x0206, 0x0207, 0x0208, 0x0209,
            0x0201, 0x0202, 0x0203, 0x0204, 0x0205, 0x0206, 0x0207, 0x0208, 0x0209,
            0x0201, 0x0202, 0x0203, 0x0204, 0x0205, 0x0206, 0x0207, 0x0208, 0x0209,
            0x0201, 0x0202, 0x0203, 0x0204, 0x0205, 0x0206, 0x0207, 0x0208, 0x0209,

            0x0301, 0x0302, 0x0303, 0x0304, 0x0305, 0x0306, 0x0307, 0x0308, 0x0309,
            0x0301, 0x0302, 0x0303, 0x0304, 0x0305, 0x0306, 0x0307, 0x0308, 0x0309,
            0x0301, 0x0302, 0x0303, 0x0304, 0x0305, 0x0306, 0x0307, 0x0308, 0x0309,
            0x0301, 0x0302, 0x0303, 0x0304, 0x0305, 0x0306, 0x0307, 0x0308, 0x0309,

            0x0401, 0x0402, 0x0403,
            0x0401, 0x0402, 0x0403,
            0x0401, 0x0402, 0x0403,
            0x0401, 0x0402, 0x0403,

            0x0501, 0x0502, 0x0503, 0x0504,
            0x0501, 0x0502, 0x0503, 0x0504,
            0x0501, 0x0502, 0x0503, 0x0504,
            0x0501, 0x0502, 0x0503, 0x0504,

            0x0601, 0x0602, 0x0603, 0x0604,
            0x0701, 0x0702, 0x0703, 0x0704,
        };
        #endregion

        #region Get Methods
        /// <summary>
        /// 随到的 idx 的内容赋予数组后，用最后单元的值覆盖。
        /// </summary>
        public static int[] RandomGet(this int[] _tps, int max, int c)
        {
            var tps = new int[max];
            Array.Copy(_tps, 0, tps, 0, max);
            var result = new int[c];
            for (int idx = 0; idx < c; idx++)
            {
                var rnd_idx = Rnd(max - idx);
                result[idx] = tps[rnd_idx];
                tps[rnd_idx] = tps[max - 1 - idx];
            }
            Array.Sort<int>(result);
            return result;
        }

        public static TPC[] GetTPCs(this int[] tps)
        {
            return (from tp in tps
                    group tp by tp into g
                    select new TPC { TP = g.Key, Count = g.Count() }
                    ).ToArray();
        }

        public static int[] GetTPs(this TPC[] tpcs)
        {
            var result = new List<int>();
            foreach (var tpc in tpcs)
                for (int i = 0; i < tpc.Count; i++)
                    result.Add(tpc.TP);
            return result.ToArray();
        }

        #endregion

        #region Scan Methods

        public static int[][] Get123(this TPC[] tpcs)
        {
            var maxCount = tpcs.Length - 2;
            if (maxCount <= 0) return new int[0][];
            var result = new int[maxCount][];
            int idx = 0;
            for (int i = 0; i < maxCount; i++)
            {
                if (tpcs[i].TP + 2 == tpcs[i + 2].TP && tpcs[i].TP + 1 == tpcs[i + 1].TP)
                    result[idx++] = new int[] { tpcs[i].TP, tpcs[i + 1].TP, tpcs[i + 2].TP };
            }
            if (idx < maxCount) Array.Resize<int[]>(ref result, idx);
            if (idx == 0) return new int[0][];
            return result;
        }

        public static int[][] Get111(this TPC[] tpcs)
        {
            return (from kv in tpcs where kv.Count >= 3 select new int[] { kv.TP, kv.TP, kv.TP }).ToArray();
        }

        public static int[][] Get11(this TPC[] tpcs)
        {
            return (from kv in tpcs where kv.Count >= 2 select new int[] { kv.TP, kv.TP }).ToArray();
        }

        public static TPC[] Remove(this TPC[] tpcs, int[] tps)
        {
            var tmp = tpcs.ToList();
            foreach (var tp in tps)
            {
                for (int i = 0; i < tmp.Count; i++)
                {
                    var tpc = tmp[i];
                    if (tpc.TP == tp)
                    {
                        if (tpc.Count == 1) tmp.Remove(tpc);
                        else
                        {
                            tpc.Count--;
                            tmp[i] = tpc;
                        }
                        break;
                    }
                }

            };
            return tmp.ToArray();
        }

        #endregion

        #region Sort Methods

        public static List<Group> SortByCT(this List<Group> groups)
        {
            groups.Sort(new Comparison<Group>((a, b) =>
            {
                if (a.CheckType == b.CheckType)
                    return a.TPs[0].CompareTo(b.TPs[0]);
                return a.CheckType.CompareTo(b.CheckType);
            }));
            return groups;
        }

        public static List<Result> SortByRank(this List<Result> results)
        {
            results.Sort(new Comparison<Result>((b, a) =>
            {
                if (a.Rank == b.Rank)
                    if (a.Gs.Count == b.Gs.Count)
                        return b.LeftTPs.Length.CompareTo(a.LeftTPs.Length);
                    else return a.Gs.Count.CompareTo(b.Gs.Count);
                else return a.Rank.CompareTo(b.Rank);
            }));
            return results;
        }

        #endregion

        #region CheckExists Methods

        public static bool CheckExists(this List<Result> results, List<Group> groups)
        {
            int count = groups.Count, idx;
            foreach (var result in results)
            {
                var gs = result.Gs;
                if (gs.Count < count) continue;
                idx = 0;
                for (idx = 0; idx < count; idx++)
                    if (gs[idx].HashCode != groups[idx].HashCode) break;
                if (idx == count) return true;
            }
            return false;
        }

        #endregion

        #region Dump

        public static int[] Dump(this int[] tps, string text)
        {
            Console.WriteLine(text);
            return Dump(tps);
        }
        public static int[] Dump(this int[] tps)
        {
            for (int i = 0; i < tps.Length; i++)
                Console.Write((i > 0 ? ", " : "") + tps[i].ToHexString());
            Console.WriteLine();
            return tps;
        }

        public static int[][] Dump(this int[][] results, string text)
        {
            Console.WriteLine(text);
            return Dump(results);
        }
        public static int[][] Dump(this int[][] results)
        {
            for (int i = 0; i < results.Length; i++)
            {
                for (int j = 0; j < results[i].Length; j++)
                    Console.Write((j > 0 ? ", " : "") + results[i][j].ToHexString());
                Console.WriteLine();
            }
            return results;
        }

        public static TPC[] Dump(this TPC[] tpcs, string text)
        {
            Console.WriteLine(text);
            return Dump(tpcs);
        }
        public static TPC[] Dump(this TPC[] tpcs)
        {
            for (int i = 0; i < tpcs.Length; i++)
                Console.Write((i > 0 ? ", " : "") + tpcs[i].TP.ToHexString() + "x" + tpcs[i].Count.ToString());
            Console.WriteLine();
            return tpcs;
        }
        #endregion
    }
    #endregion
}
