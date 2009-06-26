using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ_DDZ
{
    public interface IWatingReady
    {
        /// <summary>
        /// 所有玩家是否已准备
        /// </summary>
        /// <param name="playerAmount">玩家数量</param>
        /// <returns>是否全部准备</returns>
        bool EveryOneIsReady(PlayerCollection players);
    }
}
