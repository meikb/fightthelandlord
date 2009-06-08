using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public static partial class DC
	{
		#region User Defined Functions

		private static SqlCommand _dbo_uf_Split_cmd = null;
		public static SqlCommand NewCmd_dbo_uf_Split()
		{
			if (_dbo_uf_Split_cmd != null) return _dbo_uf_Split_cmd.Clone();
			_dbo_uf_Split_cmd = new SqlCommand("SELECT * FROM [dbo].[uf_Split](@text, @separator)");
			_dbo_uf_Split_cmd.Parameters.Add(new SqlParameter("text", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "text", DataRowVersion.Current, null));
			_dbo_uf_Split_cmd.Parameters.Add(new SqlParameter("separator", System.Data.SqlDbType.NVarChar, -1, ParameterDirection.Input, false, 0, 0, "separator", DataRowVersion.Current, null));
			return _dbo_uf_Split_cmd.Clone();
		}
		#endregion

	}
}
