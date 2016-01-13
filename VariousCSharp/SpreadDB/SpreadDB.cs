using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpreadDB
{
	class SpreadDB
	{
		List<Sheet> _sheets = new List<Sheet>();

		public SpreadDB()
		{
		}

		public Sheet Sheet(int i)
		{
			while (_sheets.Count <= i)
				_sheets.Add(new Sheet());
			return _sheets[i];
		}
	}
}
