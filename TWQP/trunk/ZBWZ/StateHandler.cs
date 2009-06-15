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

        public bool EveryOneIsThrew(int PlayerAmount)
        {
            if (PlayerAmount == ThrewPlayerAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[][] Throw(Character player)
        {
            player.Num = new Random().Next(1, 7);
            return new byte[][] { DataType.Num.ToBinary(), player.Num.ToBinary() };
        }

        //public byte[][] GetResult(Dictionary<int, KeyValuePair<int, Character>> players)
        //{
        //    int[] zero = { 0 };
        //    var TheSamePlayerAmount = 0;
        //    byte[][] dataResult;
        //    players.Sort(Player.ComparePlayerByNum); //从小到大排序
        //    players.Values.Select
        //    for (int i = players.Values.Count - 1; i >= 1; i++) //判断相同点数玩家的数量
        //    {
        //        if (players[i] == players[i - 1])
        //        {
        //            TheSamePlayerAmount++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    if (TheSamePlayerAmount == players.Count - 1) //全部相同
        //    {
        //        dataResult = new byte[][] { DataType.Result.ToBinary(), zero.ToBinary() };
        //    }
        //    else
        //    {
        //        List<int> WinersId = new List<int>();
        //        for (int i = players.Count - TheSamePlayerAmount; i < players.Count; i++) //给胜者加分
        //        {
        //            players.Values[i] += RoundScore;
        //            WinersId.Add(players[i].Id);
        //        }
        //        for (int i = 0; i < players.Count - TheSamePlayerAmount; i++)  //给败者减分
        //        {
        //            players[i].Score -= TheSamePlayerAmount * RoundScore / (players.Count - TheSamePlayerAmount);
        //        }
        //        dataResult = new byte[][] { DataType.Result.ToBinary(), WinersId.ToArray().ToBinary() }; //返回的结果数据
        //    }
        //    return dataResult;

        //}
        public byte[][] GetScore(Character player)
        {
            return new byte[][] { DataType.Score.ToBinary(), player.Gold.ToBinary() };
        }

        public bool EveryOneIsThrew(Dictionary<int, KeyValuePair<int, Character>> players)
        {
            var everyOneIsThrew = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.Value.clientState == ClientStates.已发_已掷骰子)
                {
                    everyOneIsThrew = true;
                }
                else
                {
                    everyOneIsThrew = false;
                    break;
                }
            }
            return everyOneIsThrew;
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
            var everyOneIsReady = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.Value.clientState == ClientStates.已发_已准备好)
                {
                    everyOneIsReady = true;
                }
                else
                {
                    everyOneIsReady = false;
                    break;
                }
            }
            return everyOneIsReady;
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
            var joinSuccess = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Value.Value.clientState == ClientStates.已发_要求进入)
                {
                    joinSuccess = true;
                }
                else
                {
                    joinSuccess = false;
                    break;
                }
            }
            return joinSuccess;
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
