/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-8-25
 * Time: 20:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace domain
{
	/// <summary>
	/// Description of SqlTool.
	/// </summary>
	public class SqlTool
	{
		private static SqlTool instance ;
		private static OleDbConnection connection ;
		private const string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./db.mdb";
		private SqlTool(){}
		public static  SqlTool getInstance(string connStr)
		{
			if(null == instance)
			{
				connection = new OleDbConnection("".Equals(connStr) ? connectionString : connStr);
				instance = new SqlTool();
			}
			return instance;
		}
		public static SqlTool getInstance()
		{
			if(null == instance)
			{
				instance = new SqlTool();
			}
			return instance;
		}
		
		public DataTable query(string sql)
		{
			connection = new OleDbConnection(connectionString);
			connection.Open();
			OleDbCommand cmd = new OleDbCommand(sql, connection);
			OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
			cmd.CommandType = CommandType.Text;
			adapter.SelectCommand = cmd;
			DataSet dataSet = new DataSet();
			adapter.Fill(dataSet);
			connection.Close();
			return (dataSet==null || dataSet.Tables.Count==0) ? null : dataSet.Tables[0];
		}
		public int update(string sql)
		{
			connection = new OleDbConnection(connectionString);
			connection.Open();
			OleDbCommand cmd = new OleDbCommand(sql, connection);
			int count = cmd.ExecuteNonQuery();
			connection.Close();
			return count;
		}
	}
}
