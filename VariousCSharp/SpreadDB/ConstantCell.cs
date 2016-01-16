using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	class ConstantCell : Cell
	{
		public override bool IsExpression
		{
			get { return false; }
		}

		public override double Value
		{
			get { return _value; }
			set
			{
				_value = value;
				SetDependenciesDirty();
			}
		}
	}
}
