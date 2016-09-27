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
			Teacher lurkin = new Teacher("Quentin", "Lurkin", "LUR", 2000);
			Teacher combefis = new Teacher("Sebastien", "Combéfis", "CBF", 2500);
			Console.WriteLine(lurkin.DisplayName());
			Console.WriteLine(combefis.DisplayName());
			Student saikou = new Student("Saïkou", "BARRY", "14055");
			Student guy = new Student("Guy", "Momo", "14220");
			Student ubert = new Student("Ubert", "Mugamo", "15030");
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
			//string json = @"{'Activity':[{'ects':6,'name':'poo','code':'2030','professeur': 'LUR'},{'ects':6,'name':'pi','code':'2130','professeur': 'CBF'}],'Student':[{'firstname':'Saikou','lastname':'Barry'}]}";
			//Parser m = JsonConvert.DeserializeObject<Parser>(json, settings);

			string json = "{ 'Activity':[{'ects':6,'name':'poo','code':'2030','professeur':'LUR'},{'ects':6,'name':'pi','code':'2130','professeur':'CBF'}],'Teacher':[{'firstname':'Quentin','lastname':'Lurkin','matricule':'LUR','salary':2000},{'firstname':'Sebastien','lastname':'Combéfis','matricule':'CBF','salary':2130}],'Student':[{'firstname':'Saikou','lastname':'Barry','matricule':'14055'},{'firstname':'Guy','lastname':'Momo','matricule':'14155'}],'Bulletin':[{'type':'grade','code':'2030','eleve':'14055','note':'18'},{'type':'appreciation','code':'2130','eleve':'14055','note':'N'},{'type':'grade','code':'2130','eleve':'14155','note':'15'},{'type':'appreciation','code':'2030','eleve':'14155','note':'TB'}]}";
			Parser m = JsonConvert.DeserializeObject<Parser>(json);
			foreach (Student eleve in m.Student)
			{
				Console.WriteLine(eleve.Firstname + " " + eleve.Lastname);
			}
			foreach (Activity activity in m.Activity)
			{
				Console.WriteLine(activity.ECTS + "-" + activity.Name + "-" + activity.Code);
				Console.WriteLine("Mat. : " + activity.Professeur);
			}
			foreach (Teacher teacher in m.Teacher)
			{
				Console.WriteLine(teacher.Firstname + "-" + teacher.Lastname + "-" + teacher.matricule);
				Console.WriteLine("Salary : " + teacher.Salary);
			}
		}
	}
}
