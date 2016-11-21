using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Calculator
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			char[] delimiterChars = {' '};
			List<double> arr = new List<double>();
		
			Console.WriteLine("===  Bienvenue  dans  Calculator  3.1  ===");
			while (true)
			{
				Assembly computer = Assembly.LoadFrom("../../BasicCommand.dll");
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
				try
				{
					if (arguments[0] == "Exit" || arguments[0] == "exit")
					{
						Environment.Exit(0);
					}
					else
					{
						Type commandType = computer.GetType("BasicCommand" + "." + arguments[0]);

						// Activator.CreateInstance calls the parameterless constructor
						// of the given Type to create an instace.
						var command = Activator.CreateInstance(commandType, arr);
						var method = command.GetType().GetMethod("Execute");

						// We call the method we found with no parameters
						Console.WriteLine("Result: " + method.Invoke(command, null));
					}
				}
				catch (ArgumentNullException)
				{
					// If the command was not found, throw an exception 
					//throw new CommandNotFoundException(commandName);
					Console.WriteLine("Command not found");
				}
			}
		}
	}
}
