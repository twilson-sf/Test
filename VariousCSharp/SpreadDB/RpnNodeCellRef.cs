using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	class RpnNodeCellRef : RpnNode
	{
		readonly int _row;
		readonly bool _rowIsAbsolute;
		readonly int _col;
		readonly bool _colIsAbsolute;

		public RpnNodeCellRef(int row, bool rowIsAbsolute, int col, bool colIsAbsolute)
		{
			_row = row;
			_rowIsAbsolute = rowIsAbsolute;
			_col = col;
			_colIsAbsolute = colIsAbsolute;
		}

		public override bool IsValueType()
		{
			return true;
		}

		public override RpnNode Evaluate(List<RpnNode> stack)
		{
			throw new NotImplementedException();
		}

		public override double Value()
		{
			throw new NotImplementedException("RpnNodeCellRef.Value");
		}
	}
}
