using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadDB
{

	class RpnNodeConst : RpnNode
	{
		readonly double _value;
		public override bool IsValueType()
		{
			return true;
		}

		public RpnNodeConst(double val)
		{
			_value = val;
		}

		public override RpnNode Evaluate(List<RpnNode> stack)
		{
			throw new NotImplementedException();
		}

		public override double Value()
		{
			return _value;
		}
	}
}
