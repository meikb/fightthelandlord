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
    public uint 整个;
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
}