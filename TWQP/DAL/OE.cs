using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 查询表达式辅助创建类
	/// </summary>
	public static partial class OE
	{
		#region Base Expression Class

		/// <summary>
		/// 表达式基类
		/// </summary>
		public partial class __Exp
		{
			public object __Column;
			public object __Value;
			public SQLHelper.Operators __Operate;
			public bool __IsAndEffect;
			public List<__Exp> __Nodes = null;
			public __Exp And(__Exp subExp)
			{
				if (subExp == null) return this;
				__IsAndEffect = true;
				__Nodes.Add(subExp);
				return this;
			}
			public __Exp Or(__Exp subExp)
			{
				if (subExp == null) return this;
				__IsAndEffect = false;
				__Nodes.Add(subExp);
				return this;
			}

			public __Exp(object column, SQLHelper.Operators operate, object value)
			{
				__Column = column; __Value = value; __Operate = operate; __IsAndEffect = true;
				__Nodes = new List<__Exp>();
			}
		}

		#endregion

	}
}
