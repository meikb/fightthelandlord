using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public static partial class DC
	{
		#region Stored Procedures

		private static SqlCommand _usp_Init = null;
		public static SqlCommand NewCmd_usp_Init()
		{
			if (_usp_Init != null) return _usp_Init.Clone();

			_usp_Init = new SqlCommand("[usp].[Init]");
			_usp_Init.CommandType = CommandType.StoredProcedure;
			_usp_Init.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			return _usp_Init.Clone();
		}
		public static SqlCommand NewCmd_usp_Init(DI.usp_InitParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[Init]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			return cmd;
		}

		private static SqlCommand _usp_Service_Init = null;
		public static SqlCommand NewCmd_usp_Service_Init()
		{
			if (_usp_Service_Init != null) return _usp_Service_Init.Clone();

			_usp_Service_Init = new SqlCommand("[usp].[Service_Init]");
			_usp_Service_Init.CommandType = CommandType.StoredProcedure;
			_usp_Service_Init.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			return _usp_Service_Init.Clone();
		}
		public static SqlCommand NewCmd_usp_Service_Init(DI.usp_Service_InitParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[Service_Init]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			return cmd;
		}

		private static SqlCommand _usp_Service_Insert = null;
		public static SqlCommand NewCmd_usp_Service_Insert()
		{
			if (_usp_Service_Insert != null) return _usp_Service_Insert.Clone();

			_usp_Service_Insert = new SqlCommand("[usp].[Service_Insert]");
			_usp_Service_Insert.CommandType = CommandType.StoredProcedure;
			_usp_Service_Insert.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			_usp_Service_Insert.Parameters.Add(new SqlParameter("ServiceTypeID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceTypeID", DataRowVersion.Current, null));
			_usp_Service_Insert.Parameters.Add(new SqlParameter("CreateTime", System.Data.SqlDbType.DateTime2, 8, ParameterDirection.Input, false, 27, 7, "CreateTime", DataRowVersion.Current, null));
			_usp_Service_Insert.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, null));
			_usp_Service_Insert.Parameters.Add(new SqlParameter("Version", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Version", DataRowVersion.Current, null));
			_usp_Service_Insert.Parameters.Add(new SqlParameter("FilePath", System.Data.SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "FilePath", DataRowVersion.Current, null));
			_usp_Service_Insert.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			return _usp_Service_Insert.Clone();
		}
		public static SqlCommand NewCmd_usp_Service_Insert(DI.usp_Service_InsertParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[Service_Insert]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			if (p.CheckIsServiceTypeIDChanged())
			{
				cmd.Parameters.Add(new SqlParameter("ServiceTypeID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceTypeID", DataRowVersion.Current, null));
			}
			if (p.CheckIsCreateTimeChanged())
			{
				cmd.Parameters.Add(new SqlParameter("CreateTime", System.Data.SqlDbType.DateTime2, 8, ParameterDirection.Input, false, 27, 7, "CreateTime", DataRowVersion.Current, null));
			}
			if (p.CheckIsNameChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, null));
			}
			if (p.CheckIsVersionChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Version", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Version", DataRowVersion.Current, null));
			}
			if (p.CheckIsFilePathChanged())
			{
				cmd.Parameters.Add(new SqlParameter("FilePath", System.Data.SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "FilePath", DataRowVersion.Current, null));
			}
			if (p.CheckIsDescriptionChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			}
			return cmd;
		}

		private static SqlCommand _usp_Service_Update = null;
		public static SqlCommand NewCmd_usp_Service_Update()
		{
			if (_usp_Service_Update != null) return _usp_Service_Update.Clone();

			_usp_Service_Update = new SqlCommand("[usp].[Service_Update]");
			_usp_Service_Update.CommandType = CommandType.StoredProcedure;
			_usp_Service_Update.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			_usp_Service_Update.Parameters.Add(new SqlParameter("Original_ServiceID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Original_ServiceID", DataRowVersion.Original, null));
			_usp_Service_Update.Parameters.Add(new SqlParameter("ServiceTypeID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceTypeID", DataRowVersion.Current, null));
			_usp_Service_Update.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, null));
			_usp_Service_Update.Parameters.Add(new SqlParameter("Version", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Version", DataRowVersion.Current, null));
			_usp_Service_Update.Parameters.Add(new SqlParameter("FilePath", System.Data.SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "FilePath", DataRowVersion.Current, null));
			_usp_Service_Update.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			return _usp_Service_Update.Clone();
		}
		public static SqlCommand NewCmd_usp_Service_Update(DI.usp_Service_UpdateParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[Service_Update]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			if (p.CheckIsOriginal_ServiceIDChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Original_ServiceID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Original_ServiceID", DataRowVersion.Original, null));
			}
			if (p.CheckIsServiceTypeIDChanged())
			{
				cmd.Parameters.Add(new SqlParameter("ServiceTypeID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceTypeID", DataRowVersion.Current, null));
			}
			if (p.CheckIsNameChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Name", System.Data.SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "Name", DataRowVersion.Current, null));
			}
			if (p.CheckIsVersionChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Version", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "Version", DataRowVersion.Current, null));
			}
			if (p.CheckIsFilePathChanged())
			{
				cmd.Parameters.Add(new SqlParameter("FilePath", System.Data.SqlDbType.NVarChar, 250, ParameterDirection.Input, false, 0, 0, "FilePath", DataRowVersion.Current, null));
			}
			if (p.CheckIsDescriptionChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			}
			return cmd;
		}

		private static SqlCommand _usp_ServiceInstance_Insert_NamedPipe = null;
		public static SqlCommand NewCmd_usp_ServiceInstance_Insert_NamedPipe()
		{
			if (_usp_ServiceInstance_Insert_NamedPipe != null) return _usp_ServiceInstance_Insert_NamedPipe.Clone();

			_usp_ServiceInstance_Insert_NamedPipe = new SqlCommand("[usp].[ServiceInstance_Insert_NamedPipe]");
			_usp_ServiceInstance_Insert_NamedPipe.CommandType = CommandType.StoredProcedure;
			_usp_ServiceInstance_Insert_NamedPipe.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			_usp_ServiceInstance_Insert_NamedPipe.Parameters.Add(new SqlParameter("ServiceID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceID", DataRowVersion.Current, null));
			_usp_ServiceInstance_Insert_NamedPipe.Parameters.Add(new SqlParameter("CreateTime", System.Data.SqlDbType.DateTime2, 8, ParameterDirection.Input, false, 27, 7, "CreateTime", DataRowVersion.Current, null));
			_usp_ServiceInstance_Insert_NamedPipe.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			return _usp_ServiceInstance_Insert_NamedPipe.Clone();
		}
		public static SqlCommand NewCmd_usp_ServiceInstance_Insert_NamedPipe(DI.usp_ServiceInstance_Insert_NamedPipeParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[ServiceInstance_Insert_NamedPipe]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			if (p.CheckIsServiceIDChanged())
			{
				cmd.Parameters.Add(new SqlParameter("ServiceID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceID", DataRowVersion.Current, null));
			}
			if (p.CheckIsCreateTimeChanged())
			{
				cmd.Parameters.Add(new SqlParameter("CreateTime", System.Data.SqlDbType.DateTime2, 8, ParameterDirection.Input, false, 27, 7, "CreateTime", DataRowVersion.Current, null));
			}
			if (p.CheckIsDescriptionChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			}
			return cmd;
		}

		private static SqlCommand _usp_ServiceInstance_Insert_TCPIP = null;
		public static SqlCommand NewCmd_usp_ServiceInstance_Insert_TCPIP()
		{
			if (_usp_ServiceInstance_Insert_TCPIP != null) return _usp_ServiceInstance_Insert_TCPIP.Clone();

			_usp_ServiceInstance_Insert_TCPIP = new SqlCommand("[usp].[ServiceInstance_Insert_TCPIP]");
			_usp_ServiceInstance_Insert_TCPIP.CommandType = CommandType.StoredProcedure;
			_usp_ServiceInstance_Insert_TCPIP.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			_usp_ServiceInstance_Insert_TCPIP.Parameters.Add(new SqlParameter("ServiceID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceID", DataRowVersion.Current, null));
			_usp_ServiceInstance_Insert_TCPIP.Parameters.Add(new SqlParameter("CreateTime", System.Data.SqlDbType.DateTime2, 8, ParameterDirection.Input, false, 27, 7, "CreateTime", DataRowVersion.Current, null));
			_usp_ServiceInstance_Insert_TCPIP.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			return _usp_ServiceInstance_Insert_TCPIP.Clone();
		}
		public static SqlCommand NewCmd_usp_ServiceInstance_Insert_TCPIP(DI.usp_ServiceInstance_Insert_TCPIPParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[ServiceInstance_Insert_TCPIP]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			if (p.CheckIsServiceIDChanged())
			{
				cmd.Parameters.Add(new SqlParameter("ServiceID", System.Data.SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "ServiceID", DataRowVersion.Current, null));
			}
			if (p.CheckIsCreateTimeChanged())
			{
				cmd.Parameters.Add(new SqlParameter("CreateTime", System.Data.SqlDbType.DateTime2, 8, ParameterDirection.Input, false, 27, 7, "CreateTime", DataRowVersion.Current, null));
			}
			if (p.CheckIsDescriptionChanged())
			{
				cmd.Parameters.Add(new SqlParameter("Description", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "Description", DataRowVersion.Current, null));
			}
			return cmd;
		}

		private static SqlCommand _usp_ServiceType_SelectAll = null;
		public static SqlCommand NewCmd_usp_ServiceType_SelectAll()
		{
			if (_usp_ServiceType_SelectAll != null) return _usp_ServiceType_SelectAll.Clone();

			_usp_ServiceType_SelectAll = new SqlCommand("[usp].[ServiceType_SelectAll]");
			_usp_ServiceType_SelectAll.CommandType = CommandType.StoredProcedure;
			_usp_ServiceType_SelectAll.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			return _usp_ServiceType_SelectAll.Clone();
		}
		public static SqlCommand NewCmd_usp_ServiceType_SelectAll(DI.usp_ServiceType_SelectAllParameters p)
		{
			SqlCommand cmd = new SqlCommand("[usp].[ServiceType_SelectAll]");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add(new SqlParameter("RETURN_VALUE", System.Data.SqlDbType.Int, 0, ParameterDirection.ReturnValue, false, 0, 0, null, DataRowVersion.Current, null));
			return cmd;
		}

		#endregion

	}
}
