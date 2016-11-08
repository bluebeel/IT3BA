using System;
using System.Collections.Generic;
using System.Linq;
      
namespace Calculator
{
	public class Calculator : IReciever<double>
	{
		/* The receiver implementation. 
		The receiver object owns the method that is called by the command's execute method. 
		The receiver is typically also the target object.
		*/
		ACTION currentAction;
		List<double> arguments;
		double result = double.NaN;

		public Calculator(List<double> args)
		{
			arguments = args;
		}

		public void SetAction(ACTION action)
		{
			currentAction = action;
		}

		public double GetResult()
		{
			
			if (currentAction == ACTION.Add)
			{
				result = arguments.Aggregate((a, b) => a + b);
			}
			else if (currentAction == ACTION.Mult)
			{
				result = arguments.Aggregate((a, b) => a * b);
			}
			else if (currentAction == ACTION.Div)
			{
				result = arguments.Aggregate((a, b) => a / b);
			}
			else if (currentAction == ACTION.Sub)
			{
				result = arguments.Aggregate((a, b) => a - b);
			}
			else
			{
				Console.WriteLine("Command not found");
			}
			return result;
		}

	}
}
