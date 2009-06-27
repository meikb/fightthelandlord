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
}
