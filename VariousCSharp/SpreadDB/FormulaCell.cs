using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{
	public class FormulaCell : Cell
	{
		public RpnExpression Formula = null;
		bool _isDirty = true;

		public override bool IsExpression
		{
			get { return true; }
		}

		public bool IsDirty
		{
			get { return _isDirty;}
		}
	
		public override double Value
		{
			get
			{
				Debug.Assert(!_isDirty);
				return _value;
			}
			set
			{
				_value = value;
				_isDirty = false;
			}
		}
	}
}
