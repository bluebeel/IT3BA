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
			/*
			Command<double> command;
			Command<double> addCmd;
			Command<double> divCmd;
			Command<double> subCmd;
			Command<double> multCmd;
			*/
			char[] delimiterChars = {' '};
			List<double> arr = new List<double>();
		
			//Console.WriteLine("===  Bienvenue  dans  Calculator  3.1  ===");
			while (true)
			{
				Assembly computer = Assembly.LoadFrom("../../BasicCommand.dll");
				Console.WriteLine(computer);
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
				foreach (Type t in computer.GetTypes())
				{
					// Filtre pour ne garder que les classes
					// qui implémentent l'interface "Computer"
					Console.WriteLine(t);
				if (t.IsClass && typeof(BasicCommand.Command).IsAssignableFrom(t))
				{
					Console.WriteLine(">>> Calling: " + t.Name);

					// Création d'un instance de la classe de type "t"
					// et on peut l'affecter à une variable de type "Computer"
					// puisqu'elle implémente cette interface
					BasicCommand.Command c = (BasicCommand.Command)Activator.CreateInstance(t, arr);

					// Appel de la méthode "Compute" avec les données
					// qui ont été extraites du fichier
					Console.WriteLine("Result: " + c.Execute());
				}
				} /*
				addCmd = new AddCommand(arr);
				divCmd = new DivCommand(arr);
				subCmd = new SubCommand(arr);
				multCmd = new MultCommand(arr);
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
				} */

			}
		}
	}
}
