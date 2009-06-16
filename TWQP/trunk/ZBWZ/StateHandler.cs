using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace ZBWZ
{
    public class StateHandler:IWatingJoin,IWatingReady,IWatingThrow
    {
        #region IWatingThrow 成员

        public int ThrewPlayerAmount { get; set; }

        public int RoundScore { get; set; }

        public byte[][] Throw(Character player)
        {
            player.Num = new Random().Next(1, 7);
            return new byte[][] { DataType.Num.ToBinary(), player.Num.ToBinary() };
        }

        public byte[][] GetResult(Dictionary<int, KeyValuePair<int, Character>> players)
        {
            int[] zero = { 0 };
            var TheSamePlayerAmount = 0;
            byte[][] dataResult;
            for (int i = 0; i < players.Count - 1; i++)  //根据骰子的点数从小到大排序
            {
                for (int j = i + 1; j < players.Count; j++)
                {
                    var temp = players[i];
                    if (players[i].Value.Num > players[j].Value.Num)
                    {
                        players[i] = players[j];
                        players[j] = temp;
                    }
                }
            }
            for (int i = players.Values.Count - 1; i >= 1; i++) //判断相同点数玩家的数量
            {
                if (players[i].Value.Num == players[i - 1].Value.Num)
                {
                    TheSamePlayerAmount++;
                }
                else
                {
                    break;
                }
            }
            if (TheSamePlayerAmount == players.Count - 1) //全部相同
            {
                dataResult = new byte[][] { BitConverter.GetBytes((int)RollActions.S_结果), zero.ToBinary() };
            }
            else
            {
                List<int> WinersId = new List<int>();
                for (int i = players.Count - TheSamePlayerAmount; i < players.Count; i++) //给胜者加分
                {
                    players[i].Value.Gold += RoundScore;
                    WinersId.Add(players[i].Key);
                }
                for (int i = 0; i < players.Count - TheSamePlayerAmount; i++)  //给败者减分
                {
                    players[i].Value.Gold -= TheSamePlayerAmount * RoundScore / (players.Count - TheSamePlayerAmount);
                }
                dataResult = new byte[][] { BitConverter.GetBytes((int)RollActions.S_结果), WinersId.ToArray().ToBinary() }; //返回的结果数据
            }
            return dataResult;

        }
        public byte[][] GetScore(Character player)
        {
            return new byte[][] { DataType.Score.ToBinary(), player.Gold.ToBinary() };
        }

        public bool EveryOneIsThrew(Dictionary<int, KeyValuePair<int, Character>> players)
        {
            var ThrewPlayer = 0;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.Value.clientState == ClientStates.已发_已掷骰子)
                {
                    ThrewPlayer++;
                }
                else
                {
                    return false;
                }
            }
            if (ThrewPlayer == AmountPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public Dictionary<int, KeyValuePair<int, Character>> WhoThrowTimeOuted(long Counter, Dictionary<int, KeyValuePair<int, Character>> players)
        //{
        //    foreach (var onePlayer in players)
        //    {
        //        if (Counter >= onePlayer.TimeOut && !onePlayer.IsThrew)
        //        {
        //            return onePlayer;
        //        }
        //    }
        //    return null;
        //}

        #endregion

        #region IWatingReady 成员

        //public int ReadyPlayerAmount { get; set; }

        public byte[][] GetStartData()
        {
            return new byte[][] { DataType.Action.ToBinary(), ActionType.Start.ToBinary() };
        }

        //public void PlayerReady(Character player)
        //{
        //    ReadyPlayerAmount++;
        //}


        public bool EveryOneIsReady(Dictionary<int, KeyValuePair<int, Character>> players)
        {
            var ReadyPlayer = 0;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.Value.clientState == ClientStates.已发_已准备好)
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

        //public Dictionary<int, KeyValuePair<int, Character>> WhoReadyTimeOuted(long Counter, Dictionary<int, KeyValuePair<int, Character>> players)
        //{
        //    foreach(var onePlayer in players)
        //    {
        //        if (Counter >= onePlayer.TimeOut && !onePlayer.IsReady)
        //        {
        //            return onePlayer;
        //        }
        //    }
        //    return null;
        //}


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

        //public Dictionary<int, KeyValuePair<int, Character>> WhoJoinTimeOuted(long Counter, Dictionary<int, KeyValuePair<int, Character>> players)
        //{
        //    foreach (var onePlayer in players)
        //    {
        //        if (Counter >= onePlayer.TimeOut && !onePlayer.Joined)
        //        {
        //            return onePlayer;
        //        }
        //    }
        //    return null;
        //}

        public bool JoinSuccess(Dictionary<int, KeyValuePair<int, Character>> players)
        {
            var joinSuccessPlayer = 0;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.Value.clientState == ClientStates.已发_要求进入)
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
        public ClientStates clientState;
        public long 超时_进入超时;
        public long 超时_准备超时;
        public long 超时_投掷超时;
        public int 获胜次数;
        public int Num;
    }

    public class Message
    {
        int Id;
        byte[][] data;
        public RollActions rollAction;
    }
}
