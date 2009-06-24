using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ_DDZServer
{
    public class Poker
    {
        /// <summary>
        /// 扑克牌的值
        /// </summary>
        private PokerNum _pokerNum;
        /// <summary>
        /// 扑克牌的花色
        /// </summary>
        private PokerColor _pokerColor;

        /// <summary>
        /// 扑克牌的值
        /// </summary>
        public PokerNum pokerNum
        {
            get
            {
                return this._pokerNum;
            }
            set
            {
                this._pokerNum = value;
            }
        }

        /// <summary>
        /// 扑克牌的花色
        /// </summary>
        public PokerColor pokerColor
        {
            get
            {
                return this._pokerColor;
            }
            set
            {
                this._pokerColor = value;
            }
        }
        /// <summary>
        /// Poker构造方法
        /// </summary>
        /// <param name="pokerNum">Poker点数</param>
        /// <param name="pokerColor">Poker花色</param>
        public Poker(PokerNum pokerNum, PokerColor pokerColor)
        {
            this.pokerNum = pokerNum;
            this.pokerColor = pokerColor;
        }

        public static bool operator ==(Poker LP, Poker RP)
        {
            if ((object)LP != null && (object)RP != null)
            {
                if (LP.pokerNum == RP.pokerNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((object)LP == null && (object)RP != null)
                {
                    return false;
                }
                else
                {
                    if ((object)LP != null && (object)RP == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        public static bool operator ==(Poker LP, PokerNum RP)
        {
            if ((object)LP != null)
            {
                if (LP.pokerNum == RP)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Poker LP, PokerNum RP)
        {
            return !(LP.pokerNum == RP);
        }
        public static bool operator !=(Poker LP, Poker RP)
        {
            return !(LP == RP);
        }
        public static bool operator >(Poker LP, Poker RP)
        {
            if ((object)LP != null && (object)RP != null)
            {
                if (LP.pokerNum > RP.pokerNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static bool operator <(Poker LP, Poker RP)
        {
            if (RP > LP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static class DConsole
    {
        /// <summary>
        /// 已出牌组集合
        /// </summary>
        List<KeyValuePair<int, PokerGroup>> OutPokerGroups = new List<KeyValuePair<int, PokerGroup>>();
        /// <summary>
        /// 牌组是否有效
        /// </summary>
        /// <returns>bool值</returns>
        public static bool Isavailable()
        {
            //todo 验证出牌合法性
            return true;
        }
    }

    public class PokerGroup : List<Poker>
    {
        /// <summary>
        /// 牌组的类型
        /// </summary>
        public PokerGroupType type;

        /// <summary>
        /// 序列化一个PokerGroup对象,返回一个byte数组
        /// </summary>
        /// <returns></returns>
        public byte[] GetBuffer()
        {
            byte[] bytePoker = new byte[this.Count * 2];
            int i = 0;
            foreach (Poker onepoker in this)
            {
                switch (onepoker.pokerColor)
                {
                    case PokerColor.黑桃:
                        switch (onepoker.pokerNum)
                        {
                            case PokerNum.P3:
                                bytePoker[i] = Convert.ToByte('3');
                                break;
                            case PokerNum.P4:
                                bytePoker[i] = Convert.ToByte('4');
                                break;
                            case PokerNum.P5:
                                bytePoker[i] = Convert.ToByte('5');
                                break;
                            case PokerNum.P6:
                                bytePoker[i] = Convert.ToByte('6');
                                break;
                            case PokerNum.P7:
                                bytePoker[i] = Convert.ToByte('7');
                                break;
                            case PokerNum.P8:
                                bytePoker[i] = Convert.ToByte('8');
                                break;
                            case PokerNum.P9:
                                bytePoker[i] = Convert.ToByte('9');
                                break;
                            case PokerNum.P10:
                                bytePoker[i] = Convert.ToByte('0');
                                break;
                            case PokerNum.J:
                                bytePoker[i] = Convert.ToByte('J');
                                break;
                            case PokerNum.Q:
                                bytePoker[i] = Convert.ToByte('Q');
                                break;
                            case PokerNum.K:
                                bytePoker[i] = Convert.ToByte('K');
                                break;
                            case PokerNum.A:
                                bytePoker[i] = Convert.ToByte('A');
                                break;
                            case PokerNum.P2:
                                bytePoker[i] = Convert.ToByte('2');
                                break;
                            case PokerNum.小王:
                                bytePoker[i] = Convert.ToByte('X');
                                break;
                            case PokerNum.大王:
                                bytePoker[i] = Convert.ToByte('D');
                                break;
                        }
                        bytePoker[i + 1] = Convert.ToByte('a');
                        break;
                    case PokerColor.红心:
                        switch (onepoker.pokerNum)
                        {
                            case PokerNum.P3:
                                bytePoker[i] = Convert.ToByte('3');
                                break;
                            case PokerNum.P4:
                                bytePoker[i] = Convert.ToByte('4');
                                break;
                            case PokerNum.P5:
                                bytePoker[i] = Convert.ToByte('5');
                                break;
                            case PokerNum.P6:
                                bytePoker[i] = Convert.ToByte('6');
                                break;
                            case PokerNum.P7:
                                bytePoker[i] = Convert.ToByte('7');
                                break;
                            case PokerNum.P8:
                                bytePoker[i] = Convert.ToByte('8');
                                break;
                            case PokerNum.P9:
                                bytePoker[i] = Convert.ToByte('9');
                                break;
                            case PokerNum.P10:
                                bytePoker[i] = Convert.ToByte('0');
                                break;
                            case PokerNum.J:
                                bytePoker[i] = Convert.ToByte('J');
                                break;
                            case PokerNum.Q:
                                bytePoker[i] = Convert.ToByte('Q');
                                break;
                            case PokerNum.K:
                                bytePoker[i] = Convert.ToByte('K');
                                break;
                            case PokerNum.A:
                                bytePoker[i] = Convert.ToByte('A');
                                break;
                            case PokerNum.P2:
                                bytePoker[i] = Convert.ToByte('2');
                                break;
                            case PokerNum.小王:
                                bytePoker[i] = Convert.ToByte('X');
                                break;
                            case PokerNum.大王:
                                bytePoker[i] = Convert.ToByte('D');
                                break;
                        }
                        bytePoker[i + 1] = Convert.ToByte('b');
                        break;
                    case PokerColor.梅花:
                        switch (onepoker.pokerNum)
                        {
                            case PokerNum.P3:
                                bytePoker[i] = Convert.ToByte('3');
                                break;
                            case PokerNum.P4:
                                bytePoker[i] = Convert.ToByte('4');
                                break;
                            case PokerNum.P5:
                                bytePoker[i] = Convert.ToByte('5');
                                break;
                            case PokerNum.P6:
                                bytePoker[i] = Convert.ToByte('6');
                                break;
                            case PokerNum.P7:
                                bytePoker[i] = Convert.ToByte('7');
                                break;
                            case PokerNum.P8:
                                bytePoker[i] = Convert.ToByte('8');
                                break;
                            case PokerNum.P9:
                                bytePoker[i] = Convert.ToByte('9');
                                break;
                            case PokerNum.P10:
                                bytePoker[i] = Convert.ToByte('0');
                                break;
                            case PokerNum.J:
                                bytePoker[i] = Convert.ToByte('J');
                                break;
                            case PokerNum.Q:
                                bytePoker[i] = Convert.ToByte('Q');
                                break;
                            case PokerNum.K:
                                bytePoker[i] = Convert.ToByte('K');
                                break;
                            case PokerNum.A:
                                bytePoker[i] = Convert.ToByte('A');
                                break;
                            case PokerNum.P2:
                                bytePoker[i] = Convert.ToByte('2');
                                break;
                            case PokerNum.小王:
                                bytePoker[i] = Convert.ToByte('X');
                                break;
                            case PokerNum.大王:
                                bytePoker[i] = Convert.ToByte('D');
                                break;
                        }
                        bytePoker[i + 1] = Convert.ToByte('c');
                        break;
                    case PokerColor.方块:
                        switch (onepoker.pokerNum)
                        {
                            case PokerNum.P3:
                                bytePoker[i] = Convert.ToByte('3');
                                break;
                            case PokerNum.P4:
                                bytePoker[i] = Convert.ToByte('4');
                                break;
                            case PokerNum.P5:
                                bytePoker[i] = Convert.ToByte('5');
                                break;
                            case PokerNum.P6:
                                bytePoker[i] = Convert.ToByte('6');
                                break;
                            case PokerNum.P7:
                                bytePoker[i] = Convert.ToByte('7');
                                break;
                            case PokerNum.P8:
                                bytePoker[i] = Convert.ToByte('8');
                                break;
                            case PokerNum.P9:
                                bytePoker[i] = Convert.ToByte('9');
                                break;
                            case PokerNum.P10:
                                bytePoker[i] = Convert.ToByte('0');
                                break;
                            case PokerNum.J:
                                bytePoker[i] = Convert.ToByte('J');
                                break;
                            case PokerNum.Q:
                                bytePoker[i] = Convert.ToByte('Q');
                                break;
                            case PokerNum.K:
                                bytePoker[i] = Convert.ToByte('K');
                                break;
                            case PokerNum.A:
                                bytePoker[i] = Convert.ToByte('A');
                                break;
                            case PokerNum.P2:
                                bytePoker[i] = Convert.ToByte('2');
                                break;
                            case PokerNum.小王:
                                bytePoker[i] = Convert.ToByte('X');
                                break;
                            case PokerNum.大王:
                                bytePoker[i] = Convert.ToByte('D');
                                break;
                        }
                        bytePoker[i + 1] = Convert.ToByte('d');
                        break;
                }
                i += 2;
            }
            return bytePoker;
        }

        public PokerGroup(byte[] bytePokers)
        {
            this.GetPokerGroup(bytePokers);
        }
        public PokerGroup()
        {
        }
        /// <summary>
        /// 通过一个byte[]反序列化为PokerGroup对象
        /// </summary>
        /// <param name="bytePokers"></param>
        public void GetPokerGroup(byte[] bytePokers)
        {
            for (int i = 0; i < bytePokers.Length - 1; i += 2)
            {
                switch (Convert.ToChar((bytePokers[i + 1])))
                {
                    case 'a':
                        switch (Convert.ToChar((bytePokers[i])))
                        {
                            case '3':
                                this.Add(new Poker(PokerNum.P3, PokerColor.黑桃));
                                break;
                            case '4':
                                this.Add(new Poker(PokerNum.P4, PokerColor.黑桃));
                                break;
                            case '5':
                                this.Add(new Poker(PokerNum.P5, PokerColor.黑桃));
                                break;
                            case '6':
                                this.Add(new Poker(PokerNum.P6, PokerColor.黑桃));
                                break;
                            case '7':
                                this.Add(new Poker(PokerNum.P7, PokerColor.黑桃));
                                break;
                            case '8':
                                this.Add(new Poker(PokerNum.P8, PokerColor.黑桃));
                                break;
                            case '9':
                                this.Add(new Poker(PokerNum.P9, PokerColor.黑桃));
                                break;
                            case '0':
                                this.Add(new Poker(PokerNum.P10, PokerColor.黑桃));
                                break;
                            case 'J':
                                this.Add(new Poker(PokerNum.J, PokerColor.黑桃));
                                break;
                            case 'Q':
                                this.Add(new Poker(PokerNum.Q, PokerColor.黑桃));
                                break;
                            case 'K':
                                this.Add(new Poker(PokerNum.K, PokerColor.黑桃));
                                break;
                            case 'A':
                                this.Add(new Poker(PokerNum.A, PokerColor.黑桃));
                                break;
                            case '2':
                                this.Add(new Poker(PokerNum.P2, PokerColor.黑桃));
                                break;
                            case 'X':
                                this.Add(new Poker(PokerNum.小王, PokerColor.黑桃));
                                break;
                            case 'D':
                                this.Add(new Poker(PokerNum.大王, PokerColor.黑桃));
                                break;
                        }
                        break;
                    case 'b':
                        switch (Convert.ToChar((bytePokers[i])))
                        {
                            case '3':
                                this.Add(new Poker(PokerNum.P3, PokerColor.红心));
                                break;
                            case '4':
                                this.Add(new Poker(PokerNum.P4, PokerColor.红心));
                                break;
                            case '5':
                                this.Add(new Poker(PokerNum.P5, PokerColor.红心));
                                break;
                            case '6':
                                this.Add(new Poker(PokerNum.P6, PokerColor.红心));
                                break;
                            case '7':
                                this.Add(new Poker(PokerNum.P7, PokerColor.红心));
                                break;
                            case '8':
                                this.Add(new Poker(PokerNum.P8, PokerColor.红心));
                                break;
                            case '9':
                                this.Add(new Poker(PokerNum.P9, PokerColor.红心));
                                break;
                            case '0':
                                this.Add(new Poker(PokerNum.P10, PokerColor.红心));
                                break;
                            case 'J':
                                this.Add(new Poker(PokerNum.J, PokerColor.红心));
                                break;
                            case 'Q':
                                this.Add(new Poker(PokerNum.Q, PokerColor.红心));
                                break;
                            case 'K':
                                this.Add(new Poker(PokerNum.K, PokerColor.红心));
                                break;
                            case 'A':
                                this.Add(new Poker(PokerNum.A, PokerColor.红心));
                                break;
                            case '2':
                                this.Add(new Poker(PokerNum.P2, PokerColor.红心));
                                break;
                            case 'X':
                                this.Add(new Poker(PokerNum.小王, PokerColor.红心));
                                break;
                            case 'D':
                                this.Add(new Poker(PokerNum.大王, PokerColor.红心));
                                break;
                        }
                        break;
                    case 'c':
                        switch (Convert.ToChar((bytePokers[i])))
                        {
                            case '3':
                                this.Add(new Poker(PokerNum.P3, PokerColor.梅花));
                                break;
                            case '4':
                                this.Add(new Poker(PokerNum.P4, PokerColor.梅花));
                                break;
                            case '5':
                                this.Add(new Poker(PokerNum.P5, PokerColor.梅花));
                                break;
                            case '6':
                                this.Add(new Poker(PokerNum.P6, PokerColor.梅花));
                                break;
                            case '7':
                                this.Add(new Poker(PokerNum.P7, PokerColor.梅花));
                                break;
                            case '8':
                                this.Add(new Poker(PokerNum.P8, PokerColor.梅花));
                                break;
                            case '9':
                                this.Add(new Poker(PokerNum.P9, PokerColor.梅花));
                                break;
                            case '0':
                                this.Add(new Poker(PokerNum.P10, PokerColor.梅花));
                                break;
                            case 'J':
                                this.Add(new Poker(PokerNum.J, PokerColor.梅花));
                                break;
                            case 'Q':
                                this.Add(new Poker(PokerNum.Q, PokerColor.梅花));
                                break;
                            case 'K':
                                this.Add(new Poker(PokerNum.K, PokerColor.梅花));
                                break;
                            case 'A':
                                this.Add(new Poker(PokerNum.A, PokerColor.梅花));
                                break;
                            case '2':
                                this.Add(new Poker(PokerNum.P2, PokerColor.梅花));
                                break;
                            case 'X':
                                this.Add(new Poker(PokerNum.小王, PokerColor.梅花));
                                break;
                            case 'D':
                                this.Add(new Poker(PokerNum.大王, PokerColor.梅花));
                                break;
                        }
                        break;
                    case 'd':
                        switch (Convert.ToChar((bytePokers[i])))
                        {
                            case '3':
                                this.Add(new Poker(PokerNum.P3, PokerColor.方块));
                                break;
                            case '4':
                                this.Add(new Poker(PokerNum.P4, PokerColor.方块));
                                break;
                            case '5':
                                this.Add(new Poker(PokerNum.P5, PokerColor.方块));
                                break;
                            case '6':
                                this.Add(new Poker(PokerNum.P6, PokerColor.方块));
                                break;
                            case '7':
                                this.Add(new Poker(PokerNum.P7, PokerColor.方块));
                                break;
                            case '8':
                                this.Add(new Poker(PokerNum.P8, PokerColor.方块));
                                break;
                            case '9':
                                this.Add(new Poker(PokerNum.P9, PokerColor.方块));
                                break;
                            case '0':
                                this.Add(new Poker(PokerNum.P10, PokerColor.方块));
                                break;
                            case 'J':
                                this.Add(new Poker(PokerNum.J, PokerColor.方块));
                                break;
                            case 'Q':
                                this.Add(new Poker(PokerNum.Q, PokerColor.方块));
                                break;
                            case 'K':
                                this.Add(new Poker(PokerNum.K, PokerColor.方块));
                                break;
                            case 'A':
                                this.Add(new Poker(PokerNum.A, PokerColor.方块));
                                break;
                            case '2':
                                this.Add(new Poker(PokerNum.P2, PokerColor.方块));
                                break;
                            case 'X':
                                this.Add(new Poker(PokerNum.小王, PokerColor.方块));
                                break;
                            case 'D':
                                this.Add(new Poker(PokerNum.大王, PokerColor.方块));
                                break;
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 重写"大于"运算符
        /// </summary>
        /// <param name="LP">左边的PokerGroup对象</param>
        /// <param name="RP">右边的PokerGroup对象</param>
        /// <returns></returns>
        public static bool operator >(PokerGroup LP, PokerGroup RP)
        {
            bool IsGreater = false;
            if (LP.type != RP.type && LP.type != PokerGroupType.炸弹 && LP.type != PokerGroupType.双王)
            {
                IsGreater = false;
            }
            else
            {
                if (LP.type == PokerGroupType.炸弹 && RP.type == PokerGroupType.炸弹) //LPRP都为炸弹
                {
                    if (LP[0] > RP[0]) //比较大小
                    {
                        IsGreater = true;
                    }
                    else
                    {
                        IsGreater = false;
                    }
                }
                else
                {
                    if (LP.type == PokerGroupType.炸弹) //只有LP为炸弹
                    {
                        IsGreater = true;
                    }
                    else
                    {
                        if (LP.type == PokerGroupType.双王) //LP为双王
                        {
                            IsGreater = true;
                        }
                        else
                        {
                            if (LP[0] > RP[0]) //LP为普通牌组
                            {
                                IsGreater = true;
                            }
                            else
                            {
                                IsGreater = false;
                            }
                        }
                    }
                }
            }
            return IsGreater;
        }
        public static bool operator <(PokerGroup LP, PokerGroup RP)
        {
            return (RP > LP);
        }
    }

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

