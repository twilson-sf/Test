using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{

	public abstract class Cell
	{
		protected double _value;
		protected bool _isValid = false;
		public abstract double Value
		{
			get;
			set;
		}

		public bool IsValid
		{
			get { return _isValid; }
		}
	}

	class ConstantCell : Cell
	{
		public override double Value
		{
			get
			{
				return _value;
			}

			set
			{
				_value = value;
				_isValid = true;
			}
		}
	}

	public class FormulaCell: Cell
	{
		public RpnExpression Formula = null;

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
			if (!_isValid)
				this.Value = this.Formula.Evaluate(sheet, row, col);
			return _value;
		}
	}
}
