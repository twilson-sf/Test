using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{
	struct CellStruct
	{
		double _value;
		bool _isValid;
	}

	class Cell
	{
		double _value;
		bool _isValid = false;

		public Cell()
		{
		}

		public double Val
		{
			get
			{
				return _value;
			}

			set {
				_value = value;
				_isValid = true;
			}
		}

		public bool IsValid
		{
			get { return _isValid; }
		}
	}

	class Sheet
	{
		Cell[,] _cells;
		int _numRows;
		int _numCols;

		public Sheet()
		{
			_numRows = 100;
			_numCols = 10;
			_cells = new Cell[_numRows, _numCols];
		}

		public void Load()
		{
			for (int row = 0; row < _numRows; row++)
			{
				_cells[row, 0] = new Cell();
				_cells[row, 0].Val = row + 2;
			}
		}

		public double Val(int row, int col)
		{
			Cell cell;
			if (_cells[row, col] == null)
				_cells[row, col] = new Cell();

			cell = _cells[row, col];
			if (!cell.IsValid)
			{
				switch (col)
				{
					case 1:
						cell.Val = Val(row, 0) * 2;
						break;

					case 2:
						cell.Val = Val(row, 0)*Val(row, 0) + Val(row, 1);
						break;

					default:
						Debug.Assert(false);
						break;
				}
			}
			return cell.Val;
		}

	}

	class SpreadDB
	{
		Sheet[] _sheets;

		public SpreadDB()
		{
			_sheets = new Sheet[20];
		}
	
		public Sheet Sheet(int i)
		{
			if (_sheets[i] == null)
				_sheets[i] = new Sheet();
			return _sheets[i];
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			SpreadDB db = new SpreadDB();
			Sheet sh = db.Sheet(0);
			sh.Load();

			for (int row = 0; row < 10; row++)
			{
				Console.WriteLine("row, col0, col2 {0} {1} {2}",
					row, sh.Val(row, 0), sh.Val(row, 2));
			}
		}
	}
}
