using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace ZBWZ_DDZ
{
    public class StateHandler:IWatingJoin,IWatingReady
    {

        #region IWatingReady 成员

        public bool EveryOneIsReady(Dictionary<int, DDZCharacter> players)
        {
            var ReadyPlayer = 0;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.clientState == DDZClientStates.已准备)
                {
                    ReadyPlayer++;
                }
                else
                {
                    return false;
                }
            }
            if (ReadyPlayer == AmountPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region IWatingJoin 成员

        public int AmountPlayer { get; set; }

        public bool CanIJoinIt(int Amount)
        {
            if (Amount < AmountPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool JoinSuccess(Dictionary<int, DDZCharacter> players)
        {
            var joinSuccessPlayer = 0;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.clientState == DDZClientStates.已进入 || onePlayer.Value.clientState == DDZClientStates.已准备)
                {
                    joinSuccessPlayer++;
                }
                else
                {
                    return false;
                }
            }
            if (joinSuccessPlayer == AmountPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }

    [Serializable]
    public class Character : OO.User_Character
    {
        public long 超时_进入超时;
        public long 超时_准备超时;
        public long 超时_投掷超时;
        public int 获胜次数;
        public int Num;
        public int DestTopID;
        public int ProxyID;
    }

    [Serializable]
    public class DDZCharacter : Character
    {  
        /// <summary>
        /// 玩家状态
        /// </summary>
        public DDZClientStates clientState { get; set; }
        /// <summary>
        /// 出牌超时时间
        /// </summary>
        public long 超时_出牌超时 { get; set; }
        /// <summary>
        /// 初始牌组
        /// </summary>
        public PokerGroup MyPokerGroup { get; set; }
        /// <summary>
        /// 已出牌组
        /// </summary>
        public PokerGroup LastPokerGroup { get; set; }
        /// <summary>
        /// 之前的玩家
        /// </summary>
        public DDZCharacter 前面的玩家 { get; set; }
        /// <summary>
        /// 之后的玩家
        /// </summary>
        public DDZCharacter 后面的玩家 { get; set; }
        /// <summary>
        /// 玩家ID
        /// </summary>
        public int PlayerID { get; set; }
        /// <summary>
        /// 是否是地主
        /// </summary>
        public bool IsTheLandLord { get; set; }
    }


    public class PlayerCollection : Dictionary<int, DDZCharacter>
    {
        public bool IsInit { get; set; }
    }


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
            if (Isavailable(LP) && Isavailable(RP))
            {
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
            }
            return IsGreater;
        }
        /// <summary>
        /// 重写"小于"运算符
        /// </summary>
        /// <param name="LP">左边的PokerGroup对象</param>
        /// <param name="RP">右边的PokerGroup对象</param>
        /// <returns></returns>
        public static bool operator <(PokerGroup LP, PokerGroup RP)
        {
            return (RP > LP);
        }

        /// <summary>
        /// 牌组是否有效
        /// </summary>
        /// <returns>bool值</returns>
        public static bool Isavailable(PokerGroup leadPokers)
        {
            bool isRule = false;
            leadPokers.Sort(ComparePokerByNum);
            switch (leadPokers.Count)
            {
                case 0:
                    isRule = false;
                    break;
                case 1:
                    isRule = true;
                    leadPokers.type = PokerGroupType.单张;
                    break;
                case 2:
                    if (IsSame(leadPokers, 2))
                    {
                        isRule = true;
                        leadPokers.type = PokerGroupType.对子;
                    }
                    else
                    {
                        if (leadPokers[0] == PokerNum.大王 && leadPokers[1] == PokerNum.小王)
                        {
                            leadPokers.type = PokerGroupType.双王;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 3:
                    if (IsSame(leadPokers, 3))
                    {
                        leadPokers.type = PokerGroupType.三张相同;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 4:
                    if (IsSame(leadPokers, 4))
                    {
                        leadPokers.type = PokerGroupType.炸弹;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.三带一;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 5:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.五张顺子;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 6:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.六张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.三连对;
                            isRule = true;
                        }
                        else
                        {
                            if (IsSame(leadPokers, 4))
                            {
                                leadPokers.type = PokerGroupType.四带二;
                                isRule = true;
                            }
                            else
                            {
                                if (IsThreeLinkPokers(leadPokers))
                                {
                                    leadPokers.type = PokerGroupType.二连飞机;
                                    isRule = true;
                                }
                                else
                                {
                                    isRule = false;
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.七张顺子;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 8:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.八张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.四连对;
                            isRule = true;
                        }
                        else
                        {
                            if (IsThreeLinkPokers(leadPokers))
                            {
                                leadPokers.type = PokerGroupType.飞机带翅膀;
                                isRule = true;
                            }
                            else
                            {
                                isRule = false;
                            }
                        }
                    }
                    break;
                case 9:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.九张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.三连飞机;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 10:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.五连对;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 11:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十一张顺子;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 12:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十二张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.六连对;
                            isRule = true;
                        }
                        else
                        {
                            if (IsThreeLinkPokers(leadPokers))
                            {
                                //12有三连飞机带翅膀和四连飞机两种情况,所以在IsThreeLinkPokers中做了特殊处理,此处不用给type赋值.
                                isRule = true;
                            }
                            else
                            {
                                isRule = false;
                            }
                        }
                    }
                    break;
                case 13:
                    isRule = false;
                    break;
                case 14:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.七连对;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 15:
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.五连飞机;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 16:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.八连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.四连飞机带翅膀;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 17:
                    isRule = false;
                    break;
                case 18:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.六连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.六连飞机;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 19:
                    isRule = false;
                    break;
                case 20:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.五连飞机带翅膀;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
            }
            return isRule;
        }

        public static int ComparePokerByNum(Poker p1, Poker p2) //从大到小排序
        {

            if (p1 > p2)
            {
                return -1;
            }
            else
            {
                if (p1 < p2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 判断一个牌组指定数量相邻的牌是否两两相同
        /// </summary>
        /// <param name="PG">牌组对象</param>
        /// <param name="amount">指定数量的相邻牌组</param>
        /// <returns>指定数量的相邻牌是否两两相同</returns>
        public static bool IsSame(PokerGroup PG, int amount)
        {
            bool IsSame1 = false;
            bool IsSame2 = false;
            for (int i = 0; i < amount - 1; i++) //从大到小比较相邻牌是否相同
            {
                if (PG[i] == PG[i + 1])
                {
                    IsSame1 = true;
                }
                else
                {
                    IsSame1 = false;
                    break;
                }
            }
            for (int i = PG.Count - 1; i > PG.Count - amount; i--)  //从小到大比较相邻牌是否相同
            {
                if (PG[i] == PG[i - 1])
                {
                    IsSame2 = true;
                }
                else
                {
                    IsSame2 = false;
                    break;
                }
            }
            if (IsSame1 || IsSame2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断牌组是否为顺子
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为顺子</returns>
        public static bool IsStraight(PokerGroup PG)
        {
            bool IsStraight = false;
            foreach (Poker poker in PG)//不能包含2、小王、大王
            {
                if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
                {
                    IsStraight = false;
                    return IsStraight;
                }
            }
            for (int i = 0; i < PG.Count - 1; i++)
            {
                if (PG[i].pokerNum - 1 == PG[i + 1].pokerNum)
                {
                    IsStraight = true;
                }
                else
                {
                    IsStraight = false;
                    break;
                }
            }
            return IsStraight;
        }
        /// <summary>
        /// 判断牌组是否为连对
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连对</returns>
        public static bool IsLinkPair(PokerGroup PG)
        {
            bool IsLinkPair = false;
            foreach (Poker poker in PG) //不能包含2、小王、大王
            {
                if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
                {
                    IsLinkPair = false;
                    return IsLinkPair;
                }
            }
            for (int i = 0; i < PG.Count - 2; i += 2)  //首先比较是否都为对子，再比较第一个对子的点数-1是否等于第二个对子，最后检察最小的两个是否为对子（这里的for循环无法检测到最小的两个，所以需要拿出来单独检查）
            {
                if (PG[i] == PG[i + 1] && PG[i].pokerNum - 1 == PG[i + 2].pokerNum && PG[i + 2] == PG[i + 3])
                {
                    IsLinkPair = true;
                }
                else
                {
                    IsLinkPair = false;
                    break;
                }
            }
            return IsLinkPair;
        }
        /// <summary>
        /// 判断牌组是否为连续三张牌,飞机,飞机带翅膀
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连续三张牌</returns>
        public static bool IsThreeLinkPokers(PokerGroup PG) //判断三张牌方法为判断两两相邻的牌,如果两两相邻的牌相同,则count自加1.最后根据count的值判断牌的类型为多少个连续三张
        {
            bool IsThreeLinkPokers = false;
            int HowMuchLinkThree = 0;  //飞机的数量
            PG = SameThreeSort(PG); //排序,把飞机放在前面
            for (int i = 2; i < PG.Count; i++)  //得到牌组中有几个飞机
            {
                if (PG[i] == PG[i - 1] && PG[i] == PG[i - 2])
                {
                    HowMuchLinkThree++;
                }
            }
            if (HowMuchLinkThree > 0)  //当牌组里面有三个时
            {
                if (HowMuchLinkThree > 1)  //当牌组为飞机时
                {
                    for (int i = 0; i < HowMuchLinkThree * 3 - 3; i += 3) //判断飞机之间的点数是否相差1
                    {
                        if (PG[i] != PokerNum.P2 && PG[i].pokerNum - 1 == PG[i + 3].pokerNum) //2点不能当飞机出
                        {
                            IsThreeLinkPokers = true;
                        }
                        else
                        {
                            IsThreeLinkPokers = false;
                            break;
                        }
                    }
                }
                else
                {
                    IsThreeLinkPokers = true; //牌组为普通三个,直接返回true
                }
            }
            else
            {
                IsThreeLinkPokers = false;
            }
            if (HowMuchLinkThree == 4)
            {
                PG.type = PokerGroupType.四连飞机;
            }
            if (HowMuchLinkThree == 3 && PG.Count == 12)
            {
                PG.type = PokerGroupType.三连飞机带翅膀;
            }
            return IsThreeLinkPokers;

        }
        /// <summary>
        /// 对飞机和飞机带翅膀进行排序,把飞机放在前面,翅膀放在后面.
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连续三张牌</returns>
        public static PokerGroup SameThreeSort(PokerGroup PG)
        {
            Poker FourPoker = null;  //如果把4张当三张出并且带4张的另外一张,就需要特殊处理,这里记录出现这种情况的牌的点数.
            bool FindedThree = false;  //已找到三张相同的牌
            PokerGroup tempPokerGroup = new PokerGroup();  //记录三张相同的牌
            int count = 0; //记录在连续三张牌前面的翅膀的张数
            int Four = 0; // 记录是否连续出现三三相同,如果出现这种情况则表明出现把4张牌(炸弹)当中的三张和其他牌配成飞机带翅膀,并且翅膀中有炸弹牌的点数.
            // 比如有如下牌组: 998887777666 玩家要出的牌实际上应该为 888777666带997,但是经过从大到小的排序后变成了998887777666 一不美观,二不容易比较.
            for (int i = 2; i < PG.Count; i++)  //直接从2开始循环,因为PG[0],PG[1]的引用已经存储在其他变量中,直接比较即可
            {
                if (PG[i] == PG[i - 2] && PG[i] == PG[i - 1])// 比较PG[i]与PG[i-1],PG[i]与PG[i-2]是否同时相等,如果相等则说明这是三张相同牌
                {
                    if (Four >= 1) //默认的Four为0,所以第一次运行时这里为false,直接执行else
                    //一旦连续出现两个三三相等,就会执行这里的if
                    {
                        FourPoker = PG[i]; //当找到四张牌时,记录下4张牌的点数
                        Poker changePoker;
                        for (int k = i; k > 0; k--) //把四张牌中的一张移动到最前面.
                        {
                            changePoker = PG[k];
                            PG[k] = PG[k - 1];
                            PG[k - 1] = changePoker;
                        }
                        count++; //由于此时已经找到三张牌,下面为count赋值的程序不会执行,所以这里要手动+1
                    }
                    else
                    {
                        Four++; //记录本次循环,因为本次循环找到了三三相等的牌,如果连续两次找到三三相等的牌则说明找到四张牌(炸弹)
                        tempPokerGroup.Add(PG[i]); //把本次循环的PG[i]记录下来,即记录下三张牌的点数
                    }
                    FindedThree = true; //标记已找到三张牌
                }
                else
                {
                    Four = 0; //没有找到时,连续找到三张牌的标志Four归零
                    if (!FindedThree) //只有没有找到三张牌时才让count增加.如果已经找到三张牌,则不再为count赋值.
                    {
                        count = i - 1;
                    }
                }
            }
            foreach (Poker tempPoker in tempPokerGroup)  //迭代所有的三张牌点数
            {
                Poker changePoker;  //临时交换Poker
                for (int i = 0; i < PG.Count; i++)  //把所有的三张牌往前移动
                {
                    if (PG[i] == tempPoker)  //当PG[i]等于三张牌的点数时
                    {
                        if (PG[i] == FourPoker) //由于上面已经把4张牌中的一张放到的最前面,这张牌也会与tempPoker相匹配所以这里进行处理
                        // 当第一次遇到四张牌的点数时,把记录四张牌的FourPoker赋值为null,并中断本次循环.由于FourPoker已经为Null,所以下次再次遇到四张牌的点数时会按照正常情况执行.
                        {
                            FourPoker = null;
                            continue;
                        }
                        changePoker = PG[i - count];
                        PG[i - count] = PG[i];
                        PG[i] = changePoker;
                    }
                }
            }
            return PG;
        }
    }





}
