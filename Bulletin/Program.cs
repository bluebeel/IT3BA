using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bulletin
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Teacher lurkin = new Teacher("Quentin", "Lurkin", 2000);
			Teacher combefis = new Teacher("Sebastien", "Combéfis", 2500);
			Console.WriteLine(lurkin.DisplayName());
			Console.WriteLine(combefis.DisplayName());
			Student saikou = new Student("Saïkou", "BARRY");
			Student guy = new Student("Guy", "Momo");
			Student ubert = new Student("Ubert", "Mugamo");
			Activity pi = new Activity(6, "Projet Info", "2", lurkin);
			Activity poo = new Activity(6, "Prog. Orienté Objet", "3", combefis);

			saikou.Add(new Grade(pi, 18));
			saikou.Add(new Appreciation(poo, "B"));
			Console.WriteLine(saikou.Average());

			guy.Add(new Grade(pi, 10));
			guy.Add(new Appreciation(poo, "TB"));
			Console.WriteLine(guy.Average());

			ubert.Add(new Grade(pi, 6));
			ubert.Add(new Appreciation(poo, "C"));
			Console.WriteLine(ubert.Average());

			/*

			saikou.Bulletin(@"/Users/saikouah/Documents/Info-3BA/Cours/Bulletin/test2.txt");

			string a = @"/Users/saikouah/Documents/Info-3BA/Cours/Bulletin/test.csv";

			var reader = new StreamReader(File.OpenRead(a));
			List<string> listA = new List<string>();
			List<string> listB = new List<string>();
			while (!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var values = line.Split(',');

				listA.Add(values[0]);
				listB.Add(values[1]);
			}
			Console.WriteLine("Column 1:");
			foreach (var element in listA)
				Console.WriteLine(element);

			// print column2
			Console.WriteLine("Column 2:");
			foreach (var element in listB)
				Console.WriteLine(element);

			*/

			/*string json = @"{
			  'Name': 'Bad Boys',
			  'ReleaseDate': '1995-4-7T00:00:00',
			  'Genres': [
			    'Action',
			    'Comedy'
			  ]
			}";

			object m = JsonConvert.DeserializeObject(json);

			Console.WriteLine(m);
			*/
		}
	}
}
