using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	public class RpnExpression
	{
		public List<RpnNode> Nodes = new List<RpnNode>();

		public void Add(RpnNode n)
		{
			Nodes.Add(n);
		}
	}
}
