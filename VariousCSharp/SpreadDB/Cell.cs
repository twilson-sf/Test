using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpreadDB
{

	public abstract class Cell
	{
		protected double _value;

		public abstract double Value
		{
			get;
			set;
		}

		public abstract bool IsExpression { get; }
	}

}
