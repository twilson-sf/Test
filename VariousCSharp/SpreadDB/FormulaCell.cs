using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{
	public class FormulaCell : Cell
	{
		public RpnExpression Formula = null;

		public override bool IsExpression
		{
			get { return true; }
		}

		public override double Value
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				_value = value;
				_isValid = true;
			}
		}

		public double Evaluate(Sheet sheet, int row, int col)
		{
			Debug.Assert(false);
//			if (!_isValid)
//				this.Value = this.Formula.Evaluate(sheet, row, col);
			return _value;
		}
	}
}
