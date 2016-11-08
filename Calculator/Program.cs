using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Command<double> command;
			IReciever<double> calculator;
			Command<double> addCmd;
			Command<double> divCmd;
			Command<double> subCmd;
			Command<double> multCmd;
			char[] delimiterChars = {' '};
			List<double> arr = new List<double>();

			Console.WriteLine("===  Bienvenue  dans  Calculator  3.1  ===");
			while (true)
			{
				Console.Write(">>>  ");
				string[] arguments = Console.ReadLine().Split(delimiterChars);
				try
				{
					arr = arguments.Skip(1).Select(Double.Parse).ToList();
				}
				catch
				{
					Console.WriteLine(new InvalidArgumentException("letters", "numbers"));
				}

				calculator = new Calculator(arr);
				addCmd = new AddCommand(calculator);
				divCmd = new DivCommand(calculator);
				subCmd = new SubCommand(calculator);
				multCmd = new MultCommand(calculator);
				if (arguments[0] == "Add")
				{
					command = addCmd;
					Console.WriteLine(command.Execute());
				}
				else if (arguments[0] == "Mult")
				{
					command = multCmd;
					Console.WriteLine(command.Execute());
				}
				else if (arguments[0] == "Div")
				{
					command = divCmd;
					Console.WriteLine(command.Execute());
				}
				else if (arguments[0] == "Sub")
				{
					command = subCmd;
					Console.WriteLine(command.Execute());
				}
				else if (arguments[0] == "Exit")
				{
					Environment.Exit(0);
				}
				else
				{
					Console.WriteLine("Command not found");
				}

			}
		}
	}
}
