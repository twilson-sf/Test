using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{

	class Program
	{
		static void Test()
		{
			RpnExpression e = new RpnExpression();
			e.Add(new RpnNodeConst(3.0));
			e.Add(new RpnNodeConst(4.0));
			e.Add(new RpnNodeAdd());

//			double x = e.Evaluate(null, 0, 0);
		}

		static void Main(string[] args)
		{
			Test();

			SpreadDB db = new SpreadDB();

			Sheet sh = db.Sheet(0);
			sh.Load();
			sh.Display();

			Sheet sh1 = db.Sheet(1);
			sh1.Load();
			sh1.Display();

			sh1.Cells[1, 1].Value = 13.0;
			sh1.Display();

		}
	}
}
