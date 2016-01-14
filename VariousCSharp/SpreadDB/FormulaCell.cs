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
				Debug.Assert(_isValid);
				return _value;
			}
			set
			{
				_value = value;
				_isValid = true;
			}
		}
	}
}
