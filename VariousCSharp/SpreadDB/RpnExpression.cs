using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	class RpnExpression
	{
		List<RpnNode> _expression = new List<RpnNode>();

		public void Add(RpnNode n)
		{
			_expression.Add(n);
		}

		/// <summary>
		///	Evaluate the expression relative to cell(row, col)
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public double Evaluate(int row, int col)
		{
			List<RpnNode> stack = new List<RpnNode>();
			foreach (RpnNode n in _expression)
			{
				if (n.IsValueType())
					stack.Add(n);
				else
				{
					n.Evaluate(stack);
				}
			}
			Debug.Assert(stack.Count == 1);
			Debug.Assert(stack[0].IsValueType());
			return stack[0].Value();
		}
	}
}
