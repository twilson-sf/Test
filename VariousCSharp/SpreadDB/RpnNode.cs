using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	public abstract class RpnNode
	{
		public abstract bool IsValueType();
		public abstract double Value();
		public abstract RpnNode Evaluate(List<RpnNode> stack);
	}
}
