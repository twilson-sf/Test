using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	public class RpnNodeCellRef : RpnNode
	{
		public readonly int _row;
		public readonly bool _rowIsAbsolute;
		public readonly int _col;
		public readonly bool _colIsAbsolute;

		public RpnNodeCellRef(int row, bool rowIsAbsolute, int col, bool colIsAbsolute)
		{
			_row = row;
			_rowIsAbsolute = rowIsAbsolute;
			_col = col;
			_colIsAbsolute = colIsAbsolute;
		}

		public override bool IsValueType()
		{
			return false;
		}

		public override RpnNode Evaluate(RpnStack stack)
		{
			throw new NotImplementedException();
		}
	}
}
