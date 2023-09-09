using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.DA
{
	public  class HardPasswordSetupDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		public HardPasswordSetupDA() { }
		#endregion

		#region  GET PolicyNo
		public int GetPolicyID()
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			int policyID = 0;
			try
			{
				conn.Open();
				using ( SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand getCommand = new SqlCommand("select top 1 PolicyID from HardPasswordSetup order by PolicyID desc", conn, tc);
					SqlDataReader dr = getCommand.ExecuteReader();
					if (dr.Read())
					{
						policyID = dr.GetInt32(0);
					}
					dr.Close();
					tc.Commit();
					conn.Close();
				}
			}
			catch (Exception ex)
			{

			}
			finally
			{ 
				conn.Close(); 
			}

			return policyID;
		}
		#endregion
	}
}
