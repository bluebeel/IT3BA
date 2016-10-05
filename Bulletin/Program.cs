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
			/*
			Teacher lurkin = new Teacher("Quentin", "Lurkin", "LUR", 2000);
			Teacher combefis = new Teacher("Sebastien", "Combéfis", "CBF", 2500);
			Student saikou = new Student("Saïkou", "BARRY", "14055");
			Student guy = new Student("Guy", "Momo", "14220");
			Student ubert = new Student("Ubert", "Mugamo", "15030");
			Activity pi = new Activity(6, "Projet Info", "2", lurkin);
			Activity poo = new Activity(6, "Prog. Orienté Objet", "3", combefis);
			*/

			string json = "{ 'Activity':[{'ects':6,'name':'poo','code':'2030','professeur':'LUR'},{'ects':6,'name':'pi','code':'2130','professeur':'CBF'}],'Teacher':[{'firstname':'Quentin','lastname':'Lurkin','matricule':'LUR','salary':2000},{'firstname':'Sebastien','lastname':'Combéfis','matricule':'CBF','salary':2130}],'Student':[{'firstname':'Saikou','lastname':'Barry','matricule':'14055'},{'firstname':'Guy','lastname':'Momo','matricule':'14155'}],'Bulletin':[{'type':'grade','code':'2030','eleve':'14055','note':'18'},{'type':'appreciation','code':'2130','eleve':'14055','note':'N'},{'type':'grade','code':'2130','eleve':'14155','note':'15'},{'type':'appreciation','code':'2030','eleve':'14155','note':'TB'}]}";
			Parser m = JsonConvert.DeserializeObject<Parser>(json);
			foreach (Activity activity in m.Activity)
			{
				activity.Teacher = m.Teacher.Find(t => t.matricule == activity.Professeur);
			}
			foreach (Student eleve in m.Student)
			{
				foreach (Bulletin b in m.Bulletin.FindAll(b => b.eleve == eleve.matricule))
				{
					if (b.Type == "grade")
					{
						eleve.Add(new Grade(m.Activity.Find(a => a.Code == b.Code), Int32.Parse(b.Note)));
					}
					else if (b.Type == "appreciation")
					{
						eleve.Add(new Appreciation(m.Activity.Find(a => a.Code == b.Code), b.Note));
					}
				}
				eleve.Bulletin();
			}
		}
	}
}
