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

		public override RpnNode Evaluate(List<RpnNode> stack)
		{
			double x = stack[stack.Count - 1].Value() + stack[stack.Count - 2].Value();
			stack.RemoveRange(stack.Count - 2, 2);
			return new RpnNodeConst(x);
		}

		public override double Value()
		{
			throw new NotImplementedException();
		}
	}
}
