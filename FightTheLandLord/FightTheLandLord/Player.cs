using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FightTheLandLord
{
    public class Player
    {
        private List<Poker> _pokers;

        public List<Poker> pokers
        {
            get
            {
                return pokers;
            }
            set
            {
                this._pokers = value;
            }
        }

        /// <summary>
        /// 把牌从大到小重新排序
        /// </summary>
        public void sort()
        {
            throw new System.NotImplementedException();
        }
    }
}
