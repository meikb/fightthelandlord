using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FightTheLandLord
{
    public class Player
    {
        private List<Poker> _pokers = new List<Poker>();
        private bool _isLandLord;

        public List<Poker> pokers
        {
            get
            {
                return this._pokers;
            }
            set
            {
                this._pokers = value;
            }
        }
        public bool isLandLord
        {
            get
            {
                return _isLandLord;
            }
            set
            {
                this._isLandLord = value;
            }
        }


        /// <summary>
        /// 把牌从大到小重新排序
        /// </summary>
        public void sort()
        {
        }

        /// <summary>
        /// 获取扑克牌下标,检测是否符合游戏规则,如果符合则出牌,否则返回flase
        /// </summary>
        public bool lead(int[] inargs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 把牌从大到小从左至右绘制到容器上
        /// </summary>
        public void Paint()
        {
            throw new System.NotImplementedException();
        }
    }
}
