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
			Dictionary<string, Type> commands = new Dictionary<string, Type>();
			List<double> arr = new List<double>();

			foreach (string sFileName in System.IO.Directory.GetFiles("../../dll"))
			{
				if (System.IO.Path.GetExtension(sFileName) == ".dll")
				{
					Assembly computer = Assembly.LoadFrom(sFileName);
					string nameSpace = "BasicCommand";
					var q = from t in computer.GetTypes()
							where t.IsClass && t.Namespace == nameSpace
							select t;
					foreach (var command in q) {
						if (command.Name == "Command")
						{
							continue;
						}
						else {
							commands.Add(command.Name, command);
						}
					}
				}
			}
		
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
				if (arguments[0] == "Exit" || arguments[0] == "exit")
					{
						Environment.Exit(0);
					}
				else
				{
					try
					{
						// Activator.CreateInstance calls the parameterless constructor
						// of the given Type to create an instace.
						var command = Activator.CreateInstance(commands[arguments[0]], arr);
						var method = command.GetType().GetMethod("Execute");

						// We call the method we found with no parameters
						Console.WriteLine("Result: " + method.Invoke(command, null));
					}
					catch (ArgumentNullException)
					{
						// If the command was not found, throw an exception 
						//throw new CommandNotFoundException(commandName);
						Console.WriteLine("Command not found : " + arguments[0]);
					}
						
				}
			}
				
		}
	}
}
