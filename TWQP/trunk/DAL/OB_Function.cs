using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public static partial class OB
	{
		#region User Defined Functions

		/// <summary>
		/// 
		/// </summary>
		[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)]
		public static OO.dbo_uf_SplitCollection dbo_uf_Split(string text, string separator)
		{
			SqlCommand cmd = DC.NewCmd_dbo_uf_Split();
			if (text == null) cmd.Parameters["text"].Value = DBNull.Value;
			else cmd.Parameters["text"].Value = text;
			if (separator == null) cmd.Parameters["separator"].Value = DBNull.Value;
			else cmd.Parameters["separator"].Value = separator;
			OO.dbo_uf_SplitCollection os = new OO.dbo_uf_SplitCollection();
			using(SqlDataReader sdr = SQLHelper.ExecuteDataReader(cmd))
			{
				while(sdr.Read())
				{
					os.Add(new OO.dbo_uf_Split(sdr.GetInt32(0), sdr.IsDBNull(1) ? null : sdr.GetString(1)));
				}
			}
			return os;
		}
		#endregion

	}
}
