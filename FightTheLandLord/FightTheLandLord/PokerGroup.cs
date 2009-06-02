using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheLandLord
{
    public class PokerGroup:List<Poker>
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
            byte[] bytePoker = new byte[this.Count * 2 + 1];
            int i = 0;
            foreach (Poker onepoker in this)
            {
                switch (onepoker.pokerColor)
                {
                    case PokerColor.黑桃:
                        switch(onepoker.pokerNum)
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
            //bytePoker[this.Count - 1] = (byte)(this.type);
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
            for (int i = 0; i < bytePokers.Length; i += 2)
            {
                switch(Convert.ToChar((bytePokers[i + 1])))
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
            //switch ((int)bytePokers[bytePokers.Length - 1])
            //{
            //    case 1:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 2:
            //        this.type = PokerGroupType.对子;
            //        break;
            //    case 3:
            //        this.type = PokerGroupType.双王;
            //        break;
            //    case 4:
            //        this.type = PokerGroupType.三张相同;
            //        break;
            //    case 5:
            //        this.type = PokerGroupType.三带一;
            //        break;
            //    case 6:
            //        this.type = PokerGroupType.炸弹;
            //        break;
            //    case 7:
            //        this.type = PokerGroupType.五张顺子;
            //        break;
            //    case 8:
            //        this.type = PokerGroupType.六张顺子;
            //        break;
            //    case 9:
            //        this.type = PokerGroupType.三连对;
            //        break;
            //    case 10:
            //        this.type = PokerGroupType.四带二;
            //        break;
            //    case 11:
            //        this.type = PokerGroupType.二连飞机;
            //        break;
            //    case 12:
            //        this.type = PokerGroupType.七张顺子;
            //        break;
            //    case 13:
            //        this.type = PokerGroupType.四连对;
            //        break;
            //    case 14:
            //        this.type = PokerGroupType.八张顺子;
            //        break;
            //    case 15:
            //        this.type = PokerGroupType.飞机带翅膀;
            //        break;
            //    case 16:
            //        this.type = PokerGroupType.九张顺子;
            //        break;
            //    case 17:
            //        this.type = PokerGroupType.三连飞机;
            //        break;
            //    case 18:
            //        this.type = PokerGroupType.五连对;
            //        break;
            //    case 19:
            //        this.type = PokerGroupType.十张顺子
            //        break;
            //    case 20:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 21:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 22:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 23:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 24:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 25:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 26:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 27:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 28:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 29:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 30:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 31:
            //        this.type = PokerGroupType.单张;
            //        break;
            //    case 32:
            //        this.type = PokerGroupType.单张;
            //        break;
            //}
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
            if (LP.Count != RP.Count && LP.type != PokerGroupType.炸弹 && LP.type != PokerGroupType.双王)
            {
                IsGreater = false;
            }
            else
            {
                switch (LP.Count)
                {
                    case 1:
                        if (LP[0] > RP[0])
                        {
                            IsGreater = true;
                        }
                        else
                        {
                            IsGreater = false;
                        }
                        break;
                    case 2: 
                        if (LP.type == PokerGroupType.双王) 
                        {
                            IsGreater = true;
                        }
                        if (LP.type == PokerGroupType.对子 && RP.type == PokerGroupType.对子)
                        {
                            if (LP[0] > RP[0])
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
                            IsGreater = false;
                        }
                        break;
                    case 3:
                        if (LP.type == PokerGroupType.三张相同 && RP.type == PokerGroupType.三张相同)
                        {
                            if (LP[0] > RP[0])
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
                            IsGreater = false;
                        }
                        break;
                    case 4:
                        if (LP.type == PokerGroupType.炸弹 && RP.type != PokerGroupType.炸弹 && RP.type != PokerGroupType.双王)
                        {
                            IsGreater = true;
                        }
                        else
                        {
                            if (LP.type == PokerGroupType.炸弹 && RP.type == PokerGroupType.炸弹)
                            {
                                if (LP[0] > RP[0])
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
                                if (LP.type == PokerGroupType.三带一 && RP.type == PokerGroupType.三带一) //先判断连续的三张牌靠前还是靠后,然后对四种情况做出不同的处理
                                {
                                    if (LP[0] != LP[1])
                                    {
                                        if (RP[0] != RP[1])  //第一种情况,LP和RP连续的三张牌都靠后,比较LP[3]和RP[3]的大小
                                        {
                                            if (LP[3] > RP[3])
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
                                            if (LP[3] > RP[0])  //第二种情况,LP的三张牌靠后,但是RP的三张牌靠前,比较LP[3]和RP[0]的大小
                                            {
                                                IsGreater = true;
                                            }
                                            else
                                            {
                                                IsGreater = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (RP[0] != RP[1])  //第三种情况,LP的三张牌靠前,RP的三张牌靠后,比较LP[0]和RP[3]
                                        {
                                            if (LP[0] > RP[3])
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
                                            if (LP[0] > RP[0])  //第四种情况,RP的三张牌靠前,LP的三张牌靠前,比较RP[0]和LP[0]
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
                                else
                                {
                                    IsGreater = false;
                                }
                            }
                        }
                        break;
                    case 5:
                        if (LP.type == PokerGroupType.五张顺子 && RP.type == PokerGroupType.五张顺子)
                        {
                            if (LP[0] > RP[0])
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
                            IsGreater = false;
                        }
                        break;
                    case 6:
                        if (LP.type == PokerGroupType.六张顺子 && RP.type == PokerGroupType.六张顺子)
                        {
                            if (LP[0] > RP[0])
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
                            if (LP.type == PokerGroupType.三连对 && RP.type == PokerGroupType.三连对)
                            {
                                if (LP[0] > RP[0])
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
                                if (LP.type == PokerGroupType.四带二 && LP.type == PokerGroupType.四带二)
                                {
                                    if (LP[0] > RP[0])
                                    {
                                        IsGreater = true;
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                        break;
                    case 7:
                        if (LP.type == PokerGroupType.七张顺子 && RP.type == PokerGroupType.七张顺子)
                        {
                            if (LP[0] > RP[0])
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
                            IsGreater = false;
                        }
                        break;
                    case 8:
                        if (LP.type == PokerGroupType.八张顺子 && RP.type == PokerGroupType.八张顺子)
                        {
                            if (LP[0] > RP[0])
                            {
                                IsGreater = true;
                            }
                            else
                            {
                                if (LP.type == PokerGroupType.四连对 && RP.type == PokerGroupType.四连对)
                                {
                                    if (LP[0] > RP[0])
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
                                    IsGreater = false;
                                }
                            }
                        }
                        break;
                    default:
                        IsGreater = false;
                        break;
                }
            }
            return IsGreater;
        }
        public static bool operator <(PokerGroup LP, PokerGroup RP)
        {
            return (RP > LP);
        }
    }

}