﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLFightTheLandLord
{
    /// <summary>
    /// 扑克牌的值
    /// </summary>
    public enum PokerNum
    {
        P3 = 3,
        P4 = 4,
        P5 = 5,
        P6 = 6,
        P7 = 7,
        P8 = 8,
        P9 = 9,
        P10 = 10,
        J = 11,
        Q = 12,
        K = 13,
        A = 14,
        P2 = 15,
        小王 = 16,
        大王 = 17,
    }
    /// <summary>
    /// 扑克牌的花色
    /// </summary>
    public enum PokerColor
    {
        黑桃 = 4,
        红心 = 3,
        梅花 = 2,
        方块 = 1,
    }

    /// <summary>
    /// 扑克牌的类型,转换为Int后代表该类型的牌组张数
    /// </summary>
    public enum PokerGroupType
    {
        //需要修改枚举类型的值以区别各种牌.
        单张 = 1,
        对子 = 2,
        双王 = 3,
        三张相同 = 4,
        三带一 = 5,
        炸弹 = 6,
        五张顺子 = 7,
        六张顺子 = 8,
        三连对 = 9,
        四带二 = 10,
        二连飞机 = 11,
        七张顺子 = 12,
        四连对 = 13,
        八张顺子 = 14,
        飞机带翅膀 = 15,
        九张顺子 = 16,
        三连飞机 = 17,
        五连对 = 18,
        十张顺子 = 19,
        十一张顺子 = 20,
        十二张顺子 = 21,
        四连飞机 = 22,
        三连飞机带翅膀 = 23,
        六连对 = 24,
        //没有13
        七连对 = 25,
        五连飞机 = 26,
        八连对 = 27,
        四连飞机带翅膀 = 28,
        //没有17
        九连对 = 29,
        六连飞机 = 30,
        //没有19
        十连对 = 31,
        五连飞机带翅膀 = 32



        //单张 = 1,
        //对子 = 2,
        //双王 = 2,
        //三张相同 = 3,
        //三带一 = 4,
        //炸弹 = 4,
        //五张顺子 = 5,
        //六张顺子 = 6,
        //三连对 = 6,
        //四带二 = 6,
        //二连飞机 = 6,
        //七张顺子 = 7,
        //四连对 = 8,
        //八张顺子 = 8,
        //飞机带翅膀 = 8,
        //九张顺子 = 9,
        //三连飞机 = 9,
        //五连对 = 10,
        //十张顺子 = 10,
        //十一张顺子 = 11,
        //十二张顺子 = 12,
        //四连飞机 = 12,
        //三连飞机带翅膀 = 12,
        //六连对 = 12,
        ////没有13
        //七连对 = 14,
        //五连飞机 = 15,
        //八连对 = 16,
        //四连飞机带翅膀 = 16,
        ////没有17
        //九连对 = 18,
        //六连飞机 = 18,
        ////没有19
        //十连对 = 20,
        //五连飞机带翅膀 = 20
    }
}
