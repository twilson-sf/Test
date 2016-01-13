﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{
	public class Sheet
	{
		public Cell[,] Cells;
		int _numRows;
		int _numCols;
		List<RpnExpression> _expressions = new List<RpnExpression>();

		public Sheet()
		{
			_numRows = 20;
			_numCols = 5;
			Cells = new Cell[_numRows, _numCols];
		}

		public void Display()
		{
			Processor processor = new Processor(this);
			for (int row = 0; row < _numRows; row++)
			{
				for (int col = 0; col < _numCols; col++)
				{
					double x = processor.Value(row, col);
					Console.Write(x);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Currently a fake loader
		/// </summary>
		public void Load()
		{
			RpnExpression expr1 = new RpnExpression();
			expr1.Add(new RpnNodeConst(3.0));
			expr1.Add(new RpnNodeConst(4.0));
			expr1.Add(new RpnNodeAdd());
			_expressions.Add(expr1);

			RpnExpression expr2 = new RpnExpression();
			expr2.Add(new RpnNodeCellRef(0, false, -2, false));
			expr2.Add(new RpnNodeCellRef(0, false, -1, false));
			expr2.Add(new RpnNodeAdd());
			_expressions.Add(expr2);


			for (int row = 0; row < _numRows; row++)
			{
				for (int col = 0; col < _numCols; col++)
				{
					// current sheet is 5 columns, 0 to 4.
					switch (col)
					{
						case 3:
						{
							FormulaCell cell = new FormulaCell();
							cell.Formula = expr1;
							Cells[row, col] = cell;
							break;
						}

						case 4:
						{
							FormulaCell cell = new FormulaCell();
							cell.Formula = expr2;
							Cells[row, col] = cell;
							break;
						}

						default:
							Cells[row, col] = new ConstantCell();
							Cells[row, col].Value = row + col;
							break;
					}
				}
			}
		}

		public double Value(int row, int col)
		{
			Debug.Assert(false);	// I think this is obsolete
			double ret;
			Cell cell = Cells[row, col];
			if (cell.GetType() == typeof(ConstantCell))
				ret = cell.Value;
			else
				ret = ((FormulaCell)cell).Evaluate(this, row, col);
			return ret;
		}

	}
}
