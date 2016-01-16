using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{

	public abstract class Cell
	{
		protected double _value;
		List<FormulaCell> _dependencies;

		public abstract double Value
		{
			get;
			set;
		}

		public abstract bool IsExpression { get; }

		public void AddDependency(FormulaCell cell)
		{
			if (_dependencies == null)
				_dependencies = new List<FormulaCell>();
			if (!_dependencies.Contains(cell))
				_dependencies.Add(cell);
		}

		public void SetDependenciesDirty()
		{
			if (_dependencies == null)
				return;
			foreach (FormulaCell cell in _dependencies)
				cell.SetDirty();
		}

	}

}
