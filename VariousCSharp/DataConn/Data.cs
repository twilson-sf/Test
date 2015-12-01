using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Advent.Data
{
	public class DataConn
	{
		string _databaseName = "";
		SqlConnection _dbConnection;
		SqlBulkCopy _bulk;
		string _password = "";
		int _queryTimeout = 1200;	// 20 minutes
		protected string _serverName = "";
		protected bool _useIntegratedSecurity = false;
		string _userName = "";

		public DataConn()
		{
			_dbConnection = new SqlConnection();
		}

		////////////////////////////////////////////////////////////////////////
		// Properties

		public SqlConnection SqlConnection
		{
			get { return _dbConnection; }
		}

		public string DatabaseName
		{
			get { return _databaseName; }
			set { _databaseName = value; }
		}

		////////////////////////////////////////////////////////////////////////
		//	Methods

		public DataTable GetTable(SqlCommand cmd)
		{
			DataTable table = new DataTable();
			cmd.CommandTimeout = _queryTimeout;
			try
			{
				SqlDataReader reader = cmd.ExecuteReader();
				table.Load(reader);
			}
			catch (SqlException e)
			{
				string msg = string.Format("Error Number={0}\r\nMessage={1}\r\nSQL:\r\n{2}",
									e.Number, e.Message, cmd.CommandText);
				throw new Exception(msg);
			}
			return table;
		}

		public DataTable GetTable(string sql)
		{
			SqlCommand cmd = new SqlCommand(sql, _dbConnection);
			return GetTable(cmd);
		}

		public Object GetScalar(string sql)
		{
			SqlCommand cmd = new SqlCommand(sql, _dbConnection);
			Object obj = cmd.ExecuteScalar();
			return obj;
		}

		public void ExecuteCmd(string sql)
		{
			SqlCommand cmd = new SqlCommand(sql, _dbConnection);
			cmd.CommandTimeout = _queryTimeout;
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				string msg = string.Format("Error Number={0}\r\nMessage={1}\r\nSQL:\r\n{2}",
					e.Number, e.Message, sql);
				throw new Exception(msg);
			}
		}

		public void Open()
		{
			// 			string connString = "Server=(localdb)\\v11.0;Integrated Security=true";


			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = _serverName;
			builder.InitialCatalog = _databaseName;
			builder.ApplicationName = System.AppDomain.CurrentDomain.FriendlyName;
			if (_useIntegratedSecurity)
				builder.IntegratedSecurity = true;
			else
			{
				builder.UserID = _userName;
				builder.Password = _password;
			}
			_dbConnection.ConnectionString = builder.ToString();
			_dbConnection.Open();

			_bulk = new SqlBulkCopy(_dbConnection);
		}

		public void PutBulk(string tableName, DataTable table)
		{
			Debug.Assert(table.Rows.Count > 0);
			System.Console.WriteLine("{0}: {1} rows", tableName, table.Rows.Count);
			_bulk.DestinationTableName = tableName;
			_bulk.WriteToServer(table);
		}
	}
}
