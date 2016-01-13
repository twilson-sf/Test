using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{

	public abstract class Cell
	{
		protected double _value;
		protected bool _isValid = false;
		public abstract double Value
		{
			get;
			set;
		}

		public bool IsValid
		{
			get { return _isValid; }
		}

		public abstract bool IsExpression { get; }
	}

}
