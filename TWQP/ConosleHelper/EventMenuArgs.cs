using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHelper
{
	/// <summary>
	/// 承载主菜单初始化事件传递的参数
	/// </summary>
	public class EventMenuArgs : EventArgs
	{
		protected object _args = null;
		/// <summary>
		/// 用于传递的参数
		/// </summary>
		public virtual object Args
		{
			get { return _args; }
		}
		public EventMenuArgs(object args) { _args = args; }
	}

}
