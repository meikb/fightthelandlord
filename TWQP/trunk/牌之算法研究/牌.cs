using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

/// <summary>
/// 表示一张牌（麻将，扑克）（由高到低：状态, 张数，花色，点数，每个占 1 byte）
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 4, CharSet = CharSet.Ansi)]
public struct 牌
{
    /// <summary>
    /// UInt32 类型，包含牌的　状态, 张数，花色，点数　数据
    /// </summary>
    [FieldOffset(0)]
    public uint 数据;
    /// <summary>
    /// UInt16 类型，包含牌的　花色，点数　数据
    /// </summary>
    [FieldOffset(0)]
    public ushort 花点;
    /// <summary>
    /// Byte 类型，包含牌的　状态　数据
    /// </summary>
    [FieldOffset(3)]
    public byte 态;
    /// <summary>
    /// Byte 类型，包含牌的　张数　数据
    /// </summary>
    [FieldOffset(2)]
    public byte 张;
    /// <summary>
    /// Byte 类型，包含牌的　花色　数据
    /// </summary>
    [FieldOffset(1)]
    public byte 花;
    /// <summary>
    /// Byte 类型，包含牌的　点数　数据
    /// </summary>
    [FieldOffset(0)]
    public byte 点;
}

public static class ExtendMethods
{

    /// <summary>
    /// 将多张的计数牌数组转为单张牌数组（Resize）
    /// </summary>
    /// <param name="ps">目标数组</param>
    public static 牌[] 转为单张序列(this 牌[] ps)
    {
        var result = 获取单张序列(ps);
        Array.Resize<牌>(ref ps, result.Length);
        Array.Copy(result, ps, result.Length);
        return ps;
    }

    /// <summary>
    /// 返回 将多张的计数牌数组 转为的 单张牌数组
    /// </summary>
    /// <param name="ps">目标数组</param>
    /// <returns>单张牌数组</returns>
    public static 牌[] 获取单张序列(this IEnumerable<牌> ps)
    {
        var tmp = new List<牌>();
        foreach (var p in ps)
        {
            for (int i = 0; i < p.张; i++)
            {
                tmp.Add(new 牌 { 花点 = p.花点, 张 = 1 });
            }
        }
        return tmp.ToArray();
    }


    /// <summary>
    /// 按花色，点数，从小到大排列元素，统计并 Resize 数组本身
    /// </summary>
    /// <param name="ps">目标数组</param>
    public static 牌[] 转为计数牌序列(this 牌[] ps)
    {
        int lastIdx = ps.Length - 1;
        牌 temp;
        // 对比是否有重复并计数，移动到最后
        for (int i = 0; i < lastIdx; i++)
        {
            ps[i].张 = 1;
            for (int j = i + 1; j <= lastIdx; j++)
            {
                if (ps[i].花点 == ps[j].花点)
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
        Array.Sort<牌>(ps, (p1, p2) => { return p1.花点.CompareTo(p2.花点); });
        return ps;
    }


    /// <summary>
    /// 按花色，点数，从小到大排列元素，返回统计结果数据
    /// </summary>
    /// <param name="ps">目标数组</param>
    /// <returns>计数牌数组</returns>
    public static 牌[] 获取计数牌序列(this IEnumerable<牌> ps)
    {
        var result = from p in ps
                     group p by p.花点 into g
                     orderby g.Key
                     select new 牌 { 花点 = g.Key, 张 = (byte)g.Count() };
        return result.ToArray();
    }




    /// <summary>
    /// 从一个牌数组中 减去 另一个牌数组 并返回剩下的牌（表现为 张 变化，结果不含 张 为 0 的）
    /// 要求：传入的牌数组是经过由小到大排序的
    /// </summary>
    public static 牌[] 移走牌数组(this 牌[] source, 牌[] target)
    {
        // 原理：先遍历 source 和 target 中第一张牌匹配，同时递增判断下一张。如果匹配，继续递增判断。如果不匹配，继续在 source 中找。
        // 特殊处理：如果匹配牌的 张 数相减之后为零，则将 source 当前单元后面所有单元的数据，前移1并覆盖掉当前单元

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
                else
                {
                    sIdx++;
                }
                tIdx++;
                continue;
            }
            else
            {
                sIdx++;
                continue;
            }
        }
        if (sIdx == sCount) throw new Exception("source 中没有足够的牌做减法");
        Array.Resize<牌>(ref source, sCount);
        return source;
    }

    /// <summary>
    /// 按花点从小到大排列数组
    /// </summary>
    public static 牌[] 按花点排序(this 牌[] ps)
    {
        Array.Sort<牌>(ps, new Comparison<牌>((a, b) => { return a.花点.CompareTo(b.花点); }));
        return ps;
    }








    /// <summary>
    /// 从一个牌数组中 减去 另一个牌数组 并返回剩下的牌（表现为 张 变化，结果不含 张 为 0 的）
    /// </summary>
    /// <param name="Source">被减的牌组</param>
    /// <param name="Target">减去的牌组</param>
    /// <returns>剩下的牌</returns>
    public static 牌[] Remove(this 牌[] Source, 牌[] Target)
    {
        var singleSource = Source.转为单张序列();
        var singleTarget = Target.转为单张序列();
        var Result = new List<牌>();
        for (int i = 0; i < singleSource.Length; i++)
        {
            bool IsSame = false;
            for (int j = 0; j < singleTarget.Length; j++)
            {
                if (singleSource[i].花点 == singleTarget[j].花点)
                {
                    IsSame = true;
                    break;
                }
                else
                {
                    IsSame = false;
                }
            }
            if (!IsSame)
            {
                Result.Add(singleSource[i]);
            }
        }
        return Result.ToArray().转为计数牌序列();
    }
}