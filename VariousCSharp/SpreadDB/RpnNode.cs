using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	public abstract class RpnNode
	{
		public abstract bool IsValueType();

		public virtual RpnNode Evaluate(RpnStack stack)
		{
			throw new NotImplementedException();
		}

		public virtual double Value()
		{
			throw new NotImplementedException();
		}

	}
}
