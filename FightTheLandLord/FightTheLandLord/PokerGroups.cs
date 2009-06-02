using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightTheLandLord
{
    public class PokerGroups : List<PokerGroup>
    {
        public new void Add(PokerGroup PG)
        {
            if (DConsole.IsRules(PG))
            {
                base.Add(PG);
            }
            else
            {
                DConsole.Write("[系统消息]:有玩家作弊!");
            }
        }
    }
}
