using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
	public class AddCommand : Command<double>
	{
		/*
		 Extends the Command abstract class, implementing the Execute method by invoking the corresponding operations on Receiver. 
		 It defines a link between the Receiver and the action.
		 A Command class holds some subset of the following: 
		 an object, a method to be applied to the object, and the arguments to be passed when the method is applied. 
		 The Command's "execute" method then causes the pieces to come together.
		 
		 */
		public AddCommand(List<double> args)
		{
			this.args = args;
		}

		public override double Execute()
		{
			return this.args.Aggregate((a, b) => a + b);
		}
	}
}
