using System;
using System.Collections.Generic;
      
namespace Calculator
{
	public class Calculator : IReciever<double>
	{
		/* The receiver implementation. 
		The receiver object owns the method that is called by the command's execute method. 
		The receiver is typically also the target object.
		*/
		ACTION currentAction;
		string[] arguments;
		double result;

		public Calculator(string[] args)
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
				if (arguments.Length == 1 || arguments.Length == 2)
				{
					Console.WriteLine("Please enter a minimun of 2 number");
				}
				else 
				{
					result = 0;
					for (int i = 1; i < arguments.Length; i++) // Loop through array
					{
						result += Convert.ToDouble(arguments[i]);
					}
				}

			}
			else if (currentAction == ACTION.Mult)
			{
				if (arguments.Length == 1 || arguments.Length == 2)
				{
					Console.WriteLine("Please enter a minimun of 2 number");
				}
				else
				{
					result = 1;
					for (int i = 1; i < arguments.Length; i++) // Loop through array
					{
						result *= Convert.ToDouble(arguments[i]);
					}
					return result;
				}
			}
			else
			{
				Console.WriteLine("Command not found");
			}
			return result;
		}

	}
}
