using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
	public class MultCommand : Command<double>
	{
		public MultCommand(List<double> args)
		{
			this.args = args;
		}

		public override double Execute()
		{
			return this.args.Aggregate((a, b) => a * b);
		}
	}
}
