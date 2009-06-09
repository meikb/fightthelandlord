using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	/// <summary>
	/// 对应于数据库 TWQP 中的表，视图，表值函数的字段结构枚举
	/// </summary>
	public static partial class DI
	{

		#region Tables

		#region Game_Action

		/// <summary>
		/// 
		/// </summary>
		public enum Game_Action
		{
		/// <summary>
		/// 
		/// </summary>
			GameID = 1,
		/// <summary>
		/// 
		/// </summary>
			DataTypeID,
		/// <summary>
		/// 
		/// </summary>
			ActionID,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_ActionSortDictionary : Dictionary<Game_Action, bool>
		{
			public Game_ActionSortDictionary(Game_Action col) : base()
			{
				this.Add(col, true);
			}
			public Game_ActionSortDictionary(Game_Action col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_ActionSortDictionary(Game_Action col1, bool IsAscending1, Game_Action col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_ActionSortDictionary(Game_Action col1, bool IsAscending1, Game_Action col2, bool IsAscending2, Game_Action col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_Action, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_Action.GameID) s += "[GameID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Action.DataTypeID) s += "[DataTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Action.ActionID) s += "[ActionID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Action.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Action.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_ActionCollection : List<Game_Action>
		{
		}

		#endregion

		#region Game_Desk

		/// <summary>
		/// 
		/// </summary>
		public enum Game_Desk
		{
		/// <summary>
		/// 
		/// </summary>
			DeskTypeID = 1,
		/// <summary>
		/// 
		/// </summary>
			LobbyID,
		/// <summary>
		/// 
		/// </summary>
			DeskID,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_DeskSortDictionary : Dictionary<Game_Desk, bool>
		{
			public Game_DeskSortDictionary(Game_Desk col) : base()
			{
				this.Add(col, true);
			}
			public Game_DeskSortDictionary(Game_Desk col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_DeskSortDictionary(Game_Desk col1, bool IsAscending1, Game_Desk col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_DeskSortDictionary(Game_Desk col1, bool IsAscending1, Game_Desk col2, bool IsAscending2, Game_Desk col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_Desk, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_Desk.DeskTypeID) s += "[DeskTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Desk.LobbyID) s += "[LobbyID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Desk.DeskID) s += "[DeskID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Desk.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Desk.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_DeskCollection : List<Game_Desk>
		{
		}

		#endregion

		#region Game_DeskActionLog

		/// <summary>
		/// 
		/// </summary>
		public enum Game_DeskActionLog
		{
		/// <summary>
		/// 
		/// </summary>
			DeskActionLogID = 1,
		/// <summary>
		/// 
		/// </summary>
			DeskID,
		/// <summary>
		/// 
		/// </summary>
			ActionID,
		/// <summary>
		/// 
		/// </summary>
			SourceCharacterID,
		/// <summary>
		/// 
		/// </summary>
			TargetCharacterID,
		/// <summary>
		/// 
		/// </summary>
			Data,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_DeskActionLogSortDictionary : Dictionary<Game_DeskActionLog, bool>
		{
			public Game_DeskActionLogSortDictionary(Game_DeskActionLog col) : base()
			{
				this.Add(col, true);
			}
			public Game_DeskActionLogSortDictionary(Game_DeskActionLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_DeskActionLogSortDictionary(Game_DeskActionLog col1, bool IsAscending1, Game_DeskActionLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_DeskActionLogSortDictionary(Game_DeskActionLog col1, bool IsAscending1, Game_DeskActionLog col2, bool IsAscending2, Game_DeskActionLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_DeskActionLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_DeskActionLog.DeskActionLogID) s += "[DeskActionLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskActionLog.DeskID) s += "[DeskID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskActionLog.ActionID) s += "[ActionID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskActionLog.SourceCharacterID) s += "[SourceCharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskActionLog.TargetCharacterID) s += "[TargetCharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskActionLog.Data) s += "[Data]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskActionLog.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_DeskActionLogCollection : List<Game_DeskActionLog>
		{
		}

		#endregion

		#region Game_DeskProfile

		/// <summary>
		/// 
		/// </summary>
		public enum Game_DeskProfile
		{
		/// <summary>
		/// 
		/// </summary>
			DeskID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_DeskProfileSortDictionary : Dictionary<Game_DeskProfile, bool>
		{
			public Game_DeskProfileSortDictionary(Game_DeskProfile col) : base()
			{
				this.Add(col, true);
			}
			public Game_DeskProfileSortDictionary(Game_DeskProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_DeskProfileSortDictionary(Game_DeskProfile col1, bool IsAscending1, Game_DeskProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_DeskProfileSortDictionary(Game_DeskProfile col1, bool IsAscending1, Game_DeskProfile col2, bool IsAscending2, Game_DeskProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_DeskProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_DeskProfile.DeskID) s += "[DeskID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_DeskProfileCollection : List<Game_DeskProfile>
		{
		}

		#endregion

		#region Game_DeskType

		/// <summary>
		/// 
		/// </summary>
		public enum Game_DeskType
		{
		/// <summary>
		/// 
		/// </summary>
			DeskTypeID = 1,
		/// <summary>
		/// 
		/// </summary>
			GameID,
		/// <summary>
		/// 
		/// </summary>
			NumPerson,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_DeskTypeSortDictionary : Dictionary<Game_DeskType, bool>
		{
			public Game_DeskTypeSortDictionary(Game_DeskType col) : base()
			{
				this.Add(col, true);
			}
			public Game_DeskTypeSortDictionary(Game_DeskType col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_DeskTypeSortDictionary(Game_DeskType col1, bool IsAscending1, Game_DeskType col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_DeskTypeSortDictionary(Game_DeskType col1, bool IsAscending1, Game_DeskType col2, bool IsAscending2, Game_DeskType col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_DeskType, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_DeskType.DeskTypeID) s += "[DeskTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskType.GameID) s += "[GameID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskType.NumPerson) s += "[NumPerson]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_DeskTypeCollection : List<Game_DeskType>
		{
		}

		#endregion

		#region Game_DeskTypeProfile

		/// <summary>
		/// 
		/// </summary>
		public enum Game_DeskTypeProfile
		{
		/// <summary>
		/// 
		/// </summary>
			DeskTypeID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_DeskTypeProfileSortDictionary : Dictionary<Game_DeskTypeProfile, bool>
		{
			public Game_DeskTypeProfileSortDictionary(Game_DeskTypeProfile col) : base()
			{
				this.Add(col, true);
			}
			public Game_DeskTypeProfileSortDictionary(Game_DeskTypeProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_DeskTypeProfileSortDictionary(Game_DeskTypeProfile col1, bool IsAscending1, Game_DeskTypeProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_DeskTypeProfileSortDictionary(Game_DeskTypeProfile col1, bool IsAscending1, Game_DeskTypeProfile col2, bool IsAscending2, Game_DeskTypeProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_DeskTypeProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_DeskTypeProfile.DeskTypeID) s += "[DeskTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskTypeProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskTypeProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskTypeProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_DeskTypeProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_DeskTypeProfileCollection : List<Game_DeskTypeProfile>
		{
		}

		#endregion

		#region Game_Game

		/// <summary>
		/// 
		/// </summary>
		public enum Game_Game
		{
		/// <summary>
		/// 
		/// </summary>
			GameID = 1,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Version,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_GameSortDictionary : Dictionary<Game_Game, bool>
		{
			public Game_GameSortDictionary(Game_Game col) : base()
			{
				this.Add(col, true);
			}
			public Game_GameSortDictionary(Game_Game col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_GameSortDictionary(Game_Game col1, bool IsAscending1, Game_Game col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_GameSortDictionary(Game_Game col1, bool IsAscending1, Game_Game col2, bool IsAscending2, Game_Game col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_Game, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_Game.GameID) s += "[GameID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Game.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Game.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Game.Version) s += "[Version]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Game.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_GameCollection : List<Game_Game>
		{
		}

		#endregion

		#region Game_GameProfile

		/// <summary>
		/// 
		/// </summary>
		public enum Game_GameProfile
		{
		/// <summary>
		/// 
		/// </summary>
			GameID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_GameProfileSortDictionary : Dictionary<Game_GameProfile, bool>
		{
			public Game_GameProfileSortDictionary(Game_GameProfile col) : base()
			{
				this.Add(col, true);
			}
			public Game_GameProfileSortDictionary(Game_GameProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_GameProfileSortDictionary(Game_GameProfile col1, bool IsAscending1, Game_GameProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_GameProfileSortDictionary(Game_GameProfile col1, bool IsAscending1, Game_GameProfile col2, bool IsAscending2, Game_GameProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_GameProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_GameProfile.GameID) s += "[GameID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_GameProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_GameProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_GameProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_GameProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_GameProfileCollection : List<Game_GameProfile>
		{
		}

		#endregion

		#region Game_Lobby

		/// <summary>
		/// 
		/// </summary>
		public enum Game_Lobby
		{
		/// <summary>
		/// 
		/// </summary>
			ParentLobbyID = 1,
		/// <summary>
		/// 
		/// </summary>
			LobbyID,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		/// <summary>
		/// 
		/// </summary>
			Version,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_LobbySortDictionary : Dictionary<Game_Lobby, bool>
		{
			public Game_LobbySortDictionary(Game_Lobby col) : base()
			{
				this.Add(col, true);
			}
			public Game_LobbySortDictionary(Game_Lobby col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_LobbySortDictionary(Game_Lobby col1, bool IsAscending1, Game_Lobby col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_LobbySortDictionary(Game_Lobby col1, bool IsAscending1, Game_Lobby col2, bool IsAscending2, Game_Lobby col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_Lobby, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_Lobby.ParentLobbyID) s += "[ParentLobbyID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Lobby.LobbyID) s += "[LobbyID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Lobby.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Lobby.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Lobby.Version) s += "[Version]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Lobby.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_LobbyCollection : List<Game_Lobby>
		{
		}

		#endregion

		#region Game_LobbyProfile

		/// <summary>
		/// 
		/// </summary>
		public enum Game_LobbyProfile
		{
		/// <summary>
		/// 
		/// </summary>
			LobbyID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_LobbyProfileSortDictionary : Dictionary<Game_LobbyProfile, bool>
		{
			public Game_LobbyProfileSortDictionary(Game_LobbyProfile col) : base()
			{
				this.Add(col, true);
			}
			public Game_LobbyProfileSortDictionary(Game_LobbyProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_LobbyProfileSortDictionary(Game_LobbyProfile col1, bool IsAscending1, Game_LobbyProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_LobbyProfileSortDictionary(Game_LobbyProfile col1, bool IsAscending1, Game_LobbyProfile col2, bool IsAscending2, Game_LobbyProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_LobbyProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_LobbyProfile.LobbyID) s += "[LobbyID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_LobbyProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_LobbyProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_LobbyProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_LobbyProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_LobbyProfileCollection : List<Game_LobbyProfile>
		{
		}

		#endregion

		#region Game_Seat

		/// <summary>
		/// 
		/// </summary>
		public enum Game_Seat
		{
		/// <summary>
		/// 
		/// </summary>
			DeskID = 1,
		/// <summary>
		/// 
		/// </summary>
			SeatID,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_SeatSortDictionary : Dictionary<Game_Seat, bool>
		{
			public Game_SeatSortDictionary(Game_Seat col) : base()
			{
				this.Add(col, true);
			}
			public Game_SeatSortDictionary(Game_Seat col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_SeatSortDictionary(Game_Seat col1, bool IsAscending1, Game_Seat col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_SeatSortDictionary(Game_Seat col1, bool IsAscending1, Game_Seat col2, bool IsAscending2, Game_Seat col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_Seat, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_Seat.DeskID) s += "[DeskID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Seat.SeatID) s += "[SeatID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Seat.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_Seat.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_SeatCollection : List<Game_Seat>
		{
		}

		#endregion

		#region Game_SeatProfile

		/// <summary>
		/// 
		/// </summary>
		public enum Game_SeatProfile
		{
		/// <summary>
		/// 
		/// </summary>
			SeatID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class Game_SeatProfileSortDictionary : Dictionary<Game_SeatProfile, bool>
		{
			public Game_SeatProfileSortDictionary(Game_SeatProfile col) : base()
			{
				this.Add(col, true);
			}
			public Game_SeatProfileSortDictionary(Game_SeatProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public Game_SeatProfileSortDictionary(Game_SeatProfile col1, bool IsAscending1, Game_SeatProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public Game_SeatProfileSortDictionary(Game_SeatProfile col1, bool IsAscending1, Game_SeatProfile col2, bool IsAscending2, Game_SeatProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<Game_SeatProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == Game_SeatProfile.SeatID) s += "[SeatID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_SeatProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_SeatProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_SeatProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == Game_SeatProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class Game_SeatProfileCollection : List<Game_SeatProfile>
		{
		}

		#endregion

		#region System_DataType

		/// <summary>
		/// 
		/// </summary>
		public enum System_DataType
		{
		/// <summary>
		/// 
		/// </summary>
			DataTypeID = 1,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class System_DataTypeSortDictionary : Dictionary<System_DataType, bool>
		{
			public System_DataTypeSortDictionary(System_DataType col) : base()
			{
				this.Add(col, true);
			}
			public System_DataTypeSortDictionary(System_DataType col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_DataTypeSortDictionary(System_DataType col1, bool IsAscending1, System_DataType col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_DataTypeSortDictionary(System_DataType col1, bool IsAscending1, System_DataType col2, bool IsAscending2, System_DataType col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_DataType, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_DataType.DataTypeID) s += "[DataTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_DataType.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_DataType.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class System_DataTypeCollection : List<System_DataType>
		{
		}

		#endregion

		#region System_DialogResource

		/// <summary>
		/// 
		/// </summary>
		public enum System_DialogResource
		{
		/// <summary>
		/// 
		/// </summary>
			Key = 1,
		/// <summary>
		/// 
		/// </summary>
			ENG,
		/// <summary>
		/// 
		/// </summary>
			CHS,
		/// <summary>
		/// 
		/// </summary>
			CHT,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class System_DialogResourceSortDictionary : Dictionary<System_DialogResource, bool>
		{
			public System_DialogResourceSortDictionary(System_DialogResource col) : base()
			{
				this.Add(col, true);
			}
			public System_DialogResourceSortDictionary(System_DialogResource col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_DialogResourceSortDictionary(System_DialogResource col1, bool IsAscending1, System_DialogResource col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_DialogResourceSortDictionary(System_DialogResource col1, bool IsAscending1, System_DialogResource col2, bool IsAscending2, System_DialogResource col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_DialogResource, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_DialogResource.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_DialogResource.ENG) s += "[ENG]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_DialogResource.CHS) s += "[CHS]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_DialogResource.CHT) s += "[CHT]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class System_DialogResourceCollection : List<System_DialogResource>
		{
		}

		#endregion

		#region System_Service

		/// <summary>
		/// 服务
		/// </summary>
		public enum System_Service
		{
		/// <summary>
		/// 服务类别编号
		/// </summary>
			ServiceTypeID = 1,
		/// <summary>
		/// 服务编号
		/// </summary>
			ServiceID,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		/// <summary>
		/// 服务名
		/// </summary>
			Name,
		/// <summary>
		/// 版本号
		/// </summary>
			Version,
		/// <summary>
		/// 所在网络全路径
		/// </summary>
			FilePath,
		/// <summary>
		/// 备注
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务 排序对象 字典
		/// </summary>
		public class System_ServiceSortDictionary : Dictionary<System_Service, bool>
		{
			public System_ServiceSortDictionary(System_Service col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceSortDictionary(System_Service col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceSortDictionary(System_Service col1, bool IsAscending1, System_Service col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceSortDictionary(System_Service col1, bool IsAscending1, System_Service col2, bool IsAscending2, System_Service col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_Service, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_Service.ServiceTypeID) s += "[ServiceTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Service.ServiceID) s += "[ServiceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Service.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Service.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Service.Version) s += "[Version]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Service.FilePath) s += "[FilePath]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Service.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务 集合
		/// </summary>
		public class System_ServiceCollection : List<System_Service>
		{
		}

		#endregion

		#region System_ServiceInstance

		/// <summary>
		/// 服务配置
		/// </summary>
		public enum System_ServiceInstance
		{
		/// <summary>
		/// 服务编号
		/// </summary>
			ServiceID = 1,
		/// <summary>
		/// 服务配置编号
		/// </summary>
			ServiceInstanceID,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务配置 排序对象 字典
		/// </summary>
		public class System_ServiceInstanceSortDictionary : Dictionary<System_ServiceInstance, bool>
		{
			public System_ServiceInstanceSortDictionary(System_ServiceInstance col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceInstanceSortDictionary(System_ServiceInstance col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceInstanceSortDictionary(System_ServiceInstance col1, bool IsAscending1, System_ServiceInstance col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceInstanceSortDictionary(System_ServiceInstance col1, bool IsAscending1, System_ServiceInstance col2, bool IsAscending2, System_ServiceInstance col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceInstance, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceInstance.ServiceID) s += "[ServiceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务配置 集合
		/// </summary>
		public class System_ServiceInstanceCollection : List<System_ServiceInstance>
		{
		}

		#endregion

		#region System_ServiceInstance_NamedPipe

		/// <summary>
		/// 
		/// </summary>
		public enum System_ServiceInstance_NamedPipe
		{
		/// <summary>
		/// 
		/// </summary>
			ServiceInstanceID = 1,
		/// <summary>
		/// 
		/// </summary>
			Address,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class System_ServiceInstance_NamedPipeSortDictionary : Dictionary<System_ServiceInstance_NamedPipe, bool>
		{
			public System_ServiceInstance_NamedPipeSortDictionary(System_ServiceInstance_NamedPipe col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceInstance_NamedPipeSortDictionary(System_ServiceInstance_NamedPipe col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceInstance_NamedPipeSortDictionary(System_ServiceInstance_NamedPipe col1, bool IsAscending1, System_ServiceInstance_NamedPipe col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceInstance_NamedPipeSortDictionary(System_ServiceInstance_NamedPipe col1, bool IsAscending1, System_ServiceInstance_NamedPipe col2, bool IsAscending2, System_ServiceInstance_NamedPipe col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceInstance_NamedPipe, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceInstance_NamedPipe.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance_NamedPipe.Address) s += "[Address]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class System_ServiceInstance_NamedPipeCollection : List<System_ServiceInstance_NamedPipe>
		{
		}

		#endregion

		#region System_ServiceInstance_TCPIP

		/// <summary>
		/// 
		/// </summary>
		public enum System_ServiceInstance_TCPIP
		{
		/// <summary>
		/// 
		/// </summary>
			ServiceInstanceID = 1,
		/// <summary>
		/// 
		/// </summary>
			IP,
		/// <summary>
		/// 
		/// </summary>
			Port,
		/// <summary>
		/// 
		/// </summary>
			Address,
		/// <summary>
		/// 
		/// </summary>
			MaxReceivedBufferSize,
		/// <summary>
		/// 
		/// </summary>
			etc___,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class System_ServiceInstance_TCPIPSortDictionary : Dictionary<System_ServiceInstance_TCPIP, bool>
		{
			public System_ServiceInstance_TCPIPSortDictionary(System_ServiceInstance_TCPIP col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceInstance_TCPIPSortDictionary(System_ServiceInstance_TCPIP col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceInstance_TCPIPSortDictionary(System_ServiceInstance_TCPIP col1, bool IsAscending1, System_ServiceInstance_TCPIP col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceInstance_TCPIPSortDictionary(System_ServiceInstance_TCPIP col1, bool IsAscending1, System_ServiceInstance_TCPIP col2, bool IsAscending2, System_ServiceInstance_TCPIP col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceInstance_TCPIP, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceInstance_TCPIP.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance_TCPIP.IP) s += "[IP]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance_TCPIP.Port) s += "[Port]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance_TCPIP.Address) s += "[Address]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance_TCPIP.MaxReceivedBufferSize) s += "[MaxReceivedBufferSize]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstance_TCPIP.etc___) s += "[etc...]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class System_ServiceInstance_TCPIPCollection : List<System_ServiceInstance_TCPIP>
		{
		}

		#endregion

		#region System_ServiceInstanceProfile

		/// <summary>
		/// 服务配置附加信息
		/// </summary>
		public enum System_ServiceInstanceProfile
		{
		/// <summary>
		/// 
		/// </summary>
			ServiceInstanceID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务配置附加信息 排序对象 字典
		/// </summary>
		public class System_ServiceInstanceProfileSortDictionary : Dictionary<System_ServiceInstanceProfile, bool>
		{
			public System_ServiceInstanceProfileSortDictionary(System_ServiceInstanceProfile col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceInstanceProfileSortDictionary(System_ServiceInstanceProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceInstanceProfileSortDictionary(System_ServiceInstanceProfile col1, bool IsAscending1, System_ServiceInstanceProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceInstanceProfileSortDictionary(System_ServiceInstanceProfile col1, bool IsAscending1, System_ServiceInstanceProfile col2, bool IsAscending2, System_ServiceInstanceProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceInstanceProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceInstanceProfile.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务配置附加信息 集合
		/// </summary>
		public class System_ServiceInstanceProfileCollection : List<System_ServiceInstanceProfile>
		{
		}

		#endregion

		#region System_ServiceInstanceState

		/// <summary>
		/// 服务运行状态
		/// </summary>
		public enum System_ServiceInstanceState
		{
		/// <summary>
		/// 服务运行状态类型编号
		/// </summary>
			ServiceStateTypeID = 1,
		/// <summary>
		/// 服务配置编号
		/// </summary>
			ServiceInstanceID,
		/// <summary>
		/// 状态开始时间
		/// </summary>
			BeginTime,
		}

		/// <summary>
		/// 服务运行状态 排序对象 字典
		/// </summary>
		public class System_ServiceInstanceStateSortDictionary : Dictionary<System_ServiceInstanceState, bool>
		{
			public System_ServiceInstanceStateSortDictionary(System_ServiceInstanceState col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceInstanceStateSortDictionary(System_ServiceInstanceState col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceInstanceStateSortDictionary(System_ServiceInstanceState col1, bool IsAscending1, System_ServiceInstanceState col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceInstanceStateSortDictionary(System_ServiceInstanceState col1, bool IsAscending1, System_ServiceInstanceState col2, bool IsAscending2, System_ServiceInstanceState col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceInstanceState, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceInstanceState.ServiceStateTypeID) s += "[ServiceStateTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceState.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceState.BeginTime) s += "[BeginTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务运行状态 集合
		/// </summary>
		public class System_ServiceInstanceStateCollection : List<System_ServiceInstanceState>
		{
		}

		#endregion

		#region System_ServiceInstanceStateLog

		/// <summary>
		/// 服务运行状态日志
		/// </summary>
		public enum System_ServiceInstanceStateLog
		{
		/// <summary>
		/// 服务运行状态类型
		/// </summary>
			ServiceStateTypeID = 1,
		/// <summary>
		/// 服务配置编号
		/// </summary>
			ServiceInstanceID,
		/// <summary>
		/// 
		/// </summary>
			ServiceInstanceStateLogID,
		/// <summary>
		/// 状态开始时间
		/// </summary>
			BeginTime,
		/// <summary>
		/// 详细说明
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务运行状态日志 排序对象 字典
		/// </summary>
		public class System_ServiceInstanceStateLogSortDictionary : Dictionary<System_ServiceInstanceStateLog, bool>
		{
			public System_ServiceInstanceStateLogSortDictionary(System_ServiceInstanceStateLog col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceInstanceStateLogSortDictionary(System_ServiceInstanceStateLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceInstanceStateLogSortDictionary(System_ServiceInstanceStateLog col1, bool IsAscending1, System_ServiceInstanceStateLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceInstanceStateLogSortDictionary(System_ServiceInstanceStateLog col1, bool IsAscending1, System_ServiceInstanceStateLog col2, bool IsAscending2, System_ServiceInstanceStateLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceInstanceStateLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceInstanceStateLog.ServiceStateTypeID) s += "[ServiceStateTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceStateLog.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceStateLog.ServiceInstanceStateLogID) s += "[ServiceInstanceStateLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceStateLog.BeginTime) s += "[BeginTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceInstanceStateLog.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务运行状态日志 集合
		/// </summary>
		public class System_ServiceInstanceStateLogCollection : List<System_ServiceInstanceStateLog>
		{
		}

		#endregion

		#region System_ServiceProfile

		/// <summary>
		/// 服务附加信息
		/// </summary>
		public enum System_ServiceProfile
		{
		/// <summary>
		/// 
		/// </summary>
			ServiceID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务附加信息 排序对象 字典
		/// </summary>
		public class System_ServiceProfileSortDictionary : Dictionary<System_ServiceProfile, bool>
		{
			public System_ServiceProfileSortDictionary(System_ServiceProfile col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceProfileSortDictionary(System_ServiceProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceProfileSortDictionary(System_ServiceProfile col1, bool IsAscending1, System_ServiceProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceProfileSortDictionary(System_ServiceProfile col1, bool IsAscending1, System_ServiceProfile col2, bool IsAscending2, System_ServiceProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceProfile.ServiceID) s += "[ServiceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务附加信息 集合
		/// </summary>
		public class System_ServiceProfileCollection : List<System_ServiceProfile>
		{
		}

		#endregion

		#region System_ServiceStateType

		/// <summary>
		/// 服务运行状态类型
		/// </summary>
		public enum System_ServiceStateType
		{
		/// <summary>
		/// 服务状态类型编号
		/// </summary>
			ServiceStateTypeID = 1,
		/// <summary>
		/// 类型名
		/// </summary>
			Name,
		/// <summary>
		/// 说明
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务运行状态类型 排序对象 字典
		/// </summary>
		public class System_ServiceStateTypeSortDictionary : Dictionary<System_ServiceStateType, bool>
		{
			public System_ServiceStateTypeSortDictionary(System_ServiceStateType col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceStateTypeSortDictionary(System_ServiceStateType col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceStateTypeSortDictionary(System_ServiceStateType col1, bool IsAscending1, System_ServiceStateType col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceStateTypeSortDictionary(System_ServiceStateType col1, bool IsAscending1, System_ServiceStateType col2, bool IsAscending2, System_ServiceStateType col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceStateType, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceStateType.ServiceStateTypeID) s += "[ServiceStateTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceStateType.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceStateType.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务运行状态类型 集合
		/// </summary>
		public class System_ServiceStateTypeCollection : List<System_ServiceStateType>
		{
		}

		#endregion

		#region System_ServiceType

		/// <summary>
		/// 服务类别
		/// </summary>
		public enum System_ServiceType
		{
		/// <summary>
		/// 服务类别编号
		/// </summary>
			ServiceTypeID = 1,
		/// <summary>
		/// 类别名
		/// </summary>
			Name,
		/// <summary>
		/// 备注
		/// </summary>
			Description,
		}

		/// <summary>
		/// 服务类别 排序对象 字典
		/// </summary>
		public class System_ServiceTypeSortDictionary : Dictionary<System_ServiceType, bool>
		{
			public System_ServiceTypeSortDictionary(System_ServiceType col) : base()
			{
				this.Add(col, true);
			}
			public System_ServiceTypeSortDictionary(System_ServiceType col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_ServiceTypeSortDictionary(System_ServiceType col1, bool IsAscending1, System_ServiceType col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_ServiceTypeSortDictionary(System_ServiceType col1, bool IsAscending1, System_ServiceType col2, bool IsAscending2, System_ServiceType col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_ServiceType, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_ServiceType.ServiceTypeID) s += "[ServiceTypeID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceType.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_ServiceType.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 服务类别 集合
		/// </summary>
		public class System_ServiceTypeCollection : List<System_ServiceType>
		{
		}

		#endregion

		#region System_Setting

		/// <summary>
		/// 
		/// </summary>
		public enum System_Setting
		{
		/// <summary>
		/// 
		/// </summary>
			Key = 1,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class System_SettingSortDictionary : Dictionary<System_Setting, bool>
		{
			public System_SettingSortDictionary(System_Setting col) : base()
			{
				this.Add(col, true);
			}
			public System_SettingSortDictionary(System_Setting col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public System_SettingSortDictionary(System_Setting col1, bool IsAscending1, System_Setting col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public System_SettingSortDictionary(System_Setting col1, bool IsAscending1, System_Setting col2, bool IsAscending2, System_Setting col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<System_Setting, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == System_Setting.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Setting.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Setting.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == System_Setting.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class System_SettingCollection : List<System_Setting>
		{
		}

		#endregion

		#region User_Account

		/// <summary>
		/// 用户表
		/// </summary>
		public enum User_Account
		{
		/// <summary>
		/// 用户编号
		/// </summary>
			AccountID = 1,
		/// <summary>
		/// 用户名
		/// </summary>
			Username,
		/// <summary>
		/// 当前密码（明文不加密）
		/// </summary>
			Password,
		/// <summary>
		/// 
		/// </summary>
			Gold,
		/// <summary>
		/// 账户创建时间
		/// </summary>
			CreateTime,
		/// <summary>
		/// 备注
		/// </summary>
			Description,
		/// <summary>
		/// 是否启用
		/// </summary>
			IsEnabled,
		}

		/// <summary>
		/// 用户表 排序对象 字典
		/// </summary>
		public class User_AccountSortDictionary : Dictionary<User_Account, bool>
		{
			public User_AccountSortDictionary(User_Account col) : base()
			{
				this.Add(col, true);
			}
			public User_AccountSortDictionary(User_Account col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_AccountSortDictionary(User_Account col1, bool IsAscending1, User_Account col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_AccountSortDictionary(User_Account col1, bool IsAscending1, User_Account col2, bool IsAscending2, User_Account col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_Account, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_Account.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Account.Username) s += "[Username]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Account.Password) s += "[Password]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Account.Gold) s += "[Gold]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Account.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Account.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Account.IsEnabled) s += "[IsEnabled]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		/// 用户表 集合
		/// </summary>
		public class User_AccountCollection : List<User_Account>
		{
		}

		#endregion

		#region User_Character

		/// <summary>
		/// 
		/// </summary>
		public enum User_Character
		{
		/// <summary>
		/// 
		/// </summary>
			AccountID = 1,
		/// <summary>
		/// 
		/// </summary>
			CharacterID,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		/// <summary>
		/// 
		/// </summary>
			IsDeleted,
		/// <summary>
		/// 
		/// </summary>
			IsEnabled,
		/// <summary>
		/// 
		/// </summary>
			Gold,
		/// <summary>
		/// 
		/// </summary>
			IsOnline,
		/// <summary>
		/// 
		/// </summary>
			Ticket,
		/// <summary>
		/// 
		/// </summary>
			TicketExpireTime,
		/// <summary>
		/// 
		/// </summary>
			SeatID,
		/// <summary>
		/// 
		/// </summary>
			SeatTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_CharacterSortDictionary : Dictionary<User_Character, bool>
		{
			public User_CharacterSortDictionary(User_Character col) : base()
			{
				this.Add(col, true);
			}
			public User_CharacterSortDictionary(User_Character col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_CharacterSortDictionary(User_Character col1, bool IsAscending1, User_Character col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_CharacterSortDictionary(User_Character col1, bool IsAscending1, User_Character col2, bool IsAscending2, User_Character col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_Character, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_Character.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.IsDeleted) s += "[IsDeleted]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.IsEnabled) s += "[IsEnabled]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.Gold) s += "[Gold]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.IsOnline) s += "[IsOnline]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.Ticket) s += "[Ticket]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.TicketExpireTime) s += "[TicketExpireTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.SeatID) s += "[SeatID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Character.SeatTime) s += "[SeatTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_CharacterCollection : List<User_Character>
		{
		}

		#endregion

		#region User_CharacterGameProfile

		/// <summary>
		/// 
		/// </summary>
		public enum User_CharacterGameProfile
		{
		/// <summary>
		/// 
		/// </summary>
			CharacterID = 1,
		/// <summary>
		/// 
		/// </summary>
			GameID,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_CharacterGameProfileSortDictionary : Dictionary<User_CharacterGameProfile, bool>
		{
			public User_CharacterGameProfileSortDictionary(User_CharacterGameProfile col) : base()
			{
				this.Add(col, true);
			}
			public User_CharacterGameProfileSortDictionary(User_CharacterGameProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_CharacterGameProfileSortDictionary(User_CharacterGameProfile col1, bool IsAscending1, User_CharacterGameProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_CharacterGameProfileSortDictionary(User_CharacterGameProfile col1, bool IsAscending1, User_CharacterGameProfile col2, bool IsAscending2, User_CharacterGameProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_CharacterGameProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_CharacterGameProfile.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGameProfile.GameID) s += "[GameID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGameProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGameProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGameProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGameProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_CharacterGameProfileCollection : List<User_CharacterGameProfile>
		{
		}

		#endregion

		#region User_CharacterGoldLog

		/// <summary>
		/// 
		/// </summary>
		public enum User_CharacterGoldLog
		{
		/// <summary>
		/// 
		/// </summary>
			CharacterGoldLogID = 1,
		/// <summary>
		/// 
		/// </summary>
			DeskActionLogID,
		/// <summary>
		/// 
		/// </summary>
			CharacterID,
		/// <summary>
		/// 
		/// </summary>
			Value,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_CharacterGoldLogSortDictionary : Dictionary<User_CharacterGoldLog, bool>
		{
			public User_CharacterGoldLogSortDictionary(User_CharacterGoldLog col) : base()
			{
				this.Add(col, true);
			}
			public User_CharacterGoldLogSortDictionary(User_CharacterGoldLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_CharacterGoldLogSortDictionary(User_CharacterGoldLog col1, bool IsAscending1, User_CharacterGoldLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_CharacterGoldLogSortDictionary(User_CharacterGoldLog col1, bool IsAscending1, User_CharacterGoldLog col2, bool IsAscending2, User_CharacterGoldLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_CharacterGoldLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_CharacterGoldLog.CharacterGoldLogID) s += "[CharacterGoldLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGoldLog.DeskActionLogID) s += "[DeskActionLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGoldLog.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterGoldLog.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_CharacterGoldLogCollection : List<User_CharacterGoldLog>
		{
		}

		#endregion

		#region User_CharacterOnlineLog

		/// <summary>
		/// 
		/// </summary>
		public enum User_CharacterOnlineLog
		{
		/// <summary>
		/// 
		/// </summary>
			CharacterOnlineLogID = 1,
		/// <summary>
		/// 
		/// </summary>
			CharacterID,
		/// <summary>
		/// 
		/// </summary>
			IsOnline,
		/// <summary>
		/// 
		/// </summary>
			BeginTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_CharacterOnlineLogSortDictionary : Dictionary<User_CharacterOnlineLog, bool>
		{
			public User_CharacterOnlineLogSortDictionary(User_CharacterOnlineLog col) : base()
			{
				this.Add(col, true);
			}
			public User_CharacterOnlineLogSortDictionary(User_CharacterOnlineLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_CharacterOnlineLogSortDictionary(User_CharacterOnlineLog col1, bool IsAscending1, User_CharacterOnlineLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_CharacterOnlineLogSortDictionary(User_CharacterOnlineLog col1, bool IsAscending1, User_CharacterOnlineLog col2, bool IsAscending2, User_CharacterOnlineLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_CharacterOnlineLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_CharacterOnlineLog.CharacterOnlineLogID) s += "[CharacterOnlineLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterOnlineLog.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterOnlineLog.IsOnline) s += "[IsOnline]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterOnlineLog.BeginTime) s += "[BeginTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_CharacterOnlineLogCollection : List<User_CharacterOnlineLog>
		{
		}

		#endregion

		#region User_CharacterProfile

		/// <summary>
		/// 
		/// </summary>
		public enum User_CharacterProfile
		{
		/// <summary>
		/// 
		/// </summary>
			CharacterID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_CharacterProfileSortDictionary : Dictionary<User_CharacterProfile, bool>
		{
			public User_CharacterProfileSortDictionary(User_CharacterProfile col) : base()
			{
				this.Add(col, true);
			}
			public User_CharacterProfileSortDictionary(User_CharacterProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_CharacterProfileSortDictionary(User_CharacterProfile col1, bool IsAscending1, User_CharacterProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_CharacterProfileSortDictionary(User_CharacterProfile col1, bool IsAscending1, User_CharacterProfile col2, bool IsAscending2, User_CharacterProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_CharacterProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_CharacterProfile.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_CharacterProfileCollection : List<User_CharacterProfile>
		{
		}

		#endregion

		#region User_CharacterSeatLog

		/// <summary>
		/// 
		/// </summary>
		public enum User_CharacterSeatLog
		{
		/// <summary>
		/// 
		/// </summary>
			CharacterSeatLogID = 1,
		/// <summary>
		/// 
		/// </summary>
			CharacterID,
		/// <summary>
		/// 
		/// </summary>
			SeatID,
		/// <summary>
		/// 
		/// </summary>
			SeatTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_CharacterSeatLogSortDictionary : Dictionary<User_CharacterSeatLog, bool>
		{
			public User_CharacterSeatLogSortDictionary(User_CharacterSeatLog col) : base()
			{
				this.Add(col, true);
			}
			public User_CharacterSeatLogSortDictionary(User_CharacterSeatLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_CharacterSeatLogSortDictionary(User_CharacterSeatLog col1, bool IsAscending1, User_CharacterSeatLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_CharacterSeatLogSortDictionary(User_CharacterSeatLog col1, bool IsAscending1, User_CharacterSeatLog col2, bool IsAscending2, User_CharacterSeatLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_CharacterSeatLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_CharacterSeatLog.CharacterSeatLogID) s += "[CharacterSeatLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterSeatLog.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterSeatLog.SeatID) s += "[SeatID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_CharacterSeatLog.SeatTime) s += "[SeatTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_CharacterSeatLogCollection : List<User_CharacterSeatLog>
		{
		}

		#endregion

		#region User_Message

		/// <summary>
		/// 
		/// </summary>
		public enum User_Message
		{
		/// <summary>
		/// 
		/// </summary>
			CharacterID = 1,
		/// <summary>
		/// 
		/// </summary>
			MessageID,
		/// <summary>
		/// 
		/// </summary>
			Content,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_MessageSortDictionary : Dictionary<User_Message, bool>
		{
			public User_MessageSortDictionary(User_Message col) : base()
			{
				this.Add(col, true);
			}
			public User_MessageSortDictionary(User_Message col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_MessageSortDictionary(User_Message col1, bool IsAscending1, User_Message col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_MessageSortDictionary(User_Message col1, bool IsAscending1, User_Message col2, bool IsAscending2, User_Message col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_Message, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_Message.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Message.MessageID) s += "[MessageID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Message.Content) s += "[Content]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Message.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_MessageCollection : List<User_Message>
		{
		}

		#endregion

		#region User_MessageReceive

		/// <summary>
		/// 
		/// </summary>
		public enum User_MessageReceive
		{
		/// <summary>
		/// 
		/// </summary>
			MessageID = 1,
		/// <summary>
		/// 
		/// </summary>
			CharacterID,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_MessageReceiveSortDictionary : Dictionary<User_MessageReceive, bool>
		{
			public User_MessageReceiveSortDictionary(User_MessageReceive col) : base()
			{
				this.Add(col, true);
			}
			public User_MessageReceiveSortDictionary(User_MessageReceive col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_MessageReceiveSortDictionary(User_MessageReceive col1, bool IsAscending1, User_MessageReceive col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_MessageReceiveSortDictionary(User_MessageReceive col1, bool IsAscending1, User_MessageReceive col2, bool IsAscending2, User_MessageReceive col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_MessageReceive, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_MessageReceive.MessageID) s += "[MessageID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_MessageReceive.CharacterID) s += "[CharacterID]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_MessageReceiveCollection : List<User_MessageReceive>
		{
		}

		#endregion

		#region User_PasswordLog

		/// <summary>
		/// 
		/// </summary>
		public enum User_PasswordLog
		{
		/// <summary>
		/// 
		/// </summary>
			AccountID = 1,
		/// <summary>
		/// 
		/// </summary>
			Password,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_PasswordLogSortDictionary : Dictionary<User_PasswordLog, bool>
		{
			public User_PasswordLogSortDictionary(User_PasswordLog col) : base()
			{
				this.Add(col, true);
			}
			public User_PasswordLogSortDictionary(User_PasswordLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_PasswordLogSortDictionary(User_PasswordLog col1, bool IsAscending1, User_PasswordLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_PasswordLogSortDictionary(User_PasswordLog col1, bool IsAscending1, User_PasswordLog col2, bool IsAscending2, User_PasswordLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_PasswordLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_PasswordLog.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_PasswordLog.Password) s += "[Password]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_PasswordLog.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_PasswordLogCollection : List<User_PasswordLog>
		{
		}

		#endregion

		#region User_PurchaseCreditLog

		/// <summary>
		/// 
		/// </summary>
		public enum User_PurchaseCreditLog
		{
		/// <summary>
		/// 
		/// </summary>
			PurchaseCreditLogID = 1,
		/// <summary>
		/// 
		/// </summary>
			AccountID,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			CreateTime,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_PurchaseCreditLogSortDictionary : Dictionary<User_PurchaseCreditLog, bool>
		{
			public User_PurchaseCreditLogSortDictionary(User_PurchaseCreditLog col) : base()
			{
				this.Add(col, true);
			}
			public User_PurchaseCreditLogSortDictionary(User_PurchaseCreditLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_PurchaseCreditLogSortDictionary(User_PurchaseCreditLog col1, bool IsAscending1, User_PurchaseCreditLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_PurchaseCreditLogSortDictionary(User_PurchaseCreditLog col1, bool IsAscending1, User_PurchaseCreditLog col2, bool IsAscending2, User_PurchaseCreditLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_PurchaseCreditLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_PurchaseCreditLog.PurchaseCreditLogID) s += "[PurchaseCreditLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_PurchaseCreditLog.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_PurchaseCreditLog.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_PurchaseCreditLog.CreateTime) s += "[CreateTime]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_PurchaseCreditLogCollection : List<User_PurchaseCreditLog>
		{
		}

		#endregion

		#region User_Role

		/// <summary>
		/// 
		/// </summary>
		public enum User_Role
		{
		/// <summary>
		/// 
		/// </summary>
			RoleID = 1,
		/// <summary>
		/// 
		/// </summary>
			Name,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_RoleSortDictionary : Dictionary<User_Role, bool>
		{
			public User_RoleSortDictionary(User_Role col) : base()
			{
				this.Add(col, true);
			}
			public User_RoleSortDictionary(User_Role col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_RoleSortDictionary(User_Role col1, bool IsAscending1, User_Role col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_RoleSortDictionary(User_Role col1, bool IsAscending1, User_Role col2, bool IsAscending2, User_Role col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_Role, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_Role.RoleID) s += "[RoleID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Role.Name) s += "[Name]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_Role.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_RoleCollection : List<User_Role>
		{
		}

		#endregion

		#region User_User_Role

		/// <summary>
		/// 
		/// </summary>
		public enum User_User_Role
		{
		/// <summary>
		/// 
		/// </summary>
			AccountID = 1,
		/// <summary>
		/// 
		/// </summary>
			RoleID,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_User_RoleSortDictionary : Dictionary<User_User_Role, bool>
		{
			public User_User_RoleSortDictionary(User_User_Role col) : base()
			{
				this.Add(col, true);
			}
			public User_User_RoleSortDictionary(User_User_Role col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_User_RoleSortDictionary(User_User_Role col1, bool IsAscending1, User_User_Role col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_User_RoleSortDictionary(User_User_Role col1, bool IsAscending1, User_User_Role col2, bool IsAscending2, User_User_Role col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_User_Role, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_User_Role.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_User_Role.RoleID) s += "[RoleID]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_User_RoleCollection : List<User_User_Role>
		{
		}

		#endregion

		#region User_UserConnectLog

		/// <summary>
		/// 
		/// </summary>
		public enum User_UserConnectLog
		{
		/// <summary>
		/// 
		/// </summary>
			UserConnectLogID = 1,
		/// <summary>
		/// 
		/// </summary>
			AccountID,
		/// <summary>
		/// 
		/// </summary>
			BeginTime,
		/// <summary>
		/// 
		/// </summary>
			IsConnect,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_UserConnectLogSortDictionary : Dictionary<User_UserConnectLog, bool>
		{
			public User_UserConnectLogSortDictionary(User_UserConnectLog col) : base()
			{
				this.Add(col, true);
			}
			public User_UserConnectLogSortDictionary(User_UserConnectLog col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_UserConnectLogSortDictionary(User_UserConnectLog col1, bool IsAscending1, User_UserConnectLog col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_UserConnectLogSortDictionary(User_UserConnectLog col1, bool IsAscending1, User_UserConnectLog col2, bool IsAscending2, User_UserConnectLog col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_UserConnectLog, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_UserConnectLog.UserConnectLogID) s += "[UserConnectLogID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserConnectLog.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserConnectLog.BeginTime) s += "[BeginTime]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserConnectLog.IsConnect) s += "[IsConnect]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_UserConnectLogCollection : List<User_UserConnectLog>
		{
		}

		#endregion

		#region User_UserOnlineCounter

		/// <summary>
		/// 
		/// </summary>
		public enum User_UserOnlineCounter
		{
		/// <summary>
		/// 
		/// </summary>
			AccountID = 1,
		/// <summary>
		/// 
		/// </summary>
			Count,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_UserOnlineCounterSortDictionary : Dictionary<User_UserOnlineCounter, bool>
		{
			public User_UserOnlineCounterSortDictionary(User_UserOnlineCounter col) : base()
			{
				this.Add(col, true);
			}
			public User_UserOnlineCounterSortDictionary(User_UserOnlineCounter col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_UserOnlineCounterSortDictionary(User_UserOnlineCounter col1, bool IsAscending1, User_UserOnlineCounter col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_UserOnlineCounterSortDictionary(User_UserOnlineCounter col1, bool IsAscending1, User_UserOnlineCounter col2, bool IsAscending2, User_UserOnlineCounter col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_UserOnlineCounter, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_UserOnlineCounter.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserOnlineCounter.Count) s += "[Count]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_UserOnlineCounterCollection : List<User_UserOnlineCounter>
		{
		}

		#endregion

		#region User_UserProfile

		/// <summary>
		/// 
		/// </summary>
		public enum User_UserProfile
		{
		/// <summary>
		/// 
		/// </summary>
			AccountID = 1,
		/// <summary>
		/// 
		/// </summary>
			Key,
		/// <summary>
		/// 
		/// </summary>
			Value,
		/// <summary>
		/// 
		/// </summary>
			DefaultValue,
		/// <summary>
		/// 
		/// </summary>
			Description,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class User_UserProfileSortDictionary : Dictionary<User_UserProfile, bool>
		{
			public User_UserProfileSortDictionary(User_UserProfile col) : base()
			{
				this.Add(col, true);
			}
			public User_UserProfileSortDictionary(User_UserProfile col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public User_UserProfileSortDictionary(User_UserProfile col1, bool IsAscending1, User_UserProfile col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public User_UserProfileSortDictionary(User_UserProfile col1, bool IsAscending1, User_UserProfile col2, bool IsAscending2, User_UserProfile col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<User_UserProfile, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == User_UserProfile.AccountID) s += "[AccountID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserProfile.Key) s += "[Key]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserProfile.Value) s += "[Value]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserProfile.DefaultValue) s += "[DefaultValue]" + (kv.Value ? "" : " DESC");
					if (kv.Key == User_UserProfile.Description) s += "[Description]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class User_UserProfileCollection : List<User_UserProfile>
		{
		}

		#endregion

		#region 系统_认证服务器状态

		/// <summary>
		/// 
		/// </summary>
		public enum 系统_认证服务器状态
		{
		/// <summary>
		/// 
		/// </summary>
			ServiceInstanceID = 1,
		/// <summary>
		/// 
		/// </summary>
			服务器地址,
		/// <summary>
		/// 
		/// </summary>
			服务器端口,
		/// <summary>
		/// 
		/// </summary>
			当前连接数量,
		/// <summary>
		/// 
		/// </summary>
			低负载指标,
		/// <summary>
		/// 
		/// </summary>
			中负载指标,
		/// <summary>
		/// 
		/// </summary>
			高负载指标,
		/// <summary>
		/// 
		/// </summary>
			最大负载指标,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class 系统_认证服务器状态SortDictionary : Dictionary<系统_认证服务器状态, bool>
		{
			public 系统_认证服务器状态SortDictionary(系统_认证服务器状态 col) : base()
			{
				this.Add(col, true);
			}
			public 系统_认证服务器状态SortDictionary(系统_认证服务器状态 col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public 系统_认证服务器状态SortDictionary(系统_认证服务器状态 col1, bool IsAscending1, 系统_认证服务器状态 col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public 系统_认证服务器状态SortDictionary(系统_认证服务器状态 col1, bool IsAscending1, 系统_认证服务器状态 col2, bool IsAscending2, 系统_认证服务器状态 col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<系统_认证服务器状态, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == 系统_认证服务器状态.ServiceInstanceID) s += "[ServiceInstanceID]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.服务器地址) s += "[服务器地址]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.服务器端口) s += "[服务器端口]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.当前连接数量) s += "[当前连接数量]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.低负载指标) s += "[低负载指标]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.中负载指标) s += "[中负载指标]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.高负载指标) s += "[高负载指标]" + (kv.Value ? "" : " DESC");
					if (kv.Key == 系统_认证服务器状态.最大负载指标) s += "[最大负载指标]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class 系统_认证服务器状态Collection : List<系统_认证服务器状态>
		{
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
		public enum dbo_uf_Split
		{
		/// <summary>
		/// 
		/// </summary>
			id = 1,
		/// <summary>
		/// 
		/// </summary>
			item,
		}

		/// <summary>
		///  排序对象 字典
		/// </summary>
		public class dbo_uf_SplitSortDictionary : Dictionary<dbo_uf_Split, bool>
		{
			public dbo_uf_SplitSortDictionary(dbo_uf_Split col) : base()
			{
				this.Add(col, true);
			}
			public dbo_uf_SplitSortDictionary(dbo_uf_Split col, bool IsAscending) : base()
			{
				this.Add(col, IsAscending);
			}
			public dbo_uf_SplitSortDictionary(dbo_uf_Split col1, bool IsAscending1, dbo_uf_Split col2, bool IsAscending2) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
			}
			public dbo_uf_SplitSortDictionary(dbo_uf_Split col1, bool IsAscending1, dbo_uf_Split col2, bool IsAscending2, dbo_uf_Split col3, bool IsAscending3) : base()
			{
				this.Add(col1, IsAscending1);
				this.Add(col2, IsAscending2);
				this.Add(col3, IsAscending3);
			}

			/// <summary>
			/// 将排序字典转化为 TSQL 查询表达式字串
			/// </summary>
			public override string ToString()
			{
				string s = "";
				foreach(KeyValuePair<dbo_uf_Split, bool> kv in this)
				{
					if (s.Length > 0) s += ", ";
					if (kv.Key == dbo_uf_Split.id) s += "[id]" + (kv.Value ? "" : " DESC");
					if (kv.Key == dbo_uf_Split.item) s += "[item]" + (kv.Value ? "" : " DESC");
				}
				return s;
			}
		}

		/// <summary>
		///  集合
		/// </summary>
		public class dbo_uf_SplitCollection : List<dbo_uf_Split>
		{
		}

		#endregion

		#endregion

		#region Stored Procedures


		/// <summary>
		/// 包含存储过程 usp_Init 的所有参数的类声明
		/// </summary>
		public partial class usp_InitParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


		}


		/// <summary>
		/// 包含存储过程 usp_Service_Init 的所有参数的类声明
		/// </summary>
		public partial class usp_Service_InitParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


		}


		/// <summary>
		/// 包含存储过程 usp_Service_Insert 的所有参数的类声明
		/// </summary>
		public partial class usp_Service_InsertParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


			protected bool _IsServiceTypeIDChanged = false;
			protected int? _ServiceTypeID;
			/// <summary>
			/// 
			/// </summary>
			public int? ServiceTypeID
			{
				get
				{
					return _ServiceTypeID;
				}
				set
				{
					_ServiceTypeID = value;
					_IsServiceTypeIDChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 ServiceTypeID 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsServiceTypeIDChanged()
			{
				return _IsServiceTypeIDChanged;
			}

			protected bool _IsCreateTimeChanged = false;
			protected System.DateTime? _CreateTime;
			/// <summary>
			/// 
			/// </summary>
			public System.DateTime? CreateTime
			{
				get
				{
					return _CreateTime;
				}
				set
				{
					_CreateTime = value;
					_IsCreateTimeChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 CreateTime 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsCreateTimeChanged()
			{
				return _IsCreateTimeChanged;
			}

			protected bool _IsNameChanged = false;
			protected string _Name;
			/// <summary>
			/// 
			/// </summary>
			public string Name
			{
				get
				{
					return _Name;
				}
				set
				{
					_Name = value;
					_IsNameChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Name 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsNameChanged()
			{
				return _IsNameChanged;
			}

			protected bool _IsVersionChanged = false;
			protected int? _Version;
			/// <summary>
			/// 
			/// </summary>
			public int? Version
			{
				get
				{
					return _Version;
				}
				set
				{
					_Version = value;
					_IsVersionChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Version 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsVersionChanged()
			{
				return _IsVersionChanged;
			}

			protected bool _IsFilePathChanged = false;
			protected string _FilePath;
			/// <summary>
			/// 
			/// </summary>
			public string FilePath
			{
				get
				{
					return _FilePath;
				}
				set
				{
					_FilePath = value;
					_IsFilePathChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 FilePath 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsFilePathChanged()
			{
				return _IsFilePathChanged;
			}

			protected bool _IsDescriptionChanged = false;
			protected string _Description;
			/// <summary>
			/// 
			/// </summary>
			public string Description
			{
				get
				{
					return _Description;
				}
				set
				{
					_Description = value;
					_IsDescriptionChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Description 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsDescriptionChanged()
			{
				return _IsDescriptionChanged;
			}

		}


		/// <summary>
		/// 包含存储过程 usp_Service_Update 的所有参数的类声明
		/// </summary>
		public partial class usp_Service_UpdateParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


			protected bool _IsOriginal_ServiceIDChanged = false;
			protected int? _Original_ServiceID;
			/// <summary>
			/// 
			/// </summary>
			public int? Original_ServiceID
			{
				get
				{
					return _Original_ServiceID;
				}
				set
				{
					_Original_ServiceID = value;
					_IsOriginal_ServiceIDChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Original_ServiceID 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsOriginal_ServiceIDChanged()
			{
				return _IsOriginal_ServiceIDChanged;
			}

			protected bool _IsServiceTypeIDChanged = false;
			protected int? _ServiceTypeID;
			/// <summary>
			/// 
			/// </summary>
			public int? ServiceTypeID
			{
				get
				{
					return _ServiceTypeID;
				}
				set
				{
					_ServiceTypeID = value;
					_IsServiceTypeIDChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 ServiceTypeID 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsServiceTypeIDChanged()
			{
				return _IsServiceTypeIDChanged;
			}

			protected bool _IsNameChanged = false;
			protected string _Name;
			/// <summary>
			/// 
			/// </summary>
			public string Name
			{
				get
				{
					return _Name;
				}
				set
				{
					_Name = value;
					_IsNameChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Name 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsNameChanged()
			{
				return _IsNameChanged;
			}

			protected bool _IsVersionChanged = false;
			protected int? _Version;
			/// <summary>
			/// 
			/// </summary>
			public int? Version
			{
				get
				{
					return _Version;
				}
				set
				{
					_Version = value;
					_IsVersionChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Version 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsVersionChanged()
			{
				return _IsVersionChanged;
			}

			protected bool _IsFilePathChanged = false;
			protected string _FilePath;
			/// <summary>
			/// 
			/// </summary>
			public string FilePath
			{
				get
				{
					return _FilePath;
				}
				set
				{
					_FilePath = value;
					_IsFilePathChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 FilePath 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsFilePathChanged()
			{
				return _IsFilePathChanged;
			}

			protected bool _IsDescriptionChanged = false;
			protected string _Description;
			/// <summary>
			/// 
			/// </summary>
			public string Description
			{
				get
				{
					return _Description;
				}
				set
				{
					_Description = value;
					_IsDescriptionChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Description 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsDescriptionChanged()
			{
				return _IsDescriptionChanged;
			}

		}


		/// <summary>
		/// 包含存储过程 usp_ServiceInstance_Insert_NamedPipe 的所有参数的类声明
		/// </summary>
		public partial class usp_ServiceInstance_Insert_NamedPipeParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


			protected bool _IsServiceIDChanged = false;
			protected int? _ServiceID;
			/// <summary>
			/// 
			/// </summary>
			public int? ServiceID
			{
				get
				{
					return _ServiceID;
				}
				set
				{
					_ServiceID = value;
					_IsServiceIDChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 ServiceID 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsServiceIDChanged()
			{
				return _IsServiceIDChanged;
			}

			protected bool _IsCreateTimeChanged = false;
			protected System.DateTime? _CreateTime;
			/// <summary>
			/// 
			/// </summary>
			public System.DateTime? CreateTime
			{
				get
				{
					return _CreateTime;
				}
				set
				{
					_CreateTime = value;
					_IsCreateTimeChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 CreateTime 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsCreateTimeChanged()
			{
				return _IsCreateTimeChanged;
			}

			protected bool _IsDescriptionChanged = false;
			protected string _Description;
			/// <summary>
			/// 
			/// </summary>
			public string Description
			{
				get
				{
					return _Description;
				}
				set
				{
					_Description = value;
					_IsDescriptionChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Description 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsDescriptionChanged()
			{
				return _IsDescriptionChanged;
			}

		}


		/// <summary>
		/// 包含存储过程 usp_ServiceInstance_Insert_TCPIP 的所有参数的类声明
		/// </summary>
		public partial class usp_ServiceInstance_Insert_TCPIPParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


			protected bool _IsServiceIDChanged = false;
			protected int? _ServiceID;
			/// <summary>
			/// 
			/// </summary>
			public int? ServiceID
			{
				get
				{
					return _ServiceID;
				}
				set
				{
					_ServiceID = value;
					_IsServiceIDChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 ServiceID 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsServiceIDChanged()
			{
				return _IsServiceIDChanged;
			}

			protected bool _IsCreateTimeChanged = false;
			protected System.DateTime? _CreateTime;
			/// <summary>
			/// 
			/// </summary>
			public System.DateTime? CreateTime
			{
				get
				{
					return _CreateTime;
				}
				set
				{
					_CreateTime = value;
					_IsCreateTimeChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 CreateTime 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsCreateTimeChanged()
			{
				return _IsCreateTimeChanged;
			}

			protected bool _IsDescriptionChanged = false;
			protected string _Description;
			/// <summary>
			/// 
			/// </summary>
			public string Description
			{
				get
				{
					return _Description;
				}
				set
				{
					_Description = value;
					_IsDescriptionChanged = true;
				}
			}

			/// <summary>
			/// 返回一个 BOOL 值，用以标识参数 Description 的值是否被赋予或修改
			/// </summary>
			public bool CheckIsDescriptionChanged()
			{
				return _IsDescriptionChanged;
			}

		}


		/// <summary>
		/// 包含存储过程 usp_ServiceType_SelectAll 的所有参数的类声明
		/// </summary>
		public partial class usp_ServiceType_SelectAllParameters
		{
			protected int _returnValue;
			/// <summary>
			/// 获取存储过程中 RETURN 的整数值
			/// </summary>
			public int _ReturnValue
			{
				get
				{
					return _returnValue;
				}
			}

			/// <summary>
			/// 设置存储过程中 RETURN 的整数值
			/// </summary>
			public void SetReturnValue(int i)
			{
				_returnValue = i;
			}


		}


		#endregion
	}
}
