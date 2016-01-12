using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	abstract class RpnNode
	{
		public abstract bool IsValueType();
		public abstract double Value();
		public abstract double Evaluate(List<RpnNode> stack);
	}

	class RpnNodeConst: RpnNode
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

		public override double Evaluate(List<RpnNode> stack)
		{
			throw new NotImplementedException();
		}

		public override double Value()
		{
			return _value;
		}
	}

	class RpnNodeAdd: RpnNode
	{
		public override bool IsValueType()
		{
			return false;
		}

		public override double Evaluate(List<RpnNode> stack)
		{
			double x = stack[stack.Count-1].Value() + stack[stack.Count-2].Value();
			stack.RemoveRange(stack.Count-2, 2);
			stack.Add(new RpnNodeConst(x));
			return x;
		}

		public override double Value()
		{
			throw new NotImplementedException();
		}
	}
}
