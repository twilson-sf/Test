using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advent.Data;

namespace TableValuedParameter
{
	class Program
	{
		static void Main(string[] args)
		{
			DataConn conn = new DataConn();
			conn.DatabaseName = "twilson1\\inst3";
//			conn.Open();

			// create a datatable that has default values on columns
			DataTable dt = new DataTable();

			DataColumn col1 = new DataColumn("col1", typeof(Int32));
			col1.DefaultValue = -1;

			DataColumn col2 = new DataColumn("col2", typeof(string));
			col2.DefaultValue = "~^~";

			dt.Columns.Add(col1);
			dt.Columns.Add(col2);

			DataRow row = dt.NewRow();
			dt.Rows.Add(row);
		}
	}
}
