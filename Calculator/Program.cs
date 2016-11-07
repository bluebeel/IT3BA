using System;
using System.Collections.Generic;

namespace Calculator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Command<double> command;
			IReciever<double> calculator;
			AddCommand addCmd;
			MultCommand multCmd;
			char[] delimiterChars = {' '};

			Console.WriteLine("===  Bienvenue  dans  Calculator  3.1  ===");
			while (true)
			{
				Console.Write(">>>  ");
				string[] arguments = Console.ReadLine().Split(delimiterChars);
				calculator = new Calculator(arguments);
				addCmd = new AddCommand(calculator);
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
				else
				{
					Console.WriteLine("Command not found");
				}

			}
		}
	}
}
