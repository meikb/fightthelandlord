using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ZBWZ
{
    public class Player
    {
        public int Id { get; set; }
        public bool IsReady { get; set; }
        public int Score { get; set; }
        public int Num { get; set; }
        public Timer TimeOut = new Timer(30000);
        public Player(int Id)
        {
            this.Id = Id;
            TimeOut.Elapsed += (sender1, ea1) =>
                {
                    
                };
        }
        public Player()
        {
        }
        public static int ComparePlayerByNum(Player p1, Player p2)
        {

            if (p1.Num > p2.Num)
            {
                return 1;
            }
            else
            {
                if (p1.Num < p2.Num)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
    public class Watcher
    {
        public int Id { get; set; }

        public Watcher(int Id)
        {
            this.Id = Id;
        }
    }
}
