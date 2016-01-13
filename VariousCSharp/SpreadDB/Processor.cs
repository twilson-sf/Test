using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{
	public class RpnStack: List<RpnNode>
	{
	}

	public class Processor
	{
		readonly Sheet _sheet;

		public Processor(Sheet sheet)
		{
			_sheet = sheet;
		}

		/// <summary>
		///	Evaluate the expression relative to cell(row, col)
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public double Evaluate(RpnExpression expr, int row, int col)
		{
			RpnStack stack = new RpnStack();
			foreach (RpnNode n in expr.Nodes)
			{
				if (n.IsValueType())
					stack.Add(n);
				else if (n.GetType() == typeof(RpnNodeCellRef))
				{
					RpnNodeCellRef n1 = (RpnNodeCellRef)n;
					int row1 = row + n1._row;
					int col1 = col + n1._col;
					double x = this.Value(row1, col1);
					stack.Add(new RpnNodeConst(x));
				}
				else
				{
					stack.Add(n.Evaluate(stack));
				}
			}
			Debug.Assert(stack.Count == 1);
			Debug.Assert(stack[0].IsValueType());
			return stack[0].Value();
		}

		public double Value(int row, int col)
		{
			Cell cell = _sheet.Cells[row, col];
			if (!cell.IsExpression)
				return cell.Value;
			double ret = Evaluate(((FormulaCell)cell).Formula, row, col);
			return ret;
		}

	}
}
