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
			Student saikou = new Student("Saïkou", "BARRY", 14055);
			Student guy = new Student("Guy", "Momo", 14220);
			Student ubert = new Student("Ubert", "Mugamo", 15030);
			Activity pi = new Activity(6, "Projet Info", "2", lurkin);
			Activity poo = new Activity(6, "Prog. Orienté Objet", "3", combefis);

			/*
			saikou.Add(new Grade(pi, 18));
			saikou.Add(new Appreciation(poo, "B"));
			Console.WriteLine(saikou.Average());

			guy.Add(new Grade(pi, 10));
			guy.Add(new Appreciation(poo, "TB"));
			Console.WriteLine(guy.Average());

			ubert.Add(new Grade(pi, 6));
			ubert.Add(new Appreciation(poo, "C"));
			Console.WriteLine(ubert.Average());
			*/

			/*

			saikou.Bulletin(@"/Users/saikouah/Documents/Info-3BA/Cours/Bulletin/test2.txt");
			 */

			JsonConverter[] converters = { new EvaluationConverter() };
			JsonSerializerSettings settings = new  JsonSerializerSettings() {Converters = converters};
			string json = @"{'Activity':[{'ects':6,'name':'poo','code':'2030','professeur':{'firstname':'Quentin','lastname':'Lurkin','salary':2000}},{'ects':6,'name':'pi','code':'2130','professeur':{'firstname':'Sebastien','lastname':'Combefis','salary':2000}}],'Student':[{'firstname':'Saikou','lastname':'Barry','grade':[{'activity':{'ects':6,'name':'poo','code':'2030','professeur':{'firstname':'Quentin','lastname':'Lurkin','salary':2000}},'note':18},{'activity':{'ects':6,'name':'poo','code':'2030','professeur':{'firstname':'Quentin','lastname':'Lurkin','salary':2000}},'note':18}],'appreciation':[{'activity':{'ects':6,'name':'poo','code':'2030','professeur':{'firstname':'Quentin','lastname':'Lurkin','salary':2000}},'appreciation':'B'},{'activity':{'ects':6,'name':'poo','code':'2030','professeur':{'firstname':'Quentin','lastname':'Lurkin','salary':2000}},'appreciation':'TB'}]}]}";
			Parser m = JsonConvert.DeserializeObject<Parser>(json, settings);

			Console.WriteLine(m.Evaluation.Count);
			/*foreach (Student eleve in m.Student)
			{
				Console.WriteLine(eleve.Firstname + " " + eleve.Lastname);
				Console.WriteLine(eleve.Cours.Count);
			}
			foreach (Activity activity in m.Activity)
			{
				Console.WriteLine(activity.ECTS + "-" + activity.Name + "-" + activity.Code);
				Console.WriteLine("Mat. : " + activity.matricule);
			}*/
		}
	}
}
