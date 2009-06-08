using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	public static partial class OE
	{

		#region User Defined Function Tables

		#region dbo_uf_Split

		/// <summary>
		/// 
		/// </summary>
		public partial class dbo_uf_Split : __Exp
		{
			#region Exp

			public dbo_uf_Split And(dbo_uf_Split subExp)
			{
				if (subExp == null) return this;
				__IsAndEffect = true;
				__Nodes.Add(subExp);
				return this;
			}
			public dbo_uf_Split Or(dbo_uf_Split subExp)
			{
				if (subExp == null) return this;
				__IsAndEffect = false;
				__Nodes.Add(subExp);
				return this;
			}


			public new DI.dbo_uf_Split __Column
			{
				get { return (DI.dbo_uf_Split)base.__Column; }
				set { base.__Column = value; }
			}

			/// <summary>
			/// 创建自定义表达式
			/// </summary>
			public dbo_uf_Split(string customExp) : base(0, 0, customExp) { }
			/// <summary>
			/// 创建相等运算的某字段的表达式
			/// </summary>
			public dbo_uf_Split(DI.dbo_uf_Split column, object value) : base(column, SQLHelper.Operators.Equal, value) { }
			/// <summary>
			/// 创建某字段的某种运算的表达式
			/// </summary>
			public dbo_uf_Split(DI.dbo_uf_Split column, SQLHelper.Operators operate, object value) : base(column, operate, value) { }

			/// <summary>
			/// 将表达式转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = null;
				if(this.__Column == 0 && base.__Operate == SQLHelper.Operators.Custom)
				{
					s = (string)base.__Value;	   //for full custom expression support
				}
				else switch (this.__Column)
				{

					case DI.dbo_uf_Split.id:
						if (base.__Operate == SQLHelper.Operators.Custom) s = "[id]" + (string)base.__Value;
						else if (base.__Operate == SQLHelper.Operators.In || base.__Operate == SQLHelper.Operators.NotIn) s = "[id] " + SQLHelper.GetOperater(base.__Operate) + " (" + SQLHelper.Combine<int>((IEnumerable<int>)base.__Value) + ")";
						else s = "[id] " + SQLHelper.GetOperater(base.__Operate) + " " + base.__Value.ToString();
						break;

					case DI.dbo_uf_Split.item:
						if (base.__Operate == SQLHelper.Operators.Custom) s = "[item]" + (string)base.__Value;
						else if (base.__Operate == SQLHelper.Operators.In || base.__Operate == SQLHelper.Operators.NotIn) s = "[item] " + SQLHelper.GetOperater(base.__Operate) + " (" + SQLHelper.Combine<string>((IEnumerable<string>)base.__Value) + ")";
						else if (base.__Value == null && base.__Operate == SQLHelper.Operators.Equal) s = "[item] IS NULL";
						else if (base.__Value == null && base.__Operate == SQLHelper.Operators.NotEqual) s = "[item] IS NOT NULL";
						else if (base.__Operate == SQLHelper.Operators.Like) s = "[item] LIKE '%" + SQLHelper.EscapeLike((string)base.__Value) + "%'";
						else if (base.__Operate == SQLHelper.Operators.CustomLike) s = "[item] LIKE '" + SQLHelper.EscapeEqual((string)base.__Value) + "'";
						else if (base.__Operate == SQLHelper.Operators.NotLike) s = "[item] NOT LIKE '%" + SQLHelper.EscapeLike((string)base.__Value) + "%'";
						else if (base.__Operate == SQLHelper.Operators.CustomNotLike) s = "[item] NOT LIKE '" + SQLHelper.EscapeEqual((string)base.__Value) + "'";
						else s = "[item] " + SQLHelper.GetOperater(base.__Operate) + " '" + SQLHelper.EscapeEqual((string)base.__Value) + "'";
						break;

				}
				if (this.__Nodes != null && this.__Nodes.Count > 0)
				{
					s = "(" + s ;
					foreach (dbo_uf_Split __node in this.__Nodes)
					{
						s += " " + (this.__IsAndEffect ? "AND" : "OR") + " " + __node.ToString();
					}
					s += ")";
				}
				return s;
			}

			#endregion


			#region id
			/// <summary>
			/// 
			/// </summary>
			public partial class id
			{

				/// <summary>
				/// 创建 字段 id 的 自定义表达式。
				/// 生成格式为  [id] {s}
				/// </summary>
				public static dbo_uf_Split Custom(string s)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, 0, s);
				}
				/// <summary>
				/// 创建 字段 id 的 相等 判断表达式。
				/// 生成格式为  [id] = {value}
				/// </summary>
				public static dbo_uf_Split Equal(int id)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.Equal, id);
				}
				/// <summary>
				/// 创建 字段 id 的 不等于 判断表达式。
				/// 生成格式为  [id] <> {value}
				/// </summary>
				public static dbo_uf_Split NotEqual(int id)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.NotEqual, id);
				}

				/// <summary>
				/// 创建 字段 id 的 小于 判断表达式。
				/// 生成格式为  [id] < {value}
				/// </summary>
				public static dbo_uf_Split LessThan(int id)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.LessThan, id);
				}
				/// <summary>
				/// 创建 字段 id 的 小于且等于 判断表达式。
				/// 生成格式为  [id] <= {value}
				/// </summary>
				public static dbo_uf_Split LessEqual(int id)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.LessEqual, id);
				}
				/// <summary>
				/// 创建 字段 id 的 大于 判断表达式。
				/// 生成格式为  [id] > {value}
				/// </summary>
				public static dbo_uf_Split LargerThan(int id)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.LargerThan, id);
				}
				/// <summary>
				/// 创建 字段 id 的 大于且等于 判断表达式。
				/// 生成格式为  [id] >= {value}
				/// </summary>
				public static dbo_uf_Split LargerEqual(int id)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.LargerEqual, id);
				}
	
				/// <summary>
				/// 创建 字段 id 的 包含 判断表达式。
				/// 生成格式为  [id] IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split In(IEnumerable<int> list)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.In, list);
				}
				/// <summary>
				/// 创建 字段 id 的 包含 判断表达式。
				/// 生成格式为  [id] IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split In(params int[] list)
				{
					return In(new List<int>(list));
				}
				/// <summary>
				/// 创建 字段 id 的 不包含 判断表达式。
				/// 生成格式为  [id] NOT IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split NotIn(IEnumerable<int> list)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.id, SQLHelper.Operators.NotIn, list);
				}
				/// <summary>
				/// 创建 字段 id 的 不包含 判断表达式。
				/// 生成格式为  [id] NOT IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split NotIn(params int[] list)
				{
					return NotIn(new List<int>(list));
				}

			}
			#endregion

			#region item
			/// <summary>
			/// 
			/// </summary>
			public partial class item
			{

				/// <summary>
				/// 创建 字段 item 的 自定义表达式。
				/// 生成格式为  [item] {s}
				/// </summary>
				public static dbo_uf_Split Custom(string s)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, 0, s);
				}
				/// <summary>
				/// 创建 字段 item 的 相等 判断表达式。
				/// 生成格式为  [item] = {value}
				/// </summary>
				public static dbo_uf_Split Equal(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.Equal, item);
				}
				/// <summary>
				/// 创建 字段 item 的 不等于 判断表达式。
				/// 生成格式为  [item] <> {value}
				/// </summary>
				public static dbo_uf_Split NotEqual(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.NotEqual, item);
				}

				/// <summary>
				/// 创建 字段 item 的 相似 判断表达式。
				/// 生成格式为  [item] LIKE '% ? %'
				/// </summary>
				public static dbo_uf_Split Like(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.Like, item);
				}
				/// <summary>
				/// 创建 字段 item 的 自定义相似 判断表达式。
				/// 生成格式为  [item] LIKE ' ? '
				/// </summary>
				public static dbo_uf_Split LikeEx(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.CustomLike, item);
				}
				/// <summary>
				/// 创建 字段 item 的 不相似 判断表达式。
				/// 生成格式为  [item] NOT LIKE '% ? %'
				/// </summary>
				public static dbo_uf_Split NotLike(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.NotLike, item);
				}
				/// <summary>
				/// 创建 字段 item 的 自定义不相似 判断表达式。
				/// 生成格式为  [item] NOT LIKE ' ? '
				/// </summary>
				public static dbo_uf_Split NotLikeEx(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.CustomNotLike, item);
				}

				/// <summary>
				/// 创建 字段 item 的 小于 判断表达式。
				/// 生成格式为  [item] < {value}
				/// </summary>
				public static dbo_uf_Split LessThan(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.LessThan, item);
				}
				/// <summary>
				/// 创建 字段 item 的 小于且等于 判断表达式。
				/// 生成格式为  [item] <= {value}
				/// </summary>
				public static dbo_uf_Split LessEqual(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.LessEqual, item);
				}
				/// <summary>
				/// 创建 字段 item 的 大于 判断表达式。
				/// 生成格式为  [item] > {value}
				/// </summary>
				public static dbo_uf_Split LargerThan(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.LargerThan, item);
				}
				/// <summary>
				/// 创建 字段 item 的 大于且等于 判断表达式。
				/// 生成格式为  [item] >= {value}
				/// </summary>
				public static dbo_uf_Split LargerEqual(string item)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.LargerEqual, item);
				}
	
				/// <summary>
				/// 创建 字段 item 的 包含 判断表达式。
				/// 生成格式为  [item] IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split In(IEnumerable<string> list)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.In, list);
				}
				/// <summary>
				/// 创建 字段 item 的 包含 判断表达式。
				/// 生成格式为  [item] IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split In(params string[] list)
				{
					return In(new List<string>(list));
				}
				/// <summary>
				/// 创建 字段 item 的 不包含 判断表达式。
				/// 生成格式为  [item] NOT IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split NotIn(IEnumerable<string> list)
				{
					return new dbo_uf_Split(DI.dbo_uf_Split.item, SQLHelper.Operators.NotIn, list);
				}
				/// <summary>
				/// 创建 字段 item 的 不包含 判断表达式。
				/// 生成格式为  [item] NOT IN ( ??,??,??,.... )
				/// </summary>
				public static dbo_uf_Split NotIn(params string[] list)
				{
					return NotIn(new List<string>(list));
				}

			}
			#endregion

		}
		#endregion

		#endregion

	}
}
