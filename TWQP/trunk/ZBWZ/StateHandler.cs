using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;

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

        public byte[][] Throw(Player player)
        {
            player.Num = new Random().Next(1, 7);
            player.IsThrew = true;
            return new byte[][] { DataType.Num.ToBinary(), player.Num.ToBinary() };
        }

        public byte[][] GetResult(List<Player> players)
        {
            int[] zero = { 0 };
            var TheSamePlayerAmount = 0;
            byte[][] dataResult;
            players.Sort(Player.ComparePlayerByNum); //从小到大排序
            for (int i = players.Count - 1; i >= 1; i++) //判断相同点数玩家的数量
            {
                if (players[i] == players[i - 1])
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
                dataResult = new byte[][] { DataType.Result.ToBinary(), zero.ToBinary()};
            }
            else
            {
                List<int> WinersId = new List<int>();
                for (int i = players.Count - TheSamePlayerAmount; i < players.Count; i++) //给胜者加分
                {
                    players[i].Score += RoundScore;
                    WinersId.Add(players[i].Id);
                }
                for (int i = 0; i < players.Count - TheSamePlayerAmount; i++)  //给败者减分
                {
                    players[i].Score -= TheSamePlayerAmount * RoundScore / (players.Count - TheSamePlayerAmount);
                }
                dataResult = new byte[][] { DataType.Result.ToBinary(), WinersId.ToArray().ToBinary() }; //返回的结果数据
            }
            return dataResult;

        }
        public byte[][] GetScore(Player player)
        {
            return new byte[][] { DataType.Score.ToBinary(), player.Score.ToBinary() };
        }

        public bool EveryOneIsThrew(List<Player> players)
        {
            var everyOneIsThrew = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.IsThrew)
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

        public Player WhoThrowTimeOuted(long Counter, List<Player> players)
        {
            foreach (var onePlayer in players)
            {
                if (Counter >= onePlayer.TimeOut && !onePlayer.IsThrew)
                {
                    return onePlayer;
                }
            }
            return null;
        }

        #endregion

        #region IWatingReady 成员

        public int ReadyPlayerAmount { get; set; }

        public bool EveryOneIsReady(int playerAmount)
        {
            if (playerAmount == ReadyPlayerAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[][] GetStartData()
        {
            return new byte[][] { DataType.Action.ToBinary(), ActionType.Start.ToBinary() };
        }

        public void PlayerReady(Player player)
        {
            player.IsReady = true;
            ReadyPlayerAmount++;
        }


        public bool EveryOneIsReady(List<Player> players)
        {
            var everyOneIsReady = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.IsReady)
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

        public Player WhoReadyTimeOuted(long Counter, List<Player> players)
        {
            foreach(var onePlayer in players)
            {
                if (Counter >= onePlayer.TimeOut && !onePlayer.IsReady)
                {
                    return onePlayer;
                }
            }
            return null;
        }


        #endregion

        #region IWatingJoin 成员

        public int AmountPlayer { get; set; }

        public byte[][] CanIJoinIt(int Amount)
        {
            byte[][] data;
            if (Amount < AmountPlayer)
            {
                data = new byte[][] { DataType.Action.ToBinary(), ActionType.YouCanJoinIt.ToBinary() };
            }
            else
            {
                data = new byte[][] { DataType.Action.ToBinary(), ActionType.YouCanNotJoinIt.ToBinary() };
            }
            return data;
        }

        public bool HasThisPlayer(int PlayerId, List<Player> players)
        {
            var has = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Id == PlayerId)
                {
                    has = true;
                }
            }
            return has;
        }

        public Player WhoJoinTimeOuted(long Counter, List<Player> players)
        {
            foreach (var onePlayer in players)
            {
                if (Counter >= onePlayer.TimeOut && !onePlayer.Joined)
                {
                    return onePlayer;
                }
            }
            return null;
        }

        public bool JoinSuccess(List<Player> players)
        {
            var joinSuccess = false;
            foreach (var onePlayer in players)
            {
                if (onePlayer.Joined)
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
}
