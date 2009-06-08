using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public static partial class OB
	{
		#region Stored Procedures

		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Init()
		{
			SqlCommand cmd = DC.NewCmd_usp_Init();
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Init(DI.usp_InitParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_Init(p);
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Service_Init()
		{
			SqlCommand cmd = DC.NewCmd_usp_Service_Init();
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Service_Init(DI.usp_Service_InitParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_Service_Init(p);
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Service_Insert(  int? ServiceTypeID,   System.DateTime? CreateTime,   string Name,   int? Version,   string FilePath,   string Description)
		{
			SqlCommand cmd = DC.NewCmd_usp_Service_Insert();
			if (ServiceTypeID == null) cmd.Parameters["ServiceTypeID"].Value = DBNull.Value;
			else cmd.Parameters["ServiceTypeID"].Value = ServiceTypeID;
			if (CreateTime == null) cmd.Parameters["CreateTime"].Value = DBNull.Value;
			else cmd.Parameters["CreateTime"].Value = CreateTime;
			if (Name == null) cmd.Parameters["Name"].Value = DBNull.Value;
			else cmd.Parameters["Name"].Value = Name;
			if (Version == null) cmd.Parameters["Version"].Value = DBNull.Value;
			else cmd.Parameters["Version"].Value = Version;
			if (FilePath == null) cmd.Parameters["FilePath"].Value = DBNull.Value;
			else cmd.Parameters["FilePath"].Value = FilePath;
			if (Description == null) cmd.Parameters["Description"].Value = DBNull.Value;
			else cmd.Parameters["Description"].Value = Description;
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Service_Insert(DI.usp_Service_InsertParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_Service_Insert(p);
			if (p.CheckIsServiceTypeIDChanged())
			{
				object o = p.ServiceTypeID;
				if (o == null) cmd.Parameters["ServiceTypeID"].Value = DBNull.Value;
				else cmd.Parameters["ServiceTypeID"].Value = o;
			}
			if (p.CheckIsCreateTimeChanged())
			{
				object o = p.CreateTime;
				if (o == null) cmd.Parameters["CreateTime"].Value = DBNull.Value;
				else cmd.Parameters["CreateTime"].Value = o;
			}
			if (p.CheckIsNameChanged())
			{
				object o = p.Name;
				if (o == null) cmd.Parameters["Name"].Value = DBNull.Value;
				else cmd.Parameters["Name"].Value = o;
			}
			if (p.CheckIsVersionChanged())
			{
				object o = p.Version;
				if (o == null) cmd.Parameters["Version"].Value = DBNull.Value;
				else cmd.Parameters["Version"].Value = o;
			}
			if (p.CheckIsFilePathChanged())
			{
				object o = p.FilePath;
				if (o == null) cmd.Parameters["FilePath"].Value = DBNull.Value;
				else cmd.Parameters["FilePath"].Value = o;
			}
			if (p.CheckIsDescriptionChanged())
			{
				object o = p.Description;
				if (o == null) cmd.Parameters["Description"].Value = DBNull.Value;
				else cmd.Parameters["Description"].Value = o;
			}
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Service_Update(  int? Original_ServiceID,   int? ServiceTypeID,   string Name,   int? Version,   string FilePath,   string Description)
		{
			SqlCommand cmd = DC.NewCmd_usp_Service_Update();
			if (Original_ServiceID == null) cmd.Parameters["Original_ServiceID"].Value = DBNull.Value;
			else cmd.Parameters["Original_ServiceID"].Value = Original_ServiceID;
			if (ServiceTypeID == null) cmd.Parameters["ServiceTypeID"].Value = DBNull.Value;
			else cmd.Parameters["ServiceTypeID"].Value = ServiceTypeID;
			if (Name == null) cmd.Parameters["Name"].Value = DBNull.Value;
			else cmd.Parameters["Name"].Value = Name;
			if (Version == null) cmd.Parameters["Version"].Value = DBNull.Value;
			else cmd.Parameters["Version"].Value = Version;
			if (FilePath == null) cmd.Parameters["FilePath"].Value = DBNull.Value;
			else cmd.Parameters["FilePath"].Value = FilePath;
			if (Description == null) cmd.Parameters["Description"].Value = DBNull.Value;
			else cmd.Parameters["Description"].Value = Description;
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_Service_Update(DI.usp_Service_UpdateParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_Service_Update(p);
			if (p.CheckIsOriginal_ServiceIDChanged())
			{
				object o = p.Original_ServiceID;
				if (o == null) cmd.Parameters["Original_ServiceID"].Value = DBNull.Value;
				else cmd.Parameters["Original_ServiceID"].Value = o;
			}
			if (p.CheckIsServiceTypeIDChanged())
			{
				object o = p.ServiceTypeID;
				if (o == null) cmd.Parameters["ServiceTypeID"].Value = DBNull.Value;
				else cmd.Parameters["ServiceTypeID"].Value = o;
			}
			if (p.CheckIsNameChanged())
			{
				object o = p.Name;
				if (o == null) cmd.Parameters["Name"].Value = DBNull.Value;
				else cmd.Parameters["Name"].Value = o;
			}
			if (p.CheckIsVersionChanged())
			{
				object o = p.Version;
				if (o == null) cmd.Parameters["Version"].Value = DBNull.Value;
				else cmd.Parameters["Version"].Value = o;
			}
			if (p.CheckIsFilePathChanged())
			{
				object o = p.FilePath;
				if (o == null) cmd.Parameters["FilePath"].Value = DBNull.Value;
				else cmd.Parameters["FilePath"].Value = o;
			}
			if (p.CheckIsDescriptionChanged())
			{
				object o = p.Description;
				if (o == null) cmd.Parameters["Description"].Value = DBNull.Value;
				else cmd.Parameters["Description"].Value = o;
			}
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_ServiceInstance_Insert_NamedPipe(  int? ServiceID,   System.DateTime? CreateTime,   string Description)
		{
			SqlCommand cmd = DC.NewCmd_usp_ServiceInstance_Insert_NamedPipe();
			if (ServiceID == null) cmd.Parameters["ServiceID"].Value = DBNull.Value;
			else cmd.Parameters["ServiceID"].Value = ServiceID;
			if (CreateTime == null) cmd.Parameters["CreateTime"].Value = DBNull.Value;
			else cmd.Parameters["CreateTime"].Value = CreateTime;
			if (Description == null) cmd.Parameters["Description"].Value = DBNull.Value;
			else cmd.Parameters["Description"].Value = Description;
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_ServiceInstance_Insert_NamedPipe(DI.usp_ServiceInstance_Insert_NamedPipeParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_ServiceInstance_Insert_NamedPipe(p);
			if (p.CheckIsServiceIDChanged())
			{
				object o = p.ServiceID;
				if (o == null) cmd.Parameters["ServiceID"].Value = DBNull.Value;
				else cmd.Parameters["ServiceID"].Value = o;
			}
			if (p.CheckIsCreateTimeChanged())
			{
				object o = p.CreateTime;
				if (o == null) cmd.Parameters["CreateTime"].Value = DBNull.Value;
				else cmd.Parameters["CreateTime"].Value = o;
			}
			if (p.CheckIsDescriptionChanged())
			{
				object o = p.Description;
				if (o == null) cmd.Parameters["Description"].Value = DBNull.Value;
				else cmd.Parameters["Description"].Value = o;
			}
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_ServiceInstance_Insert_TCPIP(  int? ServiceID,   System.DateTime? CreateTime,   string Description)
		{
			SqlCommand cmd = DC.NewCmd_usp_ServiceInstance_Insert_TCPIP();
			if (ServiceID == null) cmd.Parameters["ServiceID"].Value = DBNull.Value;
			else cmd.Parameters["ServiceID"].Value = ServiceID;
			if (CreateTime == null) cmd.Parameters["CreateTime"].Value = DBNull.Value;
			else cmd.Parameters["CreateTime"].Value = CreateTime;
			if (Description == null) cmd.Parameters["Description"].Value = DBNull.Value;
			else cmd.Parameters["Description"].Value = Description;
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_ServiceInstance_Insert_TCPIP(DI.usp_ServiceInstance_Insert_TCPIPParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_ServiceInstance_Insert_TCPIP(p);
			if (p.CheckIsServiceIDChanged())
			{
				object o = p.ServiceID;
				if (o == null) cmd.Parameters["ServiceID"].Value = DBNull.Value;
				else cmd.Parameters["ServiceID"].Value = o;
			}
			if (p.CheckIsCreateTimeChanged())
			{
				object o = p.CreateTime;
				if (o == null) cmd.Parameters["CreateTime"].Value = DBNull.Value;
				else cmd.Parameters["CreateTime"].Value = o;
			}
			if (p.CheckIsDescriptionChanged())
			{
				object o = p.Description;
				if (o == null) cmd.Parameters["Description"].Value = DBNull.Value;
				else cmd.Parameters["Description"].Value = o;
			}
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_ServiceType_SelectAll()
		{
			SqlCommand cmd = DC.NewCmd_usp_ServiceType_SelectAll();
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			return int.Parse(s);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>int</returns>
		public static int usp_ServiceType_SelectAll(DI.usp_ServiceType_SelectAllParameters p)
		{
			SqlCommand cmd = DC.NewCmd_usp_ServiceType_SelectAll(p);
			SQLHelper.ExecuteNonQuery(cmd);
			string s = cmd.Parameters["RETURN_VALUE"].Value.ToString();
			if (string.IsNullOrEmpty(s))
			{
				p.SetReturnValue(0);
				return 0;
			}
			else
			{
				p.SetReturnValue(int.Parse(s));
				return p._ReturnValue;
			}
		}
		#endregion

	}
}
