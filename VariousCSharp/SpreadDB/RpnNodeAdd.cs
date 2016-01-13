using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	class RpnNodeAdd : RpnNode
	{
		public override bool IsValueType()
		{
			return false;
		}

		public override RpnNode Evaluate(RpnStack stack)
		{
			int stackCount = stack.Count;
			double x = stack[stackCount - 1].Value() + stack[stackCount - 2].Value();
			stack.RemoveRange(stackCount - 2, 2);
			return new RpnNodeConst(x);
		}
	}
}
