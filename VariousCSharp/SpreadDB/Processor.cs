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
			FormulaCell thisCell = (FormulaCell)_sheet.Cells[row, col];
			if (!thisCell.IsDirty)
				return thisCell.Value;

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
					_sheet.Cells[row1, col1].AddDependency(thisCell);		// TODO - only needs to be done on first evaluate
					double x = this.Value(row1, col1);	// here's the magic recursive call to evaluate upstream
					stack.Add(new RpnNodeConst(x));
				}
				else
				{
					stack.Add(n.Evaluate(stack));
				}
			}
			Debug.Assert(stack.Count == 1);
			Debug.Assert(stack[0].IsValueType());
			double ret = stack[0].Value();
			thisCell.Value = ret;
			return ret;
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
