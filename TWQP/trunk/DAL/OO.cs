using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace DAL
{
	/// <summary>
	/// 与数据库结构对应的类实例及其集合声明，含表，视图，表值函数的定义
	/// </summary>
	public static partial class OO
	{
		#region Tables

		#region Game_Action

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_Action
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Action 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ActionID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ActionID
				{
					get { return __________ActionID; }
					set { __________ActionID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ActionID)
				{
					__________ActionID = ActionID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ActionID == other.ActionID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Action 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Action 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Action other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Action.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________GameID;
			protected int __________DataTypeID;
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_Action()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_Action(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_Action(int GameID, int DataTypeID, int ActionID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(ActionID);
				__________GameID = GameID;
				__________DataTypeID = DataTypeID;
				__________Name = Name;
				__________Description = Description;
			}
			public Game_Action(PrimaryKeys __pk, int GameID, int DataTypeID, string Name, string Description)
			{
				__PKs = __pk;
				__________GameID = GameID;
				__________DataTypeID = DataTypeID;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_Action __oo)
			{
				__oo.GameID = this.GameID;
				__oo.DataTypeID = this.DataTypeID;
				__oo.ActionID = this.ActionID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_Action __oo)
			{
				this.GameID = __oo.GameID;
				this.DataTypeID = __oo.DataTypeID;
				this.ActionID = __oo.ActionID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_Action Copy()
			{
				Game_Action __oo = new Game_Action();
				__oo.GameID = this.GameID;
				__oo.DataTypeID = this.DataTypeID;
				__oo.ActionID = this.ActionID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_Action __o)
			{
				if (this == __o) return true;
				if (
					this.GameID == __o.GameID
					&& this.DataTypeID == __o.DataTypeID
					&& this.ActionID == __o.ActionID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int GameID
			{
				get { return __________GameID; }
				set { __________GameID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DataTypeID
			{
				get { return __________DataTypeID; }
				set { __________DataTypeID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ActionID
			{
				get { return __PKs.ActionID; }
				set { __PKs.ActionID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_ActionCollection : List<Game_Action>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_Action Add(int GameID, int DataTypeID, int ActionID, string Name, string Description)
			{
				Game_Action o = new Game_Action(GameID, DataTypeID, ActionID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_ActionCollection __os)
			{
				int i = 0;
				foreach (Game_Action __o in __os)
				{
					Game_Action __oo = this.Find(new Predicate<Game_Action>(delegate(Game_Action _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_ActionCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_ActionCollection Rows;
		}

		#endregion

		#region Game_Desk

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_Desk
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Desk 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________DeskID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int DeskID
				{
					get { return __________DeskID; }
					set { __________DeskID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int DeskID)
				{
					__________DeskID = DeskID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________DeskID == other.DeskID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Desk 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Desk 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Desk other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Desk.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________DeskTypeID;
			protected int __________LobbyID;
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_Desk()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_Desk(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_Desk(int DeskTypeID, int LobbyID, int DeskID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(DeskID);
				__________DeskTypeID = DeskTypeID;
				__________LobbyID = LobbyID;
				__________Name = Name;
				__________Description = Description;
			}
			public Game_Desk(PrimaryKeys __pk, int DeskTypeID, int LobbyID, string Name, string Description)
			{
				__PKs = __pk;
				__________DeskTypeID = DeskTypeID;
				__________LobbyID = LobbyID;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_Desk __oo)
			{
				__oo.DeskTypeID = this.DeskTypeID;
				__oo.LobbyID = this.LobbyID;
				__oo.DeskID = this.DeskID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_Desk __oo)
			{
				this.DeskTypeID = __oo.DeskTypeID;
				this.LobbyID = __oo.LobbyID;
				this.DeskID = __oo.DeskID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_Desk Copy()
			{
				Game_Desk __oo = new Game_Desk();
				__oo.DeskTypeID = this.DeskTypeID;
				__oo.LobbyID = this.LobbyID;
				__oo.DeskID = this.DeskID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_Desk __o)
			{
				if (this == __o) return true;
				if (
					this.DeskTypeID == __o.DeskTypeID
					&& this.LobbyID == __o.LobbyID
					&& this.DeskID == __o.DeskID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskTypeID
			{
				get { return __________DeskTypeID; }
				set { __________DeskTypeID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int LobbyID
			{
				get { return __________LobbyID; }
				set { __________LobbyID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskID
			{
				get { return __PKs.DeskID; }
				set { __PKs.DeskID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_DeskCollection : List<Game_Desk>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_Desk Add(int DeskTypeID, int LobbyID, int DeskID, string Name, string Description)
			{
				Game_Desk o = new Game_Desk(DeskTypeID, LobbyID, DeskID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_DeskCollection __os)
			{
				int i = 0;
				foreach (Game_Desk __o in __os)
				{
					Game_Desk __oo = this.Find(new Predicate<Game_Desk>(delegate(Game_Desk _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_DeskCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_DeskCollection Rows;
		}

		#endregion

		#region Game_DeskActionLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_DeskActionLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：DeskActionLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________DeskActionLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int DeskActionLogID
				{
					get { return __________DeskActionLogID; }
					set { __________DeskActionLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int DeskActionLogID)
				{
					__________DeskActionLogID = DeskActionLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________DeskActionLogID == other.DeskActionLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：DeskActionLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：DeskActionLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskActionLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskActionLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________DeskID;
			protected int __________ActionID;
			protected int __________SourceCharacterID;
			protected int __________TargetCharacterID;
			protected object __________Data;
			protected System.DateTime __________CreateTime;

			#endregion

			#region 构造函数

			public Game_DeskActionLog()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_DeskActionLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_DeskActionLog(int DeskActionLogID, int DeskID, int ActionID, int SourceCharacterID, int TargetCharacterID, object Data, System.DateTime CreateTime)
			{
				__PKs = new PrimaryKeys(DeskActionLogID);
				__________DeskID = DeskID;
				__________ActionID = ActionID;
				__________SourceCharacterID = SourceCharacterID;
				__________TargetCharacterID = TargetCharacterID;
				__________Data = Data;
				__________CreateTime = CreateTime;
			}
			public Game_DeskActionLog(PrimaryKeys __pk, int DeskID, int ActionID, int SourceCharacterID, int TargetCharacterID, object Data, System.DateTime CreateTime)
			{
				__PKs = __pk;
				__________DeskID = DeskID;
				__________ActionID = ActionID;
				__________SourceCharacterID = SourceCharacterID;
				__________TargetCharacterID = TargetCharacterID;
				__________Data = Data;
				__________CreateTime = CreateTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_DeskActionLog __oo)
			{
				__oo.DeskActionLogID = this.DeskActionLogID;
				__oo.DeskID = this.DeskID;
				__oo.ActionID = this.ActionID;
				__oo.SourceCharacterID = this.SourceCharacterID;
				__oo.TargetCharacterID = this.TargetCharacterID;
				__oo.Data = this.Data;
				__oo.CreateTime = this.CreateTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_DeskActionLog __oo)
			{
				this.DeskActionLogID = __oo.DeskActionLogID;
				this.DeskID = __oo.DeskID;
				this.ActionID = __oo.ActionID;
				this.SourceCharacterID = __oo.SourceCharacterID;
				this.TargetCharacterID = __oo.TargetCharacterID;
				this.Data = __oo.Data;
				this.CreateTime = __oo.CreateTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_DeskActionLog Copy()
			{
				Game_DeskActionLog __oo = new Game_DeskActionLog();
				__oo.DeskActionLogID = this.DeskActionLogID;
				__oo.DeskID = this.DeskID;
				__oo.ActionID = this.ActionID;
				__oo.SourceCharacterID = this.SourceCharacterID;
				__oo.TargetCharacterID = this.TargetCharacterID;
				__oo.Data = this.Data;
				__oo.CreateTime = this.CreateTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_DeskActionLog __o)
			{
				if (this == __o) return true;
				if (
					this.DeskActionLogID == __o.DeskActionLogID
					&& this.DeskID == __o.DeskID
					&& this.ActionID == __o.ActionID
					&& this.SourceCharacterID == __o.SourceCharacterID
					&& this.TargetCharacterID == __o.TargetCharacterID
					&& this.Data == __o.Data
					&& this.CreateTime == __o.CreateTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskActionLogID
			{
				get { return __PKs.DeskActionLogID; }
				set { __PKs.DeskActionLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskID
			{
				get { return __________DeskID; }
				set { __________DeskID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ActionID
			{
				get { return __________ActionID; }
				set { __________ActionID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int SourceCharacterID
			{
				get { return __________SourceCharacterID; }
				set { __________SourceCharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int TargetCharacterID
			{
				get { return __________TargetCharacterID; }
				set { __________TargetCharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Data
			{
				get { return __________Data; }
				set { __________Data = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
		}

		[Serializable]
		public partial class Game_DeskActionLogCollection : List<Game_DeskActionLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_DeskActionLog Add(int DeskActionLogID, int DeskID, int ActionID, int SourceCharacterID, int TargetCharacterID, object Data, System.DateTime CreateTime)
			{
				Game_DeskActionLog o = new Game_DeskActionLog(DeskActionLogID, DeskID, ActionID, SourceCharacterID, TargetCharacterID, Data, CreateTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_DeskActionLogCollection __os)
			{
				int i = 0;
				foreach (Game_DeskActionLog __o in __os)
				{
					Game_DeskActionLog __oo = this.Find(new Predicate<Game_DeskActionLog>(delegate(Game_DeskActionLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_DeskActionLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_DeskActionLogCollection Rows;
		}

		#endregion

		#region Game_DeskProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_DeskProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：DeskProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________DeskID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int DeskID
				{
					get { return __________DeskID; }
					set { __________DeskID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int DeskID, string Key)
				{
					__________DeskID = DeskID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________DeskID == other.DeskID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：DeskProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：DeskProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_DeskProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_DeskProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_DeskProfile(int DeskID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(DeskID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public Game_DeskProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_DeskProfile __oo)
			{
				__oo.DeskID = this.DeskID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_DeskProfile __oo)
			{
				this.DeskID = __oo.DeskID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_DeskProfile Copy()
			{
				Game_DeskProfile __oo = new Game_DeskProfile();
				__oo.DeskID = this.DeskID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_DeskProfile __o)
			{
				if (this == __o) return true;
				if (
					this.DeskID == __o.DeskID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskID
			{
				get { return __PKs.DeskID; }
				set { __PKs.DeskID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_DeskProfileCollection : List<Game_DeskProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_DeskProfile Add(int DeskID, string Key, object Value, object DefaultValue, string Description)
			{
				Game_DeskProfile o = new Game_DeskProfile(DeskID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_DeskProfileCollection __os)
			{
				int i = 0;
				foreach (Game_DeskProfile __o in __os)
				{
					Game_DeskProfile __oo = this.Find(new Predicate<Game_DeskProfile>(delegate(Game_DeskProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_DeskProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_DeskProfileCollection Rows;
		}

		#endregion

		#region Game_DeskType

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_DeskType
		{
			#region 主键组类定义

			/// <summary>
			/// 表：DeskType 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________DeskTypeID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int DeskTypeID
				{
					get { return __________DeskTypeID; }
					set { __________DeskTypeID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int DeskTypeID)
				{
					__________DeskTypeID = DeskTypeID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________DeskTypeID == other.DeskTypeID;
				}

				#endregion
			}

			/// <summary>
			/// 表：DeskType 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：DeskType 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskType other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskType.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________GameID;
			protected int __________NumPerson;

			#endregion

			#region 构造函数

			public Game_DeskType()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_DeskType(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_DeskType(int DeskTypeID, int GameID, int NumPerson)
			{
				__PKs = new PrimaryKeys(DeskTypeID);
				__________GameID = GameID;
				__________NumPerson = NumPerson;
			}
			public Game_DeskType(PrimaryKeys __pk, int GameID, int NumPerson)
			{
				__PKs = __pk;
				__________GameID = GameID;
				__________NumPerson = NumPerson;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_DeskType __oo)
			{
				__oo.DeskTypeID = this.DeskTypeID;
				__oo.GameID = this.GameID;
				__oo.NumPerson = this.NumPerson;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_DeskType __oo)
			{
				this.DeskTypeID = __oo.DeskTypeID;
				this.GameID = __oo.GameID;
				this.NumPerson = __oo.NumPerson;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_DeskType Copy()
			{
				Game_DeskType __oo = new Game_DeskType();
				__oo.DeskTypeID = this.DeskTypeID;
				__oo.GameID = this.GameID;
				__oo.NumPerson = this.NumPerson;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_DeskType __o)
			{
				if (this == __o) return true;
				if (
					this.DeskTypeID == __o.DeskTypeID
					&& this.GameID == __o.GameID
					&& this.NumPerson == __o.NumPerson
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskTypeID
			{
				get { return __PKs.DeskTypeID; }
				set { __PKs.DeskTypeID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int GameID
			{
				get { return __________GameID; }
				set { __________GameID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int NumPerson
			{
				get { return __________NumPerson; }
				set { __________NumPerson = value; }
			}
		}

		[Serializable]
		public partial class Game_DeskTypeCollection : List<Game_DeskType>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_DeskType Add(int DeskTypeID, int GameID, int NumPerson)
			{
				Game_DeskType o = new Game_DeskType(DeskTypeID, GameID, NumPerson);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_DeskTypeCollection __os)
			{
				int i = 0;
				foreach (Game_DeskType __o in __os)
				{
					Game_DeskType __oo = this.Find(new Predicate<Game_DeskType>(delegate(Game_DeskType _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_DeskTypeCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_DeskTypeCollection Rows;
		}

		#endregion

		#region Game_DeskTypeProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_DeskTypeProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：DeskTypeProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________DeskTypeID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int DeskTypeID
				{
					get { return __________DeskTypeID; }
					set { __________DeskTypeID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int DeskTypeID, string Key)
				{
					__________DeskTypeID = DeskTypeID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________DeskTypeID == other.DeskTypeID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：DeskTypeProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：DeskTypeProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskTypeProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_DeskTypeProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_DeskTypeProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_DeskTypeProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_DeskTypeProfile(int DeskTypeID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(DeskTypeID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public Game_DeskTypeProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_DeskTypeProfile __oo)
			{
				__oo.DeskTypeID = this.DeskTypeID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_DeskTypeProfile __oo)
			{
				this.DeskTypeID = __oo.DeskTypeID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_DeskTypeProfile Copy()
			{
				Game_DeskTypeProfile __oo = new Game_DeskTypeProfile();
				__oo.DeskTypeID = this.DeskTypeID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_DeskTypeProfile __o)
			{
				if (this == __o) return true;
				if (
					this.DeskTypeID == __o.DeskTypeID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskTypeID
			{
				get { return __PKs.DeskTypeID; }
				set { __PKs.DeskTypeID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_DeskTypeProfileCollection : List<Game_DeskTypeProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_DeskTypeProfile Add(int DeskTypeID, string Key, object Value, object DefaultValue, string Description)
			{
				Game_DeskTypeProfile o = new Game_DeskTypeProfile(DeskTypeID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_DeskTypeProfileCollection __os)
			{
				int i = 0;
				foreach (Game_DeskTypeProfile __o in __os)
				{
					Game_DeskTypeProfile __oo = this.Find(new Predicate<Game_DeskTypeProfile>(delegate(Game_DeskTypeProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_DeskTypeProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_DeskTypeProfileCollection Rows;
		}

		#endregion

		#region Game_Game

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_Game
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Game 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________GameID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int GameID
				{
					get { return __________GameID; }
					set { __________GameID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int GameID)
				{
					__________GameID = GameID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________GameID == other.GameID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Game 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Game 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Game other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Game.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected System.DateTime __________CreateTime;
			protected string __________Name;
			protected int __________Version;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_Game()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_Game(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_Game(int GameID, System.DateTime CreateTime, string Name, int Version, string Description)
			{
				__PKs = new PrimaryKeys(GameID);
				__________CreateTime = CreateTime;
				__________Name = Name;
				__________Version = Version;
				__________Description = Description;
			}
			public Game_Game(PrimaryKeys __pk, System.DateTime CreateTime, string Name, int Version, string Description)
			{
				__PKs = __pk;
				__________CreateTime = CreateTime;
				__________Name = Name;
				__________Version = Version;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_Game __oo)
			{
				__oo.GameID = this.GameID;
				__oo.CreateTime = this.CreateTime;
				__oo.Name = this.Name;
				__oo.Version = this.Version;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_Game __oo)
			{
				this.GameID = __oo.GameID;
				this.CreateTime = __oo.CreateTime;
				this.Name = __oo.Name;
				this.Version = __oo.Version;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_Game Copy()
			{
				Game_Game __oo = new Game_Game();
				__oo.GameID = this.GameID;
				__oo.CreateTime = this.CreateTime;
				__oo.Name = this.Name;
				__oo.Version = this.Version;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_Game __o)
			{
				if (this == __o) return true;
				if (
					this.GameID == __o.GameID
					&& this.CreateTime == __o.CreateTime
					&& this.Name == __o.Name
					&& this.Version == __o.Version
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int GameID
			{
				get { return __PKs.GameID; }
				set { __PKs.GameID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Version
			{
				get { return __________Version; }
				set { __________Version = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_GameCollection : List<Game_Game>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_Game Add(int GameID, System.DateTime CreateTime, string Name, int Version, string Description)
			{
				Game_Game o = new Game_Game(GameID, CreateTime, Name, Version, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_GameCollection __os)
			{
				int i = 0;
				foreach (Game_Game __o in __os)
				{
					Game_Game __oo = this.Find(new Predicate<Game_Game>(delegate(Game_Game _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_GameCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_GameCollection Rows;
		}

		#endregion

		#region Game_GameProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_GameProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：GameProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________GameID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int GameID
				{
					get { return __________GameID; }
					set { __________GameID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int GameID, string Key)
				{
					__________GameID = GameID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________GameID == other.GameID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：GameProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：GameProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_GameProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_GameProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_GameProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_GameProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_GameProfile(int GameID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(GameID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public Game_GameProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_GameProfile __oo)
			{
				__oo.GameID = this.GameID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_GameProfile __oo)
			{
				this.GameID = __oo.GameID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_GameProfile Copy()
			{
				Game_GameProfile __oo = new Game_GameProfile();
				__oo.GameID = this.GameID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_GameProfile __o)
			{
				if (this == __o) return true;
				if (
					this.GameID == __o.GameID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int GameID
			{
				get { return __PKs.GameID; }
				set { __PKs.GameID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_GameProfileCollection : List<Game_GameProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_GameProfile Add(int GameID, string Key, object Value, object DefaultValue, string Description)
			{
				Game_GameProfile o = new Game_GameProfile(GameID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_GameProfileCollection __os)
			{
				int i = 0;
				foreach (Game_GameProfile __o in __os)
				{
					Game_GameProfile __oo = this.Find(new Predicate<Game_GameProfile>(delegate(Game_GameProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_GameProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_GameProfileCollection Rows;
		}

		#endregion

		#region Game_Lobby

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_Lobby
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Lobby 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________LobbyID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int LobbyID
				{
					get { return __________LobbyID; }
					set { __________LobbyID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int LobbyID)
				{
					__________LobbyID = LobbyID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________LobbyID == other.LobbyID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Lobby 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Lobby 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Lobby other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Lobby.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int? __________ParentLobbyID;
			protected string __________Name;
			protected string __________Description;
			protected int __________Version;
			protected System.DateTime __________CreateTime;

			#endregion

			#region 构造函数

			public Game_Lobby()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_Lobby(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_Lobby(int? ParentLobbyID, int LobbyID, string Name, string Description, int Version, System.DateTime CreateTime)
			{
				__PKs = new PrimaryKeys(LobbyID);
				__________ParentLobbyID = ParentLobbyID;
				__________Name = Name;
				__________Description = Description;
				__________Version = Version;
				__________CreateTime = CreateTime;
			}
			public Game_Lobby(PrimaryKeys __pk, int? ParentLobbyID, string Name, string Description, int Version, System.DateTime CreateTime)
			{
				__PKs = __pk;
				__________ParentLobbyID = ParentLobbyID;
				__________Name = Name;
				__________Description = Description;
				__________Version = Version;
				__________CreateTime = CreateTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_Lobby __oo)
			{
				__oo.ParentLobbyID = this.ParentLobbyID;
				__oo.LobbyID = this.LobbyID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				__oo.Version = this.Version;
				__oo.CreateTime = this.CreateTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_Lobby __oo)
			{
				this.ParentLobbyID = __oo.ParentLobbyID;
				this.LobbyID = __oo.LobbyID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
				this.Version = __oo.Version;
				this.CreateTime = __oo.CreateTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_Lobby Copy()
			{
				Game_Lobby __oo = new Game_Lobby();
				__oo.ParentLobbyID = this.ParentLobbyID;
				__oo.LobbyID = this.LobbyID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				__oo.Version = this.Version;
				__oo.CreateTime = this.CreateTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_Lobby __o)
			{
				if (this == __o) return true;
				if (
					this.ParentLobbyID == __o.ParentLobbyID
					&& this.LobbyID == __o.LobbyID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
					&& this.Version == __o.Version
					&& this.CreateTime == __o.CreateTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int? ParentLobbyID
			{
				get { return __________ParentLobbyID; }
				set { __________ParentLobbyID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int LobbyID
			{
				get { return __PKs.LobbyID; }
				set { __PKs.LobbyID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Version
			{
				get { return __________Version; }
				set { __________Version = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
		}

		[Serializable]
		public partial class Game_LobbyCollection : List<Game_Lobby>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_Lobby Add(int? ParentLobbyID, int LobbyID, string Name, string Description, int Version, System.DateTime CreateTime)
			{
				Game_Lobby o = new Game_Lobby(ParentLobbyID, LobbyID, Name, Description, Version, CreateTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_LobbyCollection __os)
			{
				int i = 0;
				foreach (Game_Lobby __o in __os)
				{
					Game_Lobby __oo = this.Find(new Predicate<Game_Lobby>(delegate(Game_Lobby _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_LobbyCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_LobbyCollection Rows;
		}

		#endregion

		#region Game_LobbyProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_LobbyProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：LobbyProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________LobbyID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int LobbyID
				{
					get { return __________LobbyID; }
					set { __________LobbyID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int LobbyID, string Key)
				{
					__________LobbyID = LobbyID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________LobbyID == other.LobbyID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：LobbyProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：LobbyProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_LobbyProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_LobbyProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_LobbyProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_LobbyProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_LobbyProfile(int LobbyID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(LobbyID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public Game_LobbyProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_LobbyProfile __oo)
			{
				__oo.LobbyID = this.LobbyID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_LobbyProfile __oo)
			{
				this.LobbyID = __oo.LobbyID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_LobbyProfile Copy()
			{
				Game_LobbyProfile __oo = new Game_LobbyProfile();
				__oo.LobbyID = this.LobbyID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_LobbyProfile __o)
			{
				if (this == __o) return true;
				if (
					this.LobbyID == __o.LobbyID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int LobbyID
			{
				get { return __PKs.LobbyID; }
				set { __PKs.LobbyID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_LobbyProfileCollection : List<Game_LobbyProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_LobbyProfile Add(int LobbyID, string Key, object Value, object DefaultValue, string Description)
			{
				Game_LobbyProfile o = new Game_LobbyProfile(LobbyID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_LobbyProfileCollection __os)
			{
				int i = 0;
				foreach (Game_LobbyProfile __o in __os)
				{
					Game_LobbyProfile __oo = this.Find(new Predicate<Game_LobbyProfile>(delegate(Game_LobbyProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_LobbyProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_LobbyProfileCollection Rows;
		}

		#endregion

		#region Game_Seat

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_Seat
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Seat 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________SeatID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int SeatID
				{
					get { return __________SeatID; }
					set { __________SeatID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int SeatID)
				{
					__________SeatID = SeatID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________SeatID == other.SeatID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Seat 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Seat 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Seat other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_Seat.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________DeskID;
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_Seat()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_Seat(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_Seat(int DeskID, int SeatID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(SeatID);
				__________DeskID = DeskID;
				__________Name = Name;
				__________Description = Description;
			}
			public Game_Seat(PrimaryKeys __pk, int DeskID, string Name, string Description)
			{
				__PKs = __pk;
				__________DeskID = DeskID;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_Seat __oo)
			{
				__oo.DeskID = this.DeskID;
				__oo.SeatID = this.SeatID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_Seat __oo)
			{
				this.DeskID = __oo.DeskID;
				this.SeatID = __oo.SeatID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_Seat Copy()
			{
				Game_Seat __oo = new Game_Seat();
				__oo.DeskID = this.DeskID;
				__oo.SeatID = this.SeatID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_Seat __o)
			{
				if (this == __o) return true;
				if (
					this.DeskID == __o.DeskID
					&& this.SeatID == __o.SeatID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskID
			{
				get { return __________DeskID; }
				set { __________DeskID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int SeatID
			{
				get { return __PKs.SeatID; }
				set { __PKs.SeatID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_SeatCollection : List<Game_Seat>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_Seat Add(int DeskID, int SeatID, string Name, string Description)
			{
				Game_Seat o = new Game_Seat(DeskID, SeatID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_SeatCollection __os)
			{
				int i = 0;
				foreach (Game_Seat __o in __os)
				{
					Game_Seat __oo = this.Find(new Predicate<Game_Seat>(delegate(Game_Seat _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_SeatCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_SeatCollection Rows;
		}

		#endregion

		#region Game_SeatProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class Game_SeatProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：SeatProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________SeatID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int SeatID
				{
					get { return __________SeatID; }
					set { __________SeatID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int SeatID, string Key)
				{
					__________SeatID = SeatID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________SeatID == other.SeatID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：SeatProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：SeatProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_SeatProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(Game_SeatProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public Game_SeatProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public Game_SeatProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public Game_SeatProfile(int SeatID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(SeatID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public Game_SeatProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(Game_SeatProfile __oo)
			{
				__oo.SeatID = this.SeatID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(Game_SeatProfile __oo)
			{
				this.SeatID = __oo.SeatID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual Game_SeatProfile Copy()
			{
				Game_SeatProfile __oo = new Game_SeatProfile();
				__oo.SeatID = this.SeatID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(Game_SeatProfile __o)
			{
				if (this == __o) return true;
				if (
					this.SeatID == __o.SeatID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int SeatID
			{
				get { return __PKs.SeatID; }
				set { __PKs.SeatID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class Game_SeatProfileCollection : List<Game_SeatProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public Game_SeatProfile Add(int SeatID, string Key, object Value, object DefaultValue, string Description)
			{
				Game_SeatProfile o = new Game_SeatProfile(SeatID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(Game_SeatProfileCollection __os)
			{
				int i = 0;
				foreach (Game_SeatProfile __o in __os)
				{
					Game_SeatProfile __oo = this.Find(new Predicate<Game_SeatProfile>(delegate(Game_SeatProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class Game_SeatProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public Game_SeatProfileCollection Rows;
		}

		#endregion

		#region System_DataType

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_DataType
		{
			#region 主键组类定义

			/// <summary>
			/// 表：DataType 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________DataTypeID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int DataTypeID
				{
					get { return __________DataTypeID; }
					set { __________DataTypeID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int DataTypeID)
				{
					__________DataTypeID = DataTypeID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________DataTypeID == other.DataTypeID;
				}

				#endregion
			}

			/// <summary>
			/// 表：DataType 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：DataType 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_DataType other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_DataType.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_DataType()
			{
				__PKs = new PrimaryKeys();
			}
			public System_DataType(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_DataType(int DataTypeID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(DataTypeID);
				__________Name = Name;
				__________Description = Description;
			}
			public System_DataType(PrimaryKeys __pk, string Name, string Description)
			{
				__PKs = __pk;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_DataType __oo)
			{
				__oo.DataTypeID = this.DataTypeID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_DataType __oo)
			{
				this.DataTypeID = __oo.DataTypeID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_DataType Copy()
			{
				System_DataType __oo = new System_DataType();
				__oo.DataTypeID = this.DataTypeID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_DataType __o)
			{
				if (this == __o) return true;
				if (
					this.DataTypeID == __o.DataTypeID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DataTypeID
			{
				get { return __PKs.DataTypeID; }
				set { __PKs.DataTypeID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_DataTypeCollection : List<System_DataType>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_DataType Add(int DataTypeID, string Name, string Description)
			{
				System_DataType o = new System_DataType(DataTypeID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_DataTypeCollection __os)
			{
				int i = 0;
				foreach (System_DataType __o in __os)
				{
					System_DataType __oo = this.Find(new Predicate<System_DataType>(delegate(System_DataType _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_DataTypeCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_DataTypeCollection Rows;
		}

		#endregion

		#region System_DialogResource

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_DialogResource
		{
			#region 主键组类定义

			/// <summary>
			/// 表：DialogResource 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(string Key)
				{
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：DialogResource 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：DialogResource 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_DialogResource other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_DialogResource.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________ENG;
			protected string __________CHS;
			protected string __________CHT;

			#endregion

			#region 构造函数

			public System_DialogResource()
			{
				__PKs = new PrimaryKeys();
			}
			public System_DialogResource(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_DialogResource(string Key, string ENG, string CHS, string CHT)
			{
				__PKs = new PrimaryKeys(Key);
				__________ENG = ENG;
				__________CHS = CHS;
				__________CHT = CHT;
			}
			public System_DialogResource(PrimaryKeys __pk, string ENG, string CHS, string CHT)
			{
				__PKs = __pk;
				__________ENG = ENG;
				__________CHS = CHS;
				__________CHT = CHT;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_DialogResource __oo)
			{
				__oo.Key = this.Key;
				__oo.ENG = this.ENG;
				__oo.CHS = this.CHS;
				__oo.CHT = this.CHT;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_DialogResource __oo)
			{
				this.Key = __oo.Key;
				this.ENG = __oo.ENG;
				this.CHS = __oo.CHS;
				this.CHT = __oo.CHT;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_DialogResource Copy()
			{
				System_DialogResource __oo = new System_DialogResource();
				__oo.Key = this.Key;
				__oo.ENG = this.ENG;
				__oo.CHS = this.CHS;
				__oo.CHT = this.CHT;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_DialogResource __o)
			{
				if (this == __o) return true;
				if (
					this.Key == __o.Key
					&& this.ENG == __o.ENG
					&& this.CHS == __o.CHS
					&& this.CHT == __o.CHT
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string ENG
			{
				get { return __________ENG; }
				set { __________ENG = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string CHS
			{
				get { return __________CHS; }
				set { __________CHS = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string CHT
			{
				get { return __________CHT; }
				set { __________CHT = value; }
			}
		}

		[Serializable]
		public partial class System_DialogResourceCollection : List<System_DialogResource>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_DialogResource Add(string Key, string ENG, string CHS, string CHT)
			{
				System_DialogResource o = new System_DialogResource(Key, ENG, CHS, CHT);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_DialogResourceCollection __os)
			{
				int i = 0;
				foreach (System_DialogResource __o in __os)
				{
					System_DialogResource __oo = this.Find(new Predicate<System_DialogResource>(delegate(System_DialogResource _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_DialogResourceCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_DialogResourceCollection Rows;
		}

		#endregion

		#region System_Service

		/// <summary>
		/// 服务
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_Service
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Service 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceID;
			/// <summary>
			/// 服务编号
			/// </summary>
				[DataMember]
				public int ServiceID
				{
					get { return __________ServiceID; }
					set { __________ServiceID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceID)
				{
					__________ServiceID = ServiceID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceID == other.ServiceID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Service 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Service 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_Service other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_Service.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________ServiceTypeID;
			protected System.DateTime __________CreateTime;
			protected string __________Name;
			protected int __________Version;
			protected string __________FilePath;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_Service()
			{
				__PKs = new PrimaryKeys();
			}
			public System_Service(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_Service(int ServiceTypeID, int ServiceID, System.DateTime CreateTime, string Name, int Version, string FilePath, string Description)
			{
				__PKs = new PrimaryKeys(ServiceID);
				__________ServiceTypeID = ServiceTypeID;
				__________CreateTime = CreateTime;
				__________Name = Name;
				__________Version = Version;
				__________FilePath = FilePath;
				__________Description = Description;
			}
			public System_Service(PrimaryKeys __pk, int ServiceTypeID, System.DateTime CreateTime, string Name, int Version, string FilePath, string Description)
			{
				__PKs = __pk;
				__________ServiceTypeID = ServiceTypeID;
				__________CreateTime = CreateTime;
				__________Name = Name;
				__________Version = Version;
				__________FilePath = FilePath;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_Service __oo)
			{
				__oo.ServiceTypeID = this.ServiceTypeID;
				__oo.ServiceID = this.ServiceID;
				__oo.CreateTime = this.CreateTime;
				__oo.Name = this.Name;
				__oo.Version = this.Version;
				__oo.FilePath = this.FilePath;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_Service __oo)
			{
				this.ServiceTypeID = __oo.ServiceTypeID;
				this.ServiceID = __oo.ServiceID;
				this.CreateTime = __oo.CreateTime;
				this.Name = __oo.Name;
				this.Version = __oo.Version;
				this.FilePath = __oo.FilePath;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_Service Copy()
			{
				System_Service __oo = new System_Service();
				__oo.ServiceTypeID = this.ServiceTypeID;
				__oo.ServiceID = this.ServiceID;
				__oo.CreateTime = this.CreateTime;
				__oo.Name = this.Name;
				__oo.Version = this.Version;
				__oo.FilePath = this.FilePath;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_Service __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceTypeID == __o.ServiceTypeID
					&& this.ServiceID == __o.ServiceID
					&& this.CreateTime == __o.CreateTime
					&& this.Name == __o.Name
					&& this.Version == __o.Version
					&& this.FilePath == __o.FilePath
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 服务类别编号
			/// </summary>
			[DataMember]
			public int ServiceTypeID
			{
				get { return __________ServiceTypeID; }
				set { __________ServiceTypeID = value; }
			}
			/// <summary>
			/// 服务编号
			/// </summary>
			[DataMember]
			public int ServiceID
			{
				get { return __PKs.ServiceID; }
				set { __PKs.ServiceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
			/// <summary>
			/// 服务名
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 版本号
			/// </summary>
			[DataMember]
			public int Version
			{
				get { return __________Version; }
				set { __________Version = value; }
			}
			/// <summary>
			/// 所在网络全路径
			/// </summary>
			[DataMember]
			public string FilePath
			{
				get { return __________FilePath; }
				set { __________FilePath = value; }
			}
			/// <summary>
			/// 备注
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceCollection : List<System_Service>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_Service Add(int ServiceTypeID, int ServiceID, System.DateTime CreateTime, string Name, int Version, string FilePath, string Description)
			{
				System_Service o = new System_Service(ServiceTypeID, ServiceID, CreateTime, Name, Version, FilePath, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceCollection __os)
			{
				int i = 0;
				foreach (System_Service __o in __os)
				{
					System_Service __oo = this.Find(new Predicate<System_Service>(delegate(System_Service _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceCollection Rows;
		}

		#endregion

		#region System_ServiceInstance

		/// <summary>
		/// 服务配置
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceInstance
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceInstance 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceID;
			/// <summary>
			/// 服务配置编号
			/// </summary>
				[DataMember]
				public int ServiceInstanceID
				{
					get { return __________ServiceInstanceID; }
					set { __________ServiceInstanceID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceID)
				{
					__________ServiceInstanceID = ServiceInstanceID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceID == other.ServiceInstanceID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceInstance 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceInstance 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstance other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstance.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________ServiceID;
			protected System.DateTime __________CreateTime;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_ServiceInstance()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceInstance(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceInstance(int ServiceID, int ServiceInstanceID, System.DateTime CreateTime, string Description)
			{
				__PKs = new PrimaryKeys(ServiceInstanceID);
				__________ServiceID = ServiceID;
				__________CreateTime = CreateTime;
				__________Description = Description;
			}
			public System_ServiceInstance(PrimaryKeys __pk, int ServiceID, System.DateTime CreateTime, string Description)
			{
				__PKs = __pk;
				__________ServiceID = ServiceID;
				__________CreateTime = CreateTime;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceInstance __oo)
			{
				__oo.ServiceID = this.ServiceID;
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.CreateTime = this.CreateTime;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceInstance __oo)
			{
				this.ServiceID = __oo.ServiceID;
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.CreateTime = __oo.CreateTime;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceInstance Copy()
			{
				System_ServiceInstance __oo = new System_ServiceInstance();
				__oo.ServiceID = this.ServiceID;
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.CreateTime = this.CreateTime;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceInstance __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceID == __o.ServiceID
					&& this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.CreateTime == __o.CreateTime
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 服务编号
			/// </summary>
			[DataMember]
			public int ServiceID
			{
				get { return __________ServiceID; }
				set { __________ServiceID = value; }
			}
			/// <summary>
			/// 服务配置编号
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __PKs.ServiceInstanceID; }
				set { __PKs.ServiceInstanceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceInstanceCollection : List<System_ServiceInstance>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceInstance Add(int ServiceID, int ServiceInstanceID, System.DateTime CreateTime, string Description)
			{
				System_ServiceInstance o = new System_ServiceInstance(ServiceID, ServiceInstanceID, CreateTime, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceInstanceCollection __os)
			{
				int i = 0;
				foreach (System_ServiceInstance __o in __os)
				{
					System_ServiceInstance __oo = this.Find(new Predicate<System_ServiceInstance>(delegate(System_ServiceInstance _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceInstanceCollection Rows;
		}

		#endregion

		#region System_ServiceInstance_NamedPipe

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceInstance_NamedPipe
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceInstance_NamedPipe 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ServiceInstanceID
				{
					get { return __________ServiceInstanceID; }
					set { __________ServiceInstanceID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceID)
				{
					__________ServiceInstanceID = ServiceInstanceID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceID == other.ServiceInstanceID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceInstance_NamedPipe 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceInstance_NamedPipe 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstance_NamedPipe other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstance_NamedPipe.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________Address;

			#endregion

			#region 构造函数

			public System_ServiceInstance_NamedPipe()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceInstance_NamedPipe(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceInstance_NamedPipe(int ServiceInstanceID, string Address)
			{
				__PKs = new PrimaryKeys(ServiceInstanceID);
				__________Address = Address;
			}
			public System_ServiceInstance_NamedPipe(PrimaryKeys __pk, string Address)
			{
				__PKs = __pk;
				__________Address = Address;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceInstance_NamedPipe __oo)
			{
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.Address = this.Address;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceInstance_NamedPipe __oo)
			{
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.Address = __oo.Address;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceInstance_NamedPipe Copy()
			{
				System_ServiceInstance_NamedPipe __oo = new System_ServiceInstance_NamedPipe();
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.Address = this.Address;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceInstance_NamedPipe __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.Address == __o.Address
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __PKs.ServiceInstanceID; }
				set { __PKs.ServiceInstanceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Address
			{
				get { return __________Address; }
				set { __________Address = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceInstance_NamedPipeCollection : List<System_ServiceInstance_NamedPipe>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceInstance_NamedPipe Add(int ServiceInstanceID, string Address)
			{
				System_ServiceInstance_NamedPipe o = new System_ServiceInstance_NamedPipe(ServiceInstanceID, Address);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceInstance_NamedPipeCollection __os)
			{
				int i = 0;
				foreach (System_ServiceInstance_NamedPipe __o in __os)
				{
					System_ServiceInstance_NamedPipe __oo = this.Find(new Predicate<System_ServiceInstance_NamedPipe>(delegate(System_ServiceInstance_NamedPipe _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceInstance_NamedPipeCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceInstance_NamedPipeCollection Rows;
		}

		#endregion

		#region System_ServiceInstance_TCPIP

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceInstance_TCPIP
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceInstance_TCPIP 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ServiceInstanceID
				{
					get { return __________ServiceInstanceID; }
					set { __________ServiceInstanceID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceID)
				{
					__________ServiceInstanceID = ServiceInstanceID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceID == other.ServiceInstanceID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceInstance_TCPIP 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceInstance_TCPIP 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstance_TCPIP other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstance_TCPIP.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________IP;
			protected int __________Port;
			protected string __________Address;
			protected int __________MaxReceivedBufferSize;
			protected int __________etc___;

			#endregion

			#region 构造函数

			public System_ServiceInstance_TCPIP()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceInstance_TCPIP(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceInstance_TCPIP(int ServiceInstanceID, int IP, int Port, string Address, int MaxReceivedBufferSize, int etc___)
			{
				__PKs = new PrimaryKeys(ServiceInstanceID);
				__________IP = IP;
				__________Port = Port;
				__________Address = Address;
				__________MaxReceivedBufferSize = MaxReceivedBufferSize;
				__________etc___ = etc___;
			}
			public System_ServiceInstance_TCPIP(PrimaryKeys __pk, int IP, int Port, string Address, int MaxReceivedBufferSize, int etc___)
			{
				__PKs = __pk;
				__________IP = IP;
				__________Port = Port;
				__________Address = Address;
				__________MaxReceivedBufferSize = MaxReceivedBufferSize;
				__________etc___ = etc___;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceInstance_TCPIP __oo)
			{
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.IP = this.IP;
				__oo.Port = this.Port;
				__oo.Address = this.Address;
				__oo.MaxReceivedBufferSize = this.MaxReceivedBufferSize;
				__oo.etc___ = this.etc___;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceInstance_TCPIP __oo)
			{
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.IP = __oo.IP;
				this.Port = __oo.Port;
				this.Address = __oo.Address;
				this.MaxReceivedBufferSize = __oo.MaxReceivedBufferSize;
				this.etc___ = __oo.etc___;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceInstance_TCPIP Copy()
			{
				System_ServiceInstance_TCPIP __oo = new System_ServiceInstance_TCPIP();
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.IP = this.IP;
				__oo.Port = this.Port;
				__oo.Address = this.Address;
				__oo.MaxReceivedBufferSize = this.MaxReceivedBufferSize;
				__oo.etc___ = this.etc___;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceInstance_TCPIP __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.IP == __o.IP
					&& this.Port == __o.Port
					&& this.Address == __o.Address
					&& this.MaxReceivedBufferSize == __o.MaxReceivedBufferSize
					&& this.etc___ == __o.etc___
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __PKs.ServiceInstanceID; }
				set { __PKs.ServiceInstanceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int IP
			{
				get { return __________IP; }
				set { __________IP = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Port
			{
				get { return __________Port; }
				set { __________Port = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Address
			{
				get { return __________Address; }
				set { __________Address = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int MaxReceivedBufferSize
			{
				get { return __________MaxReceivedBufferSize; }
				set { __________MaxReceivedBufferSize = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int etc___
			{
				get { return __________etc___; }
				set { __________etc___ = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceInstance_TCPIPCollection : List<System_ServiceInstance_TCPIP>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceInstance_TCPIP Add(int ServiceInstanceID, int IP, int Port, string Address, int MaxReceivedBufferSize, int etc___)
			{
				System_ServiceInstance_TCPIP o = new System_ServiceInstance_TCPIP(ServiceInstanceID, IP, Port, Address, MaxReceivedBufferSize, etc___);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceInstance_TCPIPCollection __os)
			{
				int i = 0;
				foreach (System_ServiceInstance_TCPIP __o in __os)
				{
					System_ServiceInstance_TCPIP __oo = this.Find(new Predicate<System_ServiceInstance_TCPIP>(delegate(System_ServiceInstance_TCPIP _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceInstance_TCPIPCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceInstance_TCPIPCollection Rows;
		}

		#endregion

		#region System_ServiceInstanceProfile

		/// <summary>
		/// 服务配置附加信息
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceInstanceProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ServiceInstanceID
				{
					get { return __________ServiceInstanceID; }
					set { __________ServiceInstanceID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceID, string Key)
				{
					__________ServiceInstanceID = ServiceInstanceID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceID == other.ServiceInstanceID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceInstanceProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceInstanceProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstanceProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstanceProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_ServiceInstanceProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceInstanceProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceInstanceProfile(int ServiceInstanceID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(ServiceInstanceID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public System_ServiceInstanceProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceInstanceProfile __oo)
			{
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceInstanceProfile __oo)
			{
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceInstanceProfile Copy()
			{
				System_ServiceInstanceProfile __oo = new System_ServiceInstanceProfile();
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceInstanceProfile __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __PKs.ServiceInstanceID; }
				set { __PKs.ServiceInstanceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceInstanceProfileCollection : List<System_ServiceInstanceProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceInstanceProfile Add(int ServiceInstanceID, string Key, object Value, object DefaultValue, string Description)
			{
				System_ServiceInstanceProfile o = new System_ServiceInstanceProfile(ServiceInstanceID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceInstanceProfileCollection __os)
			{
				int i = 0;
				foreach (System_ServiceInstanceProfile __o in __os)
				{
					System_ServiceInstanceProfile __oo = this.Find(new Predicate<System_ServiceInstanceProfile>(delegate(System_ServiceInstanceProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceInstanceProfileCollection Rows;
		}

		#endregion

		#region System_ServiceInstanceState

		/// <summary>
		/// 服务运行状态
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceState
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceInstanceState 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceID;
			/// <summary>
			/// 服务配置编号
			/// </summary>
				[DataMember]
				public int ServiceInstanceID
				{
					get { return __________ServiceInstanceID; }
					set { __________ServiceInstanceID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceID)
				{
					__________ServiceInstanceID = ServiceInstanceID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceID == other.ServiceInstanceID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceInstanceState 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceInstanceState 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstanceState other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstanceState.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________ServiceStateTypeID;
			protected System.DateTime __________BeginTime;

			#endregion

			#region 构造函数

			public System_ServiceInstanceState()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceInstanceState(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceInstanceState(int ServiceStateTypeID, int ServiceInstanceID, System.DateTime BeginTime)
			{
				__PKs = new PrimaryKeys(ServiceInstanceID);
				__________ServiceStateTypeID = ServiceStateTypeID;
				__________BeginTime = BeginTime;
			}
			public System_ServiceInstanceState(PrimaryKeys __pk, int ServiceStateTypeID, System.DateTime BeginTime)
			{
				__PKs = __pk;
				__________ServiceStateTypeID = ServiceStateTypeID;
				__________BeginTime = BeginTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceInstanceState __oo)
			{
				__oo.ServiceStateTypeID = this.ServiceStateTypeID;
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.BeginTime = this.BeginTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceInstanceState __oo)
			{
				this.ServiceStateTypeID = __oo.ServiceStateTypeID;
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.BeginTime = __oo.BeginTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceInstanceState Copy()
			{
				System_ServiceInstanceState __oo = new System_ServiceInstanceState();
				__oo.ServiceStateTypeID = this.ServiceStateTypeID;
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.BeginTime = this.BeginTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceInstanceState __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceStateTypeID == __o.ServiceStateTypeID
					&& this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.BeginTime == __o.BeginTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 服务运行状态类型编号
			/// </summary>
			[DataMember]
			public int ServiceStateTypeID
			{
				get { return __________ServiceStateTypeID; }
				set { __________ServiceStateTypeID = value; }
			}
			/// <summary>
			/// 服务配置编号
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __PKs.ServiceInstanceID; }
				set { __PKs.ServiceInstanceID = value; }
			}
			/// <summary>
			/// 状态开始时间
			/// </summary>
			[DataMember]
			public System.DateTime BeginTime
			{
				get { return __________BeginTime; }
				set { __________BeginTime = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceInstanceStateCollection : List<System_ServiceInstanceState>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceInstanceState Add(int ServiceStateTypeID, int ServiceInstanceID, System.DateTime BeginTime)
			{
				System_ServiceInstanceState o = new System_ServiceInstanceState(ServiceStateTypeID, ServiceInstanceID, BeginTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceInstanceStateCollection __os)
			{
				int i = 0;
				foreach (System_ServiceInstanceState __o in __os)
				{
					System_ServiceInstanceState __oo = this.Find(new Predicate<System_ServiceInstanceState>(delegate(System_ServiceInstanceState _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceStateCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceInstanceStateCollection Rows;
		}

		#endregion

		#region System_ServiceInstanceStateLog

		/// <summary>
		/// 服务运行状态日志
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceStateLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceInstanceStateLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceStateLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ServiceInstanceStateLogID
				{
					get { return __________ServiceInstanceStateLogID; }
					set { __________ServiceInstanceStateLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceStateLogID)
				{
					__________ServiceInstanceStateLogID = ServiceInstanceStateLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceStateLogID == other.ServiceInstanceStateLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceInstanceStateLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceInstanceStateLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstanceStateLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceInstanceStateLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________ServiceStateTypeID;
			protected int __________ServiceInstanceID;
			protected System.DateTime __________BeginTime;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_ServiceInstanceStateLog()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceInstanceStateLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceInstanceStateLog(int ServiceStateTypeID, int ServiceInstanceID, int ServiceInstanceStateLogID, System.DateTime BeginTime, string Description)
			{
				__PKs = new PrimaryKeys(ServiceInstanceStateLogID);
				__________ServiceStateTypeID = ServiceStateTypeID;
				__________ServiceInstanceID = ServiceInstanceID;
				__________BeginTime = BeginTime;
				__________Description = Description;
			}
			public System_ServiceInstanceStateLog(PrimaryKeys __pk, int ServiceStateTypeID, int ServiceInstanceID, System.DateTime BeginTime, string Description)
			{
				__PKs = __pk;
				__________ServiceStateTypeID = ServiceStateTypeID;
				__________ServiceInstanceID = ServiceInstanceID;
				__________BeginTime = BeginTime;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceInstanceStateLog __oo)
			{
				__oo.ServiceStateTypeID = this.ServiceStateTypeID;
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.ServiceInstanceStateLogID = this.ServiceInstanceStateLogID;
				__oo.BeginTime = this.BeginTime;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceInstanceStateLog __oo)
			{
				this.ServiceStateTypeID = __oo.ServiceStateTypeID;
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.ServiceInstanceStateLogID = __oo.ServiceInstanceStateLogID;
				this.BeginTime = __oo.BeginTime;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceInstanceStateLog Copy()
			{
				System_ServiceInstanceStateLog __oo = new System_ServiceInstanceStateLog();
				__oo.ServiceStateTypeID = this.ServiceStateTypeID;
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.ServiceInstanceStateLogID = this.ServiceInstanceStateLogID;
				__oo.BeginTime = this.BeginTime;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceInstanceStateLog __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceStateTypeID == __o.ServiceStateTypeID
					&& this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.ServiceInstanceStateLogID == __o.ServiceInstanceStateLogID
					&& this.BeginTime == __o.BeginTime
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 服务运行状态类型
			/// </summary>
			[DataMember]
			public int ServiceStateTypeID
			{
				get { return __________ServiceStateTypeID; }
				set { __________ServiceStateTypeID = value; }
			}
			/// <summary>
			/// 服务配置编号
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __________ServiceInstanceID; }
				set { __________ServiceInstanceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ServiceInstanceStateLogID
			{
				get { return __PKs.ServiceInstanceStateLogID; }
				set { __PKs.ServiceInstanceStateLogID = value; }
			}
			/// <summary>
			/// 状态开始时间
			/// </summary>
			[DataMember]
			public System.DateTime BeginTime
			{
				get { return __________BeginTime; }
				set { __________BeginTime = value; }
			}
			/// <summary>
			/// 详细说明
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceInstanceStateLogCollection : List<System_ServiceInstanceStateLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceInstanceStateLog Add(int ServiceStateTypeID, int ServiceInstanceID, int ServiceInstanceStateLogID, System.DateTime BeginTime, string Description)
			{
				System_ServiceInstanceStateLog o = new System_ServiceInstanceStateLog(ServiceStateTypeID, ServiceInstanceID, ServiceInstanceStateLogID, BeginTime, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceInstanceStateLogCollection __os)
			{
				int i = 0;
				foreach (System_ServiceInstanceStateLog __o in __os)
				{
					System_ServiceInstanceStateLog __oo = this.Find(new Predicate<System_ServiceInstanceStateLog>(delegate(System_ServiceInstanceStateLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceInstanceStateLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceInstanceStateLogCollection Rows;
		}

		#endregion

		#region System_ServiceProfile

		/// <summary>
		/// 服务附加信息
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ServiceID
				{
					get { return __________ServiceID; }
					set { __________ServiceID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceID, string Key)
				{
					__________ServiceID = ServiceID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceID == other.ServiceID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_ServiceProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceProfile(int ServiceID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(ServiceID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public System_ServiceProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceProfile __oo)
			{
				__oo.ServiceID = this.ServiceID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceProfile __oo)
			{
				this.ServiceID = __oo.ServiceID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceProfile Copy()
			{
				System_ServiceProfile __oo = new System_ServiceProfile();
				__oo.ServiceID = this.ServiceID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceProfile __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceID == __o.ServiceID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ServiceID
			{
				get { return __PKs.ServiceID; }
				set { __PKs.ServiceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceProfileCollection : List<System_ServiceProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceProfile Add(int ServiceID, string Key, object Value, object DefaultValue, string Description)
			{
				System_ServiceProfile o = new System_ServiceProfile(ServiceID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceProfileCollection __os)
			{
				int i = 0;
				foreach (System_ServiceProfile __o in __os)
				{
					System_ServiceProfile __oo = this.Find(new Predicate<System_ServiceProfile>(delegate(System_ServiceProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceProfileCollection Rows;
		}

		#endregion

		#region System_ServiceStateType

		/// <summary>
		/// 服务运行状态类型
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceStateType
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceStateType 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceStateTypeID;
			/// <summary>
			/// 服务状态类型编号
			/// </summary>
				[DataMember]
				public int ServiceStateTypeID
				{
					get { return __________ServiceStateTypeID; }
					set { __________ServiceStateTypeID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceStateTypeID)
				{
					__________ServiceStateTypeID = ServiceStateTypeID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceStateTypeID == other.ServiceStateTypeID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceStateType 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceStateType 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceStateType other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceStateType.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_ServiceStateType()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceStateType(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceStateType(int ServiceStateTypeID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(ServiceStateTypeID);
				__________Name = Name;
				__________Description = Description;
			}
			public System_ServiceStateType(PrimaryKeys __pk, string Name, string Description)
			{
				__PKs = __pk;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceStateType __oo)
			{
				__oo.ServiceStateTypeID = this.ServiceStateTypeID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceStateType __oo)
			{
				this.ServiceStateTypeID = __oo.ServiceStateTypeID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceStateType Copy()
			{
				System_ServiceStateType __oo = new System_ServiceStateType();
				__oo.ServiceStateTypeID = this.ServiceStateTypeID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceStateType __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceStateTypeID == __o.ServiceStateTypeID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 服务状态类型编号
			/// </summary>
			[DataMember]
			public int ServiceStateTypeID
			{
				get { return __PKs.ServiceStateTypeID; }
				set { __PKs.ServiceStateTypeID = value; }
			}
			/// <summary>
			/// 类型名
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 说明
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceStateTypeCollection : List<System_ServiceStateType>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceStateType Add(int ServiceStateTypeID, string Name, string Description)
			{
				System_ServiceStateType o = new System_ServiceStateType(ServiceStateTypeID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceStateTypeCollection __os)
			{
				int i = 0;
				foreach (System_ServiceStateType __o in __os)
				{
					System_ServiceStateType __oo = this.Find(new Predicate<System_ServiceStateType>(delegate(System_ServiceStateType _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceStateTypeCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceStateTypeCollection Rows;
		}

		#endregion

		#region System_ServiceType

		/// <summary>
		/// 服务类别
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_ServiceType
		{
			#region 主键组类定义

			/// <summary>
			/// 表：ServiceType 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceTypeID;
			/// <summary>
			/// 服务类别编号
			/// </summary>
				[DataMember]
				public int ServiceTypeID
				{
					get { return __________ServiceTypeID; }
					set { __________ServiceTypeID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceTypeID)
				{
					__________ServiceTypeID = ServiceTypeID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceTypeID == other.ServiceTypeID;
				}

				#endregion
			}

			/// <summary>
			/// 表：ServiceType 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：ServiceType 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceType other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_ServiceType.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_ServiceType()
			{
				__PKs = new PrimaryKeys();
			}
			public System_ServiceType(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_ServiceType(int ServiceTypeID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(ServiceTypeID);
				__________Name = Name;
				__________Description = Description;
			}
			public System_ServiceType(PrimaryKeys __pk, string Name, string Description)
			{
				__PKs = __pk;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_ServiceType __oo)
			{
				__oo.ServiceTypeID = this.ServiceTypeID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_ServiceType __oo)
			{
				this.ServiceTypeID = __oo.ServiceTypeID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_ServiceType Copy()
			{
				System_ServiceType __oo = new System_ServiceType();
				__oo.ServiceTypeID = this.ServiceTypeID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_ServiceType __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceTypeID == __o.ServiceTypeID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 服务类别编号
			/// </summary>
			[DataMember]
			public int ServiceTypeID
			{
				get { return __PKs.ServiceTypeID; }
				set { __PKs.ServiceTypeID = value; }
			}
			/// <summary>
			/// 类别名
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 备注
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_ServiceTypeCollection : List<System_ServiceType>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_ServiceType Add(int ServiceTypeID, string Name, string Description)
			{
				System_ServiceType o = new System_ServiceType(ServiceTypeID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_ServiceTypeCollection __os)
			{
				int i = 0;
				foreach (System_ServiceType __o in __os)
				{
					System_ServiceType __oo = this.Find(new Predicate<System_ServiceType>(delegate(System_ServiceType _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_ServiceTypeCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_ServiceTypeCollection Rows;
		}

		#endregion

		#region System_Setting

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class System_Setting
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Setting 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(string Key)
				{
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：Setting 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Setting 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_Setting other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(System_Setting.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public System_Setting()
			{
				__PKs = new PrimaryKeys();
			}
			public System_Setting(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public System_Setting(string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public System_Setting(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(System_Setting __oo)
			{
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(System_Setting __oo)
			{
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual System_Setting Copy()
			{
				System_Setting __oo = new System_Setting();
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(System_Setting __o)
			{
				if (this == __o) return true;
				if (
					this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class System_SettingCollection : List<System_Setting>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public System_Setting Add(string Key, object Value, object DefaultValue, string Description)
			{
				System_Setting o = new System_Setting(Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(System_SettingCollection __os)
			{
				int i = 0;
				foreach (System_Setting __o in __os)
				{
					System_Setting __oo = this.Find(new Predicate<System_Setting>(delegate(System_Setting _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class System_SettingCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public System_SettingCollection Rows;
		}

		#endregion

		#region User_Account

		/// <summary>
		/// 用户表
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_Account
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Account 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________AccountID;
			/// <summary>
			/// 用户编号
			/// </summary>
				[DataMember]
				public int AccountID
				{
					get { return __________AccountID; }
					set { __________AccountID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int AccountID)
				{
					__________AccountID = AccountID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________AccountID == other.AccountID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Account 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Account 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Account other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Account.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________Username;
			protected string __________Password;
			protected int __________Gold;
			protected System.DateTime __________CreateTime;
			protected string __________Description;
			protected bool __________IsEnabled;

			#endregion

			#region 构造函数

			public User_Account()
			{
				__PKs = new PrimaryKeys();
			}
			public User_Account(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_Account(int AccountID, string Username, string Password, int Gold, System.DateTime CreateTime, string Description, bool IsEnabled)
			{
				__PKs = new PrimaryKeys(AccountID);
				__________Username = Username;
				__________Password = Password;
				__________Gold = Gold;
				__________CreateTime = CreateTime;
				__________Description = Description;
				__________IsEnabled = IsEnabled;
			}
			public User_Account(PrimaryKeys __pk, string Username, string Password, int Gold, System.DateTime CreateTime, string Description, bool IsEnabled)
			{
				__PKs = __pk;
				__________Username = Username;
				__________Password = Password;
				__________Gold = Gold;
				__________CreateTime = CreateTime;
				__________Description = Description;
				__________IsEnabled = IsEnabled;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_Account __oo)
			{
				__oo.AccountID = this.AccountID;
				__oo.Username = this.Username;
				__oo.Password = this.Password;
				__oo.Gold = this.Gold;
				__oo.CreateTime = this.CreateTime;
				__oo.Description = this.Description;
				__oo.IsEnabled = this.IsEnabled;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_Account __oo)
			{
				this.AccountID = __oo.AccountID;
				this.Username = __oo.Username;
				this.Password = __oo.Password;
				this.Gold = __oo.Gold;
				this.CreateTime = __oo.CreateTime;
				this.Description = __oo.Description;
				this.IsEnabled = __oo.IsEnabled;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_Account Copy()
			{
				User_Account __oo = new User_Account();
				__oo.AccountID = this.AccountID;
				__oo.Username = this.Username;
				__oo.Password = this.Password;
				__oo.Gold = this.Gold;
				__oo.CreateTime = this.CreateTime;
				__oo.Description = this.Description;
				__oo.IsEnabled = this.IsEnabled;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_Account __o)
			{
				if (this == __o) return true;
				if (
					this.AccountID == __o.AccountID
					&& this.Username == __o.Username
					&& this.Password == __o.Password
					&& this.Gold == __o.Gold
					&& this.CreateTime == __o.CreateTime
					&& this.Description == __o.Description
					&& this.IsEnabled == __o.IsEnabled
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 用户编号
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __PKs.AccountID; }
				set { __PKs.AccountID = value; }
			}
			/// <summary>
			/// 用户名
			/// </summary>
			[DataMember]
			public string Username
			{
				get { return __________Username; }
				set { __________Username = value; }
			}
			/// <summary>
			/// 当前密码（明文不加密）
			/// </summary>
			[DataMember]
			public string Password
			{
				get { return __________Password; }
				set { __________Password = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Gold
			{
				get { return __________Gold; }
				set { __________Gold = value; }
			}
			/// <summary>
			/// 账户创建时间
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
			/// <summary>
			/// 备注
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
			/// <summary>
			/// 是否启用
			/// </summary>
			[DataMember]
			public bool IsEnabled
			{
				get { return __________IsEnabled; }
				set { __________IsEnabled = value; }
			}
		}

		[Serializable]
		public partial class User_AccountCollection : List<User_Account>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_Account Add(int AccountID, string Username, string Password, int Gold, System.DateTime CreateTime, string Description, bool IsEnabled)
			{
				User_Account o = new User_Account(AccountID, Username, Password, Gold, CreateTime, Description, IsEnabled);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_AccountCollection __os)
			{
				int i = 0;
				foreach (User_Account __o in __os)
				{
					User_Account __oo = this.Find(new Predicate<User_Account>(delegate(User_Account _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_AccountCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_AccountCollection Rows;
		}

		#endregion

		#region User_Character

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_Character
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Character 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________CharacterID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterID
				{
					get { return __________CharacterID; }
					set { __________CharacterID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int CharacterID)
				{
					__________CharacterID = CharacterID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________CharacterID == other.CharacterID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Character 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Character 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Character other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Character.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________AccountID;
			protected System.DateTime __________CreateTime;
			protected string __________Name;
			protected string __________Description;
			protected bool __________IsDeleted;
			protected bool __________IsEnabled;
			protected int __________Gold;
			protected bool __________IsOnline;
			protected System.Guid __________Ticket;
			protected System.DateTime __________TicketExpireTime;
			protected int __________SeatID;
			protected System.DateTime __________SeatTime;

			#endregion

			#region 构造函数

			public User_Character()
			{
				__PKs = new PrimaryKeys();
			}
			public User_Character(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_Character(int AccountID, int CharacterID, System.DateTime CreateTime, string Name, string Description, bool IsDeleted, bool IsEnabled, int Gold, bool IsOnline, System.Guid Ticket, System.DateTime TicketExpireTime, int SeatID, System.DateTime SeatTime)
			{
				__PKs = new PrimaryKeys(CharacterID);
				__________AccountID = AccountID;
				__________CreateTime = CreateTime;
				__________Name = Name;
				__________Description = Description;
				__________IsDeleted = IsDeleted;
				__________IsEnabled = IsEnabled;
				__________Gold = Gold;
				__________IsOnline = IsOnline;
				__________Ticket = Ticket;
				__________TicketExpireTime = TicketExpireTime;
				__________SeatID = SeatID;
				__________SeatTime = SeatTime;
			}
			public User_Character(PrimaryKeys __pk, int AccountID, System.DateTime CreateTime, string Name, string Description, bool IsDeleted, bool IsEnabled, int Gold, bool IsOnline, System.Guid Ticket, System.DateTime TicketExpireTime, int SeatID, System.DateTime SeatTime)
			{
				__PKs = __pk;
				__________AccountID = AccountID;
				__________CreateTime = CreateTime;
				__________Name = Name;
				__________Description = Description;
				__________IsDeleted = IsDeleted;
				__________IsEnabled = IsEnabled;
				__________Gold = Gold;
				__________IsOnline = IsOnline;
				__________Ticket = Ticket;
				__________TicketExpireTime = TicketExpireTime;
				__________SeatID = SeatID;
				__________SeatTime = SeatTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_Character __oo)
			{
				__oo.AccountID = this.AccountID;
				__oo.CharacterID = this.CharacterID;
				__oo.CreateTime = this.CreateTime;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				__oo.IsDeleted = this.IsDeleted;
				__oo.IsEnabled = this.IsEnabled;
				__oo.Gold = this.Gold;
				__oo.IsOnline = this.IsOnline;
				__oo.Ticket = this.Ticket;
				__oo.TicketExpireTime = this.TicketExpireTime;
				__oo.SeatID = this.SeatID;
				__oo.SeatTime = this.SeatTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_Character __oo)
			{
				this.AccountID = __oo.AccountID;
				this.CharacterID = __oo.CharacterID;
				this.CreateTime = __oo.CreateTime;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
				this.IsDeleted = __oo.IsDeleted;
				this.IsEnabled = __oo.IsEnabled;
				this.Gold = __oo.Gold;
				this.IsOnline = __oo.IsOnline;
				this.Ticket = __oo.Ticket;
				this.TicketExpireTime = __oo.TicketExpireTime;
				this.SeatID = __oo.SeatID;
				this.SeatTime = __oo.SeatTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_Character Copy()
			{
				User_Character __oo = new User_Character();
				__oo.AccountID = this.AccountID;
				__oo.CharacterID = this.CharacterID;
				__oo.CreateTime = this.CreateTime;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				__oo.IsDeleted = this.IsDeleted;
				__oo.IsEnabled = this.IsEnabled;
				__oo.Gold = this.Gold;
				__oo.IsOnline = this.IsOnline;
				__oo.Ticket = this.Ticket;
				__oo.TicketExpireTime = this.TicketExpireTime;
				__oo.SeatID = this.SeatID;
				__oo.SeatTime = this.SeatTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_Character __o)
			{
				if (this == __o) return true;
				if (
					this.AccountID == __o.AccountID
					&& this.CharacterID == __o.CharacterID
					&& this.CreateTime == __o.CreateTime
					&& this.Name == __o.Name
					&& this.Description == __o.Description
					&& this.IsDeleted == __o.IsDeleted
					&& this.IsEnabled == __o.IsEnabled
					&& this.Gold == __o.Gold
					&& this.IsOnline == __o.IsOnline
					&& this.Ticket == __o.Ticket
					&& this.TicketExpireTime == __o.TicketExpireTime
					&& this.SeatID == __o.SeatID
					&& this.SeatTime == __o.SeatTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __________AccountID; }
				set { __________AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __PKs.CharacterID; }
				set { __PKs.CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public bool IsDeleted
			{
				get { return __________IsDeleted; }
				set { __________IsDeleted = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public bool IsEnabled
			{
				get { return __________IsEnabled; }
				set { __________IsEnabled = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Gold
			{
				get { return __________Gold; }
				set { __________Gold = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public bool IsOnline
			{
				get { return __________IsOnline; }
				set { __________IsOnline = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.Guid Ticket
			{
				get { return __________Ticket; }
				set { __________Ticket = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime TicketExpireTime
			{
				get { return __________TicketExpireTime; }
				set { __________TicketExpireTime = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int SeatID
			{
				get { return __________SeatID; }
				set { __________SeatID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime SeatTime
			{
				get { return __________SeatTime; }
				set { __________SeatTime = value; }
			}
		}

		[Serializable]
		public partial class User_CharacterCollection : List<User_Character>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_Character Add(int AccountID, int CharacterID, System.DateTime CreateTime, string Name, string Description, bool IsDeleted, bool IsEnabled, int Gold, bool IsOnline, System.Guid Ticket, System.DateTime TicketExpireTime, int SeatID, System.DateTime SeatTime)
			{
				User_Character o = new User_Character(AccountID, CharacterID, CreateTime, Name, Description, IsDeleted, IsEnabled, Gold, IsOnline, Ticket, TicketExpireTime, SeatID, SeatTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_CharacterCollection __os)
			{
				int i = 0;
				foreach (User_Character __o in __os)
				{
					User_Character __oo = this.Find(new Predicate<User_Character>(delegate(User_Character _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_CharacterCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_CharacterCollection Rows;
		}

		#endregion

		#region User_CharacterGameProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_CharacterGameProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：CharacterGameProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________CharacterID;
				protected int __________GameID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterID
				{
					get { return __________CharacterID; }
					set { __________CharacterID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int GameID
				{
					get { return __________GameID; }
					set { __________GameID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int CharacterID, int GameID, string Key)
				{
					__________CharacterID = CharacterID;
					__________GameID = GameID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________CharacterID == other.CharacterID && __________GameID == other.GameID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：CharacterGameProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：CharacterGameProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterGameProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterGameProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public User_CharacterGameProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public User_CharacterGameProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_CharacterGameProfile(int CharacterID, int GameID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(CharacterID, GameID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public User_CharacterGameProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_CharacterGameProfile __oo)
			{
				__oo.CharacterID = this.CharacterID;
				__oo.GameID = this.GameID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_CharacterGameProfile __oo)
			{
				this.CharacterID = __oo.CharacterID;
				this.GameID = __oo.GameID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_CharacterGameProfile Copy()
			{
				User_CharacterGameProfile __oo = new User_CharacterGameProfile();
				__oo.CharacterID = this.CharacterID;
				__oo.GameID = this.GameID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_CharacterGameProfile __o)
			{
				if (this == __o) return true;
				if (
					this.CharacterID == __o.CharacterID
					&& this.GameID == __o.GameID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __PKs.CharacterID; }
				set { __PKs.CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int GameID
			{
				get { return __PKs.GameID; }
				set { __PKs.GameID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class User_CharacterGameProfileCollection : List<User_CharacterGameProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_CharacterGameProfile Add(int CharacterID, int GameID, string Key, object Value, object DefaultValue, string Description)
			{
				User_CharacterGameProfile o = new User_CharacterGameProfile(CharacterID, GameID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_CharacterGameProfileCollection __os)
			{
				int i = 0;
				foreach (User_CharacterGameProfile __o in __os)
				{
					User_CharacterGameProfile __oo = this.Find(new Predicate<User_CharacterGameProfile>(delegate(User_CharacterGameProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_CharacterGameProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_CharacterGameProfileCollection Rows;
		}

		#endregion

		#region User_CharacterGoldLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_CharacterGoldLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：CharacterGoldLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________CharacterGoldLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterGoldLogID
				{
					get { return __________CharacterGoldLogID; }
					set { __________CharacterGoldLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int CharacterGoldLogID)
				{
					__________CharacterGoldLogID = CharacterGoldLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________CharacterGoldLogID == other.CharacterGoldLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：CharacterGoldLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：CharacterGoldLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterGoldLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterGoldLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________DeskActionLogID;
			protected int __________CharacterID;
			protected int __________Value;

			#endregion

			#region 构造函数

			public User_CharacterGoldLog()
			{
				__PKs = new PrimaryKeys();
			}
			public User_CharacterGoldLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_CharacterGoldLog(int CharacterGoldLogID, int DeskActionLogID, int CharacterID, int Value)
			{
				__PKs = new PrimaryKeys(CharacterGoldLogID);
				__________DeskActionLogID = DeskActionLogID;
				__________CharacterID = CharacterID;
				__________Value = Value;
			}
			public User_CharacterGoldLog(PrimaryKeys __pk, int DeskActionLogID, int CharacterID, int Value)
			{
				__PKs = __pk;
				__________DeskActionLogID = DeskActionLogID;
				__________CharacterID = CharacterID;
				__________Value = Value;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_CharacterGoldLog __oo)
			{
				__oo.CharacterGoldLogID = this.CharacterGoldLogID;
				__oo.DeskActionLogID = this.DeskActionLogID;
				__oo.CharacterID = this.CharacterID;
				__oo.Value = this.Value;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_CharacterGoldLog __oo)
			{
				this.CharacterGoldLogID = __oo.CharacterGoldLogID;
				this.DeskActionLogID = __oo.DeskActionLogID;
				this.CharacterID = __oo.CharacterID;
				this.Value = __oo.Value;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_CharacterGoldLog Copy()
			{
				User_CharacterGoldLog __oo = new User_CharacterGoldLog();
				__oo.CharacterGoldLogID = this.CharacterGoldLogID;
				__oo.DeskActionLogID = this.DeskActionLogID;
				__oo.CharacterID = this.CharacterID;
				__oo.Value = this.Value;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_CharacterGoldLog __o)
			{
				if (this == __o) return true;
				if (
					this.CharacterGoldLogID == __o.CharacterGoldLogID
					&& this.DeskActionLogID == __o.DeskActionLogID
					&& this.CharacterID == __o.CharacterID
					&& this.Value == __o.Value
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterGoldLogID
			{
				get { return __PKs.CharacterGoldLogID; }
				set { __PKs.CharacterGoldLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int DeskActionLogID
			{
				get { return __________DeskActionLogID; }
				set { __________DeskActionLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __________CharacterID; }
				set { __________CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
		}

		[Serializable]
		public partial class User_CharacterGoldLogCollection : List<User_CharacterGoldLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_CharacterGoldLog Add(int CharacterGoldLogID, int DeskActionLogID, int CharacterID, int Value)
			{
				User_CharacterGoldLog o = new User_CharacterGoldLog(CharacterGoldLogID, DeskActionLogID, CharacterID, Value);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_CharacterGoldLogCollection __os)
			{
				int i = 0;
				foreach (User_CharacterGoldLog __o in __os)
				{
					User_CharacterGoldLog __oo = this.Find(new Predicate<User_CharacterGoldLog>(delegate(User_CharacterGoldLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_CharacterGoldLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_CharacterGoldLogCollection Rows;
		}

		#endregion

		#region User_CharacterOnlineLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_CharacterOnlineLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：CharacterOnlineLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________CharacterOnlineLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterOnlineLogID
				{
					get { return __________CharacterOnlineLogID; }
					set { __________CharacterOnlineLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int CharacterOnlineLogID)
				{
					__________CharacterOnlineLogID = CharacterOnlineLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________CharacterOnlineLogID == other.CharacterOnlineLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：CharacterOnlineLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：CharacterOnlineLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterOnlineLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterOnlineLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________CharacterID;
			protected bool __________IsOnline;
			protected System.DateTime __________BeginTime;

			#endregion

			#region 构造函数

			public User_CharacterOnlineLog()
			{
				__PKs = new PrimaryKeys();
			}
			public User_CharacterOnlineLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_CharacterOnlineLog(int CharacterOnlineLogID, int CharacterID, bool IsOnline, System.DateTime BeginTime)
			{
				__PKs = new PrimaryKeys(CharacterOnlineLogID);
				__________CharacterID = CharacterID;
				__________IsOnline = IsOnline;
				__________BeginTime = BeginTime;
			}
			public User_CharacterOnlineLog(PrimaryKeys __pk, int CharacterID, bool IsOnline, System.DateTime BeginTime)
			{
				__PKs = __pk;
				__________CharacterID = CharacterID;
				__________IsOnline = IsOnline;
				__________BeginTime = BeginTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_CharacterOnlineLog __oo)
			{
				__oo.CharacterOnlineLogID = this.CharacterOnlineLogID;
				__oo.CharacterID = this.CharacterID;
				__oo.IsOnline = this.IsOnline;
				__oo.BeginTime = this.BeginTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_CharacterOnlineLog __oo)
			{
				this.CharacterOnlineLogID = __oo.CharacterOnlineLogID;
				this.CharacterID = __oo.CharacterID;
				this.IsOnline = __oo.IsOnline;
				this.BeginTime = __oo.BeginTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_CharacterOnlineLog Copy()
			{
				User_CharacterOnlineLog __oo = new User_CharacterOnlineLog();
				__oo.CharacterOnlineLogID = this.CharacterOnlineLogID;
				__oo.CharacterID = this.CharacterID;
				__oo.IsOnline = this.IsOnline;
				__oo.BeginTime = this.BeginTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_CharacterOnlineLog __o)
			{
				if (this == __o) return true;
				if (
					this.CharacterOnlineLogID == __o.CharacterOnlineLogID
					&& this.CharacterID == __o.CharacterID
					&& this.IsOnline == __o.IsOnline
					&& this.BeginTime == __o.BeginTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterOnlineLogID
			{
				get { return __PKs.CharacterOnlineLogID; }
				set { __PKs.CharacterOnlineLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __________CharacterID; }
				set { __________CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public bool IsOnline
			{
				get { return __________IsOnline; }
				set { __________IsOnline = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime BeginTime
			{
				get { return __________BeginTime; }
				set { __________BeginTime = value; }
			}
		}

		[Serializable]
		public partial class User_CharacterOnlineLogCollection : List<User_CharacterOnlineLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_CharacterOnlineLog Add(int CharacterOnlineLogID, int CharacterID, bool IsOnline, System.DateTime BeginTime)
			{
				User_CharacterOnlineLog o = new User_CharacterOnlineLog(CharacterOnlineLogID, CharacterID, IsOnline, BeginTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_CharacterOnlineLogCollection __os)
			{
				int i = 0;
				foreach (User_CharacterOnlineLog __o in __os)
				{
					User_CharacterOnlineLog __oo = this.Find(new Predicate<User_CharacterOnlineLog>(delegate(User_CharacterOnlineLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_CharacterOnlineLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_CharacterOnlineLogCollection Rows;
		}

		#endregion

		#region User_CharacterProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_CharacterProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：CharacterProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________CharacterID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterID
				{
					get { return __________CharacterID; }
					set { __________CharacterID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int CharacterID, string Key)
				{
					__________CharacterID = CharacterID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________CharacterID == other.CharacterID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：CharacterProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：CharacterProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public User_CharacterProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public User_CharacterProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_CharacterProfile(int CharacterID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(CharacterID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public User_CharacterProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_CharacterProfile __oo)
			{
				__oo.CharacterID = this.CharacterID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_CharacterProfile __oo)
			{
				this.CharacterID = __oo.CharacterID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_CharacterProfile Copy()
			{
				User_CharacterProfile __oo = new User_CharacterProfile();
				__oo.CharacterID = this.CharacterID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_CharacterProfile __o)
			{
				if (this == __o) return true;
				if (
					this.CharacterID == __o.CharacterID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __PKs.CharacterID; }
				set { __PKs.CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class User_CharacterProfileCollection : List<User_CharacterProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_CharacterProfile Add(int CharacterID, string Key, object Value, object DefaultValue, string Description)
			{
				User_CharacterProfile o = new User_CharacterProfile(CharacterID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_CharacterProfileCollection __os)
			{
				int i = 0;
				foreach (User_CharacterProfile __o in __os)
				{
					User_CharacterProfile __oo = this.Find(new Predicate<User_CharacterProfile>(delegate(User_CharacterProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_CharacterProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_CharacterProfileCollection Rows;
		}

		#endregion

		#region User_CharacterSeatLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_CharacterSeatLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：CharacterSeatLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________CharacterSeatLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterSeatLogID
				{
					get { return __________CharacterSeatLogID; }
					set { __________CharacterSeatLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int CharacterSeatLogID)
				{
					__________CharacterSeatLogID = CharacterSeatLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________CharacterSeatLogID == other.CharacterSeatLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：CharacterSeatLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：CharacterSeatLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterSeatLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_CharacterSeatLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________CharacterID;
			protected int __________SeatID;
			protected System.DateTime __________SeatTime;

			#endregion

			#region 构造函数

			public User_CharacterSeatLog()
			{
				__PKs = new PrimaryKeys();
			}
			public User_CharacterSeatLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_CharacterSeatLog(int CharacterSeatLogID, int CharacterID, int SeatID, System.DateTime SeatTime)
			{
				__PKs = new PrimaryKeys(CharacterSeatLogID);
				__________CharacterID = CharacterID;
				__________SeatID = SeatID;
				__________SeatTime = SeatTime;
			}
			public User_CharacterSeatLog(PrimaryKeys __pk, int CharacterID, int SeatID, System.DateTime SeatTime)
			{
				__PKs = __pk;
				__________CharacterID = CharacterID;
				__________SeatID = SeatID;
				__________SeatTime = SeatTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_CharacterSeatLog __oo)
			{
				__oo.CharacterSeatLogID = this.CharacterSeatLogID;
				__oo.CharacterID = this.CharacterID;
				__oo.SeatID = this.SeatID;
				__oo.SeatTime = this.SeatTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_CharacterSeatLog __oo)
			{
				this.CharacterSeatLogID = __oo.CharacterSeatLogID;
				this.CharacterID = __oo.CharacterID;
				this.SeatID = __oo.SeatID;
				this.SeatTime = __oo.SeatTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_CharacterSeatLog Copy()
			{
				User_CharacterSeatLog __oo = new User_CharacterSeatLog();
				__oo.CharacterSeatLogID = this.CharacterSeatLogID;
				__oo.CharacterID = this.CharacterID;
				__oo.SeatID = this.SeatID;
				__oo.SeatTime = this.SeatTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_CharacterSeatLog __o)
			{
				if (this == __o) return true;
				if (
					this.CharacterSeatLogID == __o.CharacterSeatLogID
					&& this.CharacterID == __o.CharacterID
					&& this.SeatID == __o.SeatID
					&& this.SeatTime == __o.SeatTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterSeatLogID
			{
				get { return __PKs.CharacterSeatLogID; }
				set { __PKs.CharacterSeatLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __________CharacterID; }
				set { __________CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int SeatID
			{
				get { return __________SeatID; }
				set { __________SeatID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime SeatTime
			{
				get { return __________SeatTime; }
				set { __________SeatTime = value; }
			}
		}

		[Serializable]
		public partial class User_CharacterSeatLogCollection : List<User_CharacterSeatLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_CharacterSeatLog Add(int CharacterSeatLogID, int CharacterID, int SeatID, System.DateTime SeatTime)
			{
				User_CharacterSeatLog o = new User_CharacterSeatLog(CharacterSeatLogID, CharacterID, SeatID, SeatTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_CharacterSeatLogCollection __os)
			{
				int i = 0;
				foreach (User_CharacterSeatLog __o in __os)
				{
					User_CharacterSeatLog __oo = this.Find(new Predicate<User_CharacterSeatLog>(delegate(User_CharacterSeatLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_CharacterSeatLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_CharacterSeatLogCollection Rows;
		}

		#endregion

		#region User_Message

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_Message
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Message 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________MessageID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int MessageID
				{
					get { return __________MessageID; }
					set { __________MessageID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int MessageID)
				{
					__________MessageID = MessageID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________MessageID == other.MessageID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Message 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Message 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Message other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Message.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________CharacterID;
			protected string __________Content;
			protected System.DateTime __________CreateTime;

			#endregion

			#region 构造函数

			public User_Message()
			{
				__PKs = new PrimaryKeys();
			}
			public User_Message(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_Message(int CharacterID, int MessageID, string Content, System.DateTime CreateTime)
			{
				__PKs = new PrimaryKeys(MessageID);
				__________CharacterID = CharacterID;
				__________Content = Content;
				__________CreateTime = CreateTime;
			}
			public User_Message(PrimaryKeys __pk, int CharacterID, string Content, System.DateTime CreateTime)
			{
				__PKs = __pk;
				__________CharacterID = CharacterID;
				__________Content = Content;
				__________CreateTime = CreateTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_Message __oo)
			{
				__oo.CharacterID = this.CharacterID;
				__oo.MessageID = this.MessageID;
				__oo.Content = this.Content;
				__oo.CreateTime = this.CreateTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_Message __oo)
			{
				this.CharacterID = __oo.CharacterID;
				this.MessageID = __oo.MessageID;
				this.Content = __oo.Content;
				this.CreateTime = __oo.CreateTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_Message Copy()
			{
				User_Message __oo = new User_Message();
				__oo.CharacterID = this.CharacterID;
				__oo.MessageID = this.MessageID;
				__oo.Content = this.Content;
				__oo.CreateTime = this.CreateTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_Message __o)
			{
				if (this == __o) return true;
				if (
					this.CharacterID == __o.CharacterID
					&& this.MessageID == __o.MessageID
					&& this.Content == __o.Content
					&& this.CreateTime == __o.CreateTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __________CharacterID; }
				set { __________CharacterID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int MessageID
			{
				get { return __PKs.MessageID; }
				set { __PKs.MessageID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Content
			{
				get { return __________Content; }
				set { __________Content = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
		}

		[Serializable]
		public partial class User_MessageCollection : List<User_Message>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_Message Add(int CharacterID, int MessageID, string Content, System.DateTime CreateTime)
			{
				User_Message o = new User_Message(CharacterID, MessageID, Content, CreateTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_MessageCollection __os)
			{
				int i = 0;
				foreach (User_Message __o in __os)
				{
					User_Message __oo = this.Find(new Predicate<User_Message>(delegate(User_Message _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_MessageCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_MessageCollection Rows;
		}

		#endregion

		#region User_MessageReceive

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_MessageReceive
		{
			#region 主键组类定义

			/// <summary>
			/// 表：MessageReceive 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________MessageID;
				protected int __________CharacterID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int MessageID
				{
					get { return __________MessageID; }
					set { __________MessageID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int CharacterID
				{
					get { return __________CharacterID; }
					set { __________CharacterID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int MessageID, int CharacterID)
				{
					__________MessageID = MessageID;
					__________CharacterID = CharacterID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________MessageID == other.MessageID && __________CharacterID == other.CharacterID;
				}

				#endregion
			}

			/// <summary>
			/// 表：MessageReceive 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：MessageReceive 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_MessageReceive other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_MessageReceive.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}

			#endregion

			#region 构造函数

			public User_MessageReceive()
			{
				__PKs = new PrimaryKeys();
			}
			public User_MessageReceive(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_MessageReceive(int MessageID, int CharacterID)
			{
				__PKs = new PrimaryKeys(MessageID, CharacterID);
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_MessageReceive __oo)
			{
				__oo.MessageID = this.MessageID;
				__oo.CharacterID = this.CharacterID;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_MessageReceive __oo)
			{
				this.MessageID = __oo.MessageID;
				this.CharacterID = __oo.CharacterID;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_MessageReceive Copy()
			{
				User_MessageReceive __oo = new User_MessageReceive();
				__oo.MessageID = this.MessageID;
				__oo.CharacterID = this.CharacterID;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_MessageReceive __o)
			{
				if (this == __o) return true;
				if (
					this.MessageID == __o.MessageID
					&& this.CharacterID == __o.CharacterID
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int MessageID
			{
				get { return __PKs.MessageID; }
				set { __PKs.MessageID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int CharacterID
			{
				get { return __PKs.CharacterID; }
				set { __PKs.CharacterID = value; }
			}
		}

		[Serializable]
		public partial class User_MessageReceiveCollection : List<User_MessageReceive>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_MessageReceive Add(int MessageID, int CharacterID)
			{
				User_MessageReceive o = new User_MessageReceive(MessageID, CharacterID);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_MessageReceiveCollection __os)
			{
				int i = 0;
				foreach (User_MessageReceive __o in __os)
				{
					User_MessageReceive __oo = this.Find(new Predicate<User_MessageReceive>(delegate(User_MessageReceive _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_MessageReceiveCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_MessageReceiveCollection Rows;
		}

		#endregion

		#region User_PasswordLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_PasswordLog
		{
			#region 私有成员

			protected int __________AccountID;
			protected string __________Password;
			protected System.DateTime __________CreateTime;

			#endregion

			#region 构造函数

			public User_PasswordLog()
			{
			}
			public User_PasswordLog(int AccountID, string Password, System.DateTime CreateTime)
			{
				__________AccountID = AccountID;
				__________Password = Password;
				__________CreateTime = CreateTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_PasswordLog __oo)
			{
				__oo.AccountID = this.AccountID;
				__oo.Password = this.Password;
				__oo.CreateTime = this.CreateTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_PasswordLog __oo)
			{
				this.AccountID = __oo.AccountID;
				this.Password = __oo.Password;
				this.CreateTime = __oo.CreateTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_PasswordLog Copy()
			{
				User_PasswordLog __oo = new User_PasswordLog();
				__oo.AccountID = this.AccountID;
				__oo.Password = this.Password;
				__oo.CreateTime = this.CreateTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_PasswordLog __o)
			{
				if (this == __o) return true;
				if (
					this.AccountID == __o.AccountID
					&& this.Password == __o.Password
					&& this.CreateTime == __o.CreateTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __________AccountID; }
				set { __________AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Password
			{
				get { return __________Password; }
				set { __________Password = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
		}

		[Serializable]
		public partial class User_PasswordLogCollection : List<User_PasswordLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_PasswordLog Add(int AccountID, string Password, System.DateTime CreateTime)
			{
				User_PasswordLog o = new User_PasswordLog(AccountID, Password, CreateTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_PasswordLogCollection __os)
			{
				int i = 0;
				foreach (User_PasswordLog __o in __os)
				{
					User_PasswordLog __oo = this.Find(new Predicate<User_PasswordLog>(delegate(User_PasswordLog _o) { return _o.Equals(__o); }));
					if (__oo != null)
					{
						__o.CopyTo(__oo);
						i++;
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_PasswordLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_PasswordLogCollection Rows;
		}

		#endregion

		#region User_PurchaseCreditLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_PurchaseCreditLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：PurchaseCreditLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________PurchaseCreditLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int PurchaseCreditLogID
				{
					get { return __________PurchaseCreditLogID; }
					set { __________PurchaseCreditLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int PurchaseCreditLogID)
				{
					__________PurchaseCreditLogID = PurchaseCreditLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________PurchaseCreditLogID == other.PurchaseCreditLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：PurchaseCreditLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：PurchaseCreditLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_PurchaseCreditLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_PurchaseCreditLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________AccountID;
			protected int __________Value;
			protected System.DateTime __________CreateTime;

			#endregion

			#region 构造函数

			public User_PurchaseCreditLog()
			{
				__PKs = new PrimaryKeys();
			}
			public User_PurchaseCreditLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_PurchaseCreditLog(int PurchaseCreditLogID, int AccountID, int Value, System.DateTime CreateTime)
			{
				__PKs = new PrimaryKeys(PurchaseCreditLogID);
				__________AccountID = AccountID;
				__________Value = Value;
				__________CreateTime = CreateTime;
			}
			public User_PurchaseCreditLog(PrimaryKeys __pk, int AccountID, int Value, System.DateTime CreateTime)
			{
				__PKs = __pk;
				__________AccountID = AccountID;
				__________Value = Value;
				__________CreateTime = CreateTime;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_PurchaseCreditLog __oo)
			{
				__oo.PurchaseCreditLogID = this.PurchaseCreditLogID;
				__oo.AccountID = this.AccountID;
				__oo.Value = this.Value;
				__oo.CreateTime = this.CreateTime;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_PurchaseCreditLog __oo)
			{
				this.PurchaseCreditLogID = __oo.PurchaseCreditLogID;
				this.AccountID = __oo.AccountID;
				this.Value = __oo.Value;
				this.CreateTime = __oo.CreateTime;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_PurchaseCreditLog Copy()
			{
				User_PurchaseCreditLog __oo = new User_PurchaseCreditLog();
				__oo.PurchaseCreditLogID = this.PurchaseCreditLogID;
				__oo.AccountID = this.AccountID;
				__oo.Value = this.Value;
				__oo.CreateTime = this.CreateTime;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_PurchaseCreditLog __o)
			{
				if (this == __o) return true;
				if (
					this.PurchaseCreditLogID == __o.PurchaseCreditLogID
					&& this.AccountID == __o.AccountID
					&& this.Value == __o.Value
					&& this.CreateTime == __o.CreateTime
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int PurchaseCreditLogID
			{
				get { return __PKs.PurchaseCreditLogID; }
				set { __PKs.PurchaseCreditLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __________AccountID; }
				set { __________AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime CreateTime
			{
				get { return __________CreateTime; }
				set { __________CreateTime = value; }
			}
		}

		[Serializable]
		public partial class User_PurchaseCreditLogCollection : List<User_PurchaseCreditLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_PurchaseCreditLog Add(int PurchaseCreditLogID, int AccountID, int Value, System.DateTime CreateTime)
			{
				User_PurchaseCreditLog o = new User_PurchaseCreditLog(PurchaseCreditLogID, AccountID, Value, CreateTime);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_PurchaseCreditLogCollection __os)
			{
				int i = 0;
				foreach (User_PurchaseCreditLog __o in __os)
				{
					User_PurchaseCreditLog __oo = this.Find(new Predicate<User_PurchaseCreditLog>(delegate(User_PurchaseCreditLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_PurchaseCreditLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_PurchaseCreditLogCollection Rows;
		}

		#endregion

		#region User_Role

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_Role
		{
			#region 主键组类定义

			/// <summary>
			/// 表：Role 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________RoleID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int RoleID
				{
					get { return __________RoleID; }
					set { __________RoleID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int RoleID)
				{
					__________RoleID = RoleID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________RoleID == other.RoleID;
				}

				#endregion
			}

			/// <summary>
			/// 表：Role 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：Role 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Role other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_Role.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________Name;
			protected string __________Description;

			#endregion

			#region 构造函数

			public User_Role()
			{
				__PKs = new PrimaryKeys();
			}
			public User_Role(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_Role(int RoleID, string Name, string Description)
			{
				__PKs = new PrimaryKeys(RoleID);
				__________Name = Name;
				__________Description = Description;
			}
			public User_Role(PrimaryKeys __pk, string Name, string Description)
			{
				__PKs = __pk;
				__________Name = Name;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_Role __oo)
			{
				__oo.RoleID = this.RoleID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_Role __oo)
			{
				this.RoleID = __oo.RoleID;
				this.Name = __oo.Name;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_Role Copy()
			{
				User_Role __oo = new User_Role();
				__oo.RoleID = this.RoleID;
				__oo.Name = this.Name;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_Role __o)
			{
				if (this == __o) return true;
				if (
					this.RoleID == __o.RoleID
					&& this.Name == __o.Name
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int RoleID
			{
				get { return __PKs.RoleID; }
				set { __PKs.RoleID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Name
			{
				get { return __________Name; }
				set { __________Name = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class User_RoleCollection : List<User_Role>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_Role Add(int RoleID, string Name, string Description)
			{
				User_Role o = new User_Role(RoleID, Name, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_RoleCollection __os)
			{
				int i = 0;
				foreach (User_Role __o in __os)
				{
					User_Role __oo = this.Find(new Predicate<User_Role>(delegate(User_Role _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_RoleCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_RoleCollection Rows;
		}

		#endregion

		#region User_User_Role

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_User_Role
		{
			#region 私有成员

			protected int __________AccountID;
			protected int __________RoleID;

			#endregion

			#region 构造函数

			public User_User_Role()
			{
			}
			public User_User_Role(int AccountID, int RoleID)
			{
				__________AccountID = AccountID;
				__________RoleID = RoleID;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_User_Role __oo)
			{
				__oo.AccountID = this.AccountID;
				__oo.RoleID = this.RoleID;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_User_Role __oo)
			{
				this.AccountID = __oo.AccountID;
				this.RoleID = __oo.RoleID;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_User_Role Copy()
			{
				User_User_Role __oo = new User_User_Role();
				__oo.AccountID = this.AccountID;
				__oo.RoleID = this.RoleID;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_User_Role __o)
			{
				if (this == __o) return true;
				if (
					this.AccountID == __o.AccountID
					&& this.RoleID == __o.RoleID
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __________AccountID; }
				set { __________AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int RoleID
			{
				get { return __________RoleID; }
				set { __________RoleID = value; }
			}
		}

		[Serializable]
		public partial class User_User_RoleCollection : List<User_User_Role>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_User_Role Add(int AccountID, int RoleID)
			{
				User_User_Role o = new User_User_Role(AccountID, RoleID);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_User_RoleCollection __os)
			{
				int i = 0;
				foreach (User_User_Role __o in __os)
				{
					User_User_Role __oo = this.Find(new Predicate<User_User_Role>(delegate(User_User_Role _o) { return _o.Equals(__o); }));
					if (__oo != null)
					{
						__o.CopyTo(__oo);
						i++;
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_User_RoleCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_User_RoleCollection Rows;
		}

		#endregion

		#region User_UserConnectLog

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_UserConnectLog
		{
			#region 主键组类定义

			/// <summary>
			/// 表：UserConnectLog 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________UserConnectLogID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int UserConnectLogID
				{
					get { return __________UserConnectLogID; }
					set { __________UserConnectLogID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int UserConnectLogID)
				{
					__________UserConnectLogID = UserConnectLogID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________UserConnectLogID == other.UserConnectLogID;
				}

				#endregion
			}

			/// <summary>
			/// 表：UserConnectLog 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：UserConnectLog 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_UserConnectLog other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_UserConnectLog.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________AccountID;
			protected System.DateTime __________BeginTime;
			protected bool __________IsConnect;

			#endregion

			#region 构造函数

			public User_UserConnectLog()
			{
				__PKs = new PrimaryKeys();
			}
			public User_UserConnectLog(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_UserConnectLog(int UserConnectLogID, int AccountID, System.DateTime BeginTime, bool IsConnect)
			{
				__PKs = new PrimaryKeys(UserConnectLogID);
				__________AccountID = AccountID;
				__________BeginTime = BeginTime;
				__________IsConnect = IsConnect;
			}
			public User_UserConnectLog(PrimaryKeys __pk, int AccountID, System.DateTime BeginTime, bool IsConnect)
			{
				__PKs = __pk;
				__________AccountID = AccountID;
				__________BeginTime = BeginTime;
				__________IsConnect = IsConnect;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_UserConnectLog __oo)
			{
				__oo.UserConnectLogID = this.UserConnectLogID;
				__oo.AccountID = this.AccountID;
				__oo.BeginTime = this.BeginTime;
				__oo.IsConnect = this.IsConnect;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_UserConnectLog __oo)
			{
				this.UserConnectLogID = __oo.UserConnectLogID;
				this.AccountID = __oo.AccountID;
				this.BeginTime = __oo.BeginTime;
				this.IsConnect = __oo.IsConnect;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_UserConnectLog Copy()
			{
				User_UserConnectLog __oo = new User_UserConnectLog();
				__oo.UserConnectLogID = this.UserConnectLogID;
				__oo.AccountID = this.AccountID;
				__oo.BeginTime = this.BeginTime;
				__oo.IsConnect = this.IsConnect;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_UserConnectLog __o)
			{
				if (this == __o) return true;
				if (
					this.UserConnectLogID == __o.UserConnectLogID
					&& this.AccountID == __o.AccountID
					&& this.BeginTime == __o.BeginTime
					&& this.IsConnect == __o.IsConnect
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int UserConnectLogID
			{
				get { return __PKs.UserConnectLogID; }
				set { __PKs.UserConnectLogID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __________AccountID; }
				set { __________AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public System.DateTime BeginTime
			{
				get { return __________BeginTime; }
				set { __________BeginTime = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public bool IsConnect
			{
				get { return __________IsConnect; }
				set { __________IsConnect = value; }
			}
		}

		[Serializable]
		public partial class User_UserConnectLogCollection : List<User_UserConnectLog>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_UserConnectLog Add(int UserConnectLogID, int AccountID, System.DateTime BeginTime, bool IsConnect)
			{
				User_UserConnectLog o = new User_UserConnectLog(UserConnectLogID, AccountID, BeginTime, IsConnect);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_UserConnectLogCollection __os)
			{
				int i = 0;
				foreach (User_UserConnectLog __o in __os)
				{
					User_UserConnectLog __oo = this.Find(new Predicate<User_UserConnectLog>(delegate(User_UserConnectLog _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_UserConnectLogCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_UserConnectLogCollection Rows;
		}

		#endregion

		#region User_UserOnlineCounter

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_UserOnlineCounter
		{
			#region 主键组类定义

			/// <summary>
			/// 表：UserOnlineCounter 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________AccountID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int AccountID
				{
					get { return __________AccountID; }
					set { __________AccountID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int AccountID)
				{
					__________AccountID = AccountID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________AccountID == other.AccountID;
				}

				#endregion
			}

			/// <summary>
			/// 表：UserOnlineCounter 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：UserOnlineCounter 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_UserOnlineCounter other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_UserOnlineCounter.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected int __________Count;

			#endregion

			#region 构造函数

			public User_UserOnlineCounter()
			{
				__PKs = new PrimaryKeys();
			}
			public User_UserOnlineCounter(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_UserOnlineCounter(int AccountID, int Count)
			{
				__PKs = new PrimaryKeys(AccountID);
				__________Count = Count;
			}
			public User_UserOnlineCounter(PrimaryKeys __pk, int Count)
			{
				__PKs = __pk;
				__________Count = Count;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_UserOnlineCounter __oo)
			{
				__oo.AccountID = this.AccountID;
				__oo.Count = this.Count;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_UserOnlineCounter __oo)
			{
				this.AccountID = __oo.AccountID;
				this.Count = __oo.Count;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_UserOnlineCounter Copy()
			{
				User_UserOnlineCounter __oo = new User_UserOnlineCounter();
				__oo.AccountID = this.AccountID;
				__oo.Count = this.Count;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_UserOnlineCounter __o)
			{
				if (this == __o) return true;
				if (
					this.AccountID == __o.AccountID
					&& this.Count == __o.Count
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __PKs.AccountID; }
				set { __PKs.AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int Count
			{
				get { return __________Count; }
				set { __________Count = value; }
			}
		}

		[Serializable]
		public partial class User_UserOnlineCounterCollection : List<User_UserOnlineCounter>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_UserOnlineCounter Add(int AccountID, int Count)
			{
				User_UserOnlineCounter o = new User_UserOnlineCounter(AccountID, Count);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_UserOnlineCounterCollection __os)
			{
				int i = 0;
				foreach (User_UserOnlineCounter __o in __os)
				{
					User_UserOnlineCounter __oo = this.Find(new Predicate<User_UserOnlineCounter>(delegate(User_UserOnlineCounter _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_UserOnlineCounterCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_UserOnlineCounterCollection Rows;
		}

		#endregion

		#region User_UserProfile

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class User_UserProfile
		{
			#region 主键组类定义

			/// <summary>
			/// 表：UserProfile 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________AccountID;
				protected string __________Key;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int AccountID
				{
					get { return __________AccountID; }
					set { __________AccountID = value; }
				}
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public string Key
				{
					get { return __________Key; }
					set { __________Key = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int AccountID, string Key)
				{
					__________AccountID = AccountID;
					__________Key = Key;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________AccountID == other.AccountID && __________Key == other.Key;
				}

				#endregion
			}

			/// <summary>
			/// 表：UserProfile 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：UserProfile 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_UserProfile other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(User_UserProfile.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected object __________Value;
			protected object __________DefaultValue;
			protected string __________Description;

			#endregion

			#region 构造函数

			public User_UserProfile()
			{
				__PKs = new PrimaryKeys();
			}
			public User_UserProfile(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public User_UserProfile(int AccountID, string Key, object Value, object DefaultValue, string Description)
			{
				__PKs = new PrimaryKeys(AccountID, Key);
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}
			public User_UserProfile(PrimaryKeys __pk, object Value, object DefaultValue, string Description)
			{
				__PKs = __pk;
				__________Value = Value;
				__________DefaultValue = DefaultValue;
				__________Description = Description;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(User_UserProfile __oo)
			{
				__oo.AccountID = this.AccountID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(User_UserProfile __oo)
			{
				this.AccountID = __oo.AccountID;
				this.Key = __oo.Key;
				this.Value = __oo.Value;
				this.DefaultValue = __oo.DefaultValue;
				this.Description = __oo.Description;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual User_UserProfile Copy()
			{
				User_UserProfile __oo = new User_UserProfile();
				__oo.AccountID = this.AccountID;
				__oo.Key = this.Key;
				__oo.Value = this.Value;
				__oo.DefaultValue = this.DefaultValue;
				__oo.Description = this.Description;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(User_UserProfile __o)
			{
				if (this == __o) return true;
				if (
					this.AccountID == __o.AccountID
					&& this.Key == __o.Key
					&& this.Value == __o.Value
					&& this.DefaultValue == __o.DefaultValue
					&& this.Description == __o.Description
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int AccountID
			{
				get { return __PKs.AccountID; }
				set { __PKs.AccountID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Key
			{
				get { return __PKs.Key; }
				set { __PKs.Key = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object Value
			{
				get { return __________Value; }
				set { __________Value = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public object DefaultValue
			{
				get { return __________DefaultValue; }
				set { __________DefaultValue = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string Description
			{
				get { return __________Description; }
				set { __________Description = value; }
			}
		}

		[Serializable]
		public partial class User_UserProfileCollection : List<User_UserProfile>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public User_UserProfile Add(int AccountID, string Key, object Value, object DefaultValue, string Description)
			{
				User_UserProfile o = new User_UserProfile(AccountID, Key, Value, DefaultValue, Description);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(User_UserProfileCollection __os)
			{
				int i = 0;
				foreach (User_UserProfile __o in __os)
				{
					User_UserProfile __oo = this.Find(new Predicate<User_UserProfile>(delegate(User_UserProfile _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class User_UserProfileCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public User_UserProfileCollection Rows;
		}

		#endregion

		#region 系统_认证服务器状态

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class 系统_认证服务器状态
		{
			#region 主键组类定义

			/// <summary>
			/// 表：认证服务器状态 的主键组类
			/// </summary>
			[DataContract]
			[Serializable]
			public partial class PrimaryKeys : IEquatable<PrimaryKeys>
			{
				protected int __________ServiceInstanceID;
			/// <summary>
			/// 
			/// </summary>
				[DataMember]
				public int ServiceInstanceID
				{
					get { return __________ServiceInstanceID; }
					set { __________ServiceInstanceID = value; }
				}
				public PrimaryKeys() { }

				public PrimaryKeys(int ServiceInstanceID)
				{
					__________ServiceInstanceID = ServiceInstanceID;
				}

				#region IEquatable<PrimaryKeys> Members

				public bool Equals(PrimaryKeys other)
				{
					return __________ServiceInstanceID == other.ServiceInstanceID;
				}

				#endregion
			}

			/// <summary>
			/// 表：认证服务器状态 的主键组类集合
			/// </summary>
			[Serializable]
			public partial class PrimaryKeysCollection : List<PrimaryKeys> { }

			#endregion

			#region 私有成员，获取主键方法，主键值对比方法

			protected PrimaryKeys __PKs;
			/// <summary>
			/// 获取表：认证服务器状态 的主键组实例
			/// </summary>
			public PrimaryKeys GetPrimaryKeys()
			{
				return __PKs;
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(系统_认证服务器状态 other)
			{
				return __PKs.Equals(other.GetPrimaryKeys());
			}
			/// <summary>
			/// 判断与另一个类实例的主键是否相等
			/// </summary>
			public bool PrimaryKeyEquals(系统_认证服务器状态.PrimaryKeys other)
			{
				return __PKs.Equals(other);
			}
			protected string __________服务器地址;
			protected int __________服务器端口;
			protected int __________当前连接数量;
			protected int __________低负载指标;
			protected int __________中负载指标;
			protected int __________高负载指标;
			protected int __________最大负载指标;

			#endregion

			#region 构造函数

			public 系统_认证服务器状态()
			{
				__PKs = new PrimaryKeys();
			}
			public 系统_认证服务器状态(PrimaryKeys pk)
			{
				__PKs = pk;
			}
			public 系统_认证服务器状态(int ServiceInstanceID, string 服务器地址, int 服务器端口, int 当前连接数量, int 低负载指标, int 中负载指标, int 高负载指标, int 最大负载指标)
			{
				__PKs = new PrimaryKeys(ServiceInstanceID);
				__________服务器地址 = 服务器地址;
				__________服务器端口 = 服务器端口;
				__________当前连接数量 = 当前连接数量;
				__________低负载指标 = 低负载指标;
				__________中负载指标 = 中负载指标;
				__________高负载指标 = 高负载指标;
				__________最大负载指标 = 最大负载指标;
			}
			public 系统_认证服务器状态(PrimaryKeys __pk, string 服务器地址, int 服务器端口, int 当前连接数量, int 低负载指标, int 中负载指标, int 高负载指标, int 最大负载指标)
			{
				__PKs = __pk;
				__________服务器地址 = 服务器地址;
				__________服务器端口 = 服务器端口;
				__________当前连接数量 = 当前连接数量;
				__________低负载指标 = 低负载指标;
				__________中负载指标 = 中负载指标;
				__________高负载指标 = 高负载指标;
				__________最大负载指标 = 最大负载指标;
			}

			#endregion
			


			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(系统_认证服务器状态 __oo)
			{
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.服务器地址 = this.服务器地址;
				__oo.服务器端口 = this.服务器端口;
				__oo.当前连接数量 = this.当前连接数量;
				__oo.低负载指标 = this.低负载指标;
				__oo.中负载指标 = this.中负载指标;
				__oo.高负载指标 = this.高负载指标;
				__oo.最大负载指标 = this.最大负载指标;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(系统_认证服务器状态 __oo)
			{
				this.ServiceInstanceID = __oo.ServiceInstanceID;
				this.服务器地址 = __oo.服务器地址;
				this.服务器端口 = __oo.服务器端口;
				this.当前连接数量 = __oo.当前连接数量;
				this.低负载指标 = __oo.低负载指标;
				this.中负载指标 = __oo.中负载指标;
				this.高负载指标 = __oo.高负载指标;
				this.最大负载指标 = __oo.最大负载指标;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual 系统_认证服务器状态 Copy()
			{
				系统_认证服务器状态 __oo = new 系统_认证服务器状态();
				__oo.ServiceInstanceID = this.ServiceInstanceID;
				__oo.服务器地址 = this.服务器地址;
				__oo.服务器端口 = this.服务器端口;
				__oo.当前连接数量 = this.当前连接数量;
				__oo.低负载指标 = this.低负载指标;
				__oo.中负载指标 = this.中负载指标;
				__oo.高负载指标 = this.高负载指标;
				__oo.最大负载指标 = this.最大负载指标;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(系统_认证服务器状态 __o)
			{
				if (this == __o) return true;
				if (
					this.ServiceInstanceID == __o.ServiceInstanceID
					&& this.服务器地址 == __o.服务器地址
					&& this.服务器端口 == __o.服务器端口
					&& this.当前连接数量 == __o.当前连接数量
					&& this.低负载指标 == __o.低负载指标
					&& this.中负载指标 == __o.中负载指标
					&& this.高负载指标 == __o.高负载指标
					&& this.最大负载指标 == __o.最大负载指标
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int ServiceInstanceID
			{
				get { return __PKs.ServiceInstanceID; }
				set { __PKs.ServiceInstanceID = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string 服务器地址
			{
				get { return __________服务器地址; }
				set { __________服务器地址 = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int 服务器端口
			{
				get { return __________服务器端口; }
				set { __________服务器端口 = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int 当前连接数量
			{
				get { return __________当前连接数量; }
				set { __________当前连接数量 = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int 低负载指标
			{
				get { return __________低负载指标; }
				set { __________低负载指标 = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int 中负载指标
			{
				get { return __________中负载指标; }
				set { __________中负载指标 = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int 高负载指标
			{
				get { return __________高负载指标; }
				set { __________高负载指标 = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int 最大负载指标
			{
				get { return __________最大负载指标; }
				set { __________最大负载指标 = value; }
			}
		}

		[Serializable]
		public partial class 系统_认证服务器状态Collection : List<系统_认证服务器状态>
		{
            public 系统_认证服务器状态Collection() { }
            public 系统_认证服务器状态Collection(IEnumerable<系统_认证服务器状态> items)
            {
                base.AddRange(items);
            }

			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public 系统_认证服务器状态 Add(int ServiceInstanceID, string 服务器地址, int 服务器端口, int 当前连接数量, int 低负载指标, int 中负载指标, int 高负载指标, int 最大负载指标)
			{
				系统_认证服务器状态 o = new 系统_认证服务器状态(ServiceInstanceID, 服务器地址, 服务器端口, 当前连接数量, 低负载指标, 中负载指标, 高负载指标, 最大负载指标);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(系统_认证服务器状态Collection __os)
			{
				int i = 0;
				foreach (系统_认证服务器状态 __o in __os)
				{
					系统_认证服务器状态 __oo = this.Find(new Predicate<系统_认证服务器状态>(delegate(系统_认证服务器状态 _o) { return _o.PrimaryKeyEquals(__o); }));
					if (__oo != null)
					{
						if (!__o.Equals(__oo))
						{
							__o.CopyTo(__oo);
							i++;
						}
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class 系统_认证服务器状态Collection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public 系统_认证服务器状态Collection Rows;
		}

		#endregion

		#endregion

		#region Views

		#endregion

		#region User Defined Function Tables

		#region dbo_uf_Split

		/// <summary>
		/// 
		/// </summary>
		[DataContract]
		[Serializable]
		public partial class dbo_uf_Split
		{
			#region 私有成员

			protected int __________id;
			protected string __________item;

			#endregion

			#region 构造函数

			public dbo_uf_Split()
			{
			}
			public dbo_uf_Split(int id, string item)
			{
				__________id = id;
				__________item = item;
			}

			#endregion
			
			#region 复制方法

			/// <summary>
			/// 将当前对象的值覆盖到另一同类型对象
			/// </summary>
			public virtual void CopyTo(dbo_uf_Split __oo)
			{
				__oo.id = this.id;
				__oo.item = this.item;
			}

			/// <summary>
			/// 从另一同类型对象中复制值覆盖到当前对象
			/// </summary>
			public virtual void CopyFrom(dbo_uf_Split __oo)
			{
				this.id = __oo.id;
				this.item = __oo.item;
			}

			/// <summary>
			/// 复制一份当前对象成为一个新实例返回
			/// </summary>
			public virtual dbo_uf_Split Copy()
			{
				dbo_uf_Split __oo = new dbo_uf_Split();
				__oo.id = this.id;
				__oo.item = this.item;
				return __oo;
			}

			#endregion

			#region 比较方法

			/// <summary>
			/// 比较当前对象和传入对象的值是否相等
			/// </summary>
			public virtual bool Equals(dbo_uf_Split __o)
			{
				if (this == __o) return true;
				if (
					this.id == __o.id
					&& this.item == __o.item
				) return true;
				return false;
			}

			#endregion

			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public int id
			{
				get { return __________id; }
				set { __________id = value; }
			}
			/// <summary>
			/// 
			/// </summary>
			[DataMember]
			public string item
			{
				get { return __________item; }
				set { __________item = value; }
			}
		}

		[Serializable]
		public partial class dbo_uf_SplitCollection : List<dbo_uf_Split>
		{
			/// <summary>
			/// 直接往集合添加某元数的值，并返回某元素的实例
			/// </summary>
			public dbo_uf_Split Add(int id, string item)
			{
				dbo_uf_Split o = new dbo_uf_Split(id, item);
				this.Add(o);
				return o;
			}

			/// <summary>
			/// 合并另一个结果集到当前集合（主键相同则替换原值，不同则新增） 返回受影响行数
			/// </summary>
			public int Combine(dbo_uf_SplitCollection __os)
			{
				int i = 0;
				foreach (dbo_uf_Split __o in __os)
				{
					dbo_uf_Split __oo = this.Find(new Predicate<dbo_uf_Split>(delegate(dbo_uf_Split _o) { return _o.Equals(__o); }));
					if (__oo != null)
					{
						__o.CopyTo(__oo);
						i++;
					}
					else
					{
						this.Add(__o);
						i++;
					}
				}
				return i;
			}
		}

		[DataContract]
		[Serializable]
		public partial class dbo_uf_SplitCollection_With_Count
		{
			[DataMember]
			
			public int Count;
			[DataMember]
			
			public dbo_uf_SplitCollection Rows;
		}

		#endregion

		#endregion

	}
}