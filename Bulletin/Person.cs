using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Bulletin
{
	public class Person
	{
		private string firstname;
		private string lastname;

		public Person(string firstname, string lastname)
		{
			this.firstname = firstname;
			this.lastname = lastname;
		}

		public string Firstname
		{
			get
			{
				return firstname;
			}
			set
			{
				this.firstname = value;
			}
		}

		public string Lastname
		{
			get
			{
				return lastname;
			}
			set
			{
				this.lastname = value;
			}
		}

		public string DisplayName()
		{
			return string.Format("{0} {1}", Lastname, Firstname);
		}

	}

	public class Teacher : Person
	{
		private int salary;
		public string matricule;

		public Teacher(string firstname, string lastname, string mat, int salaire) : base(firstname, lastname)
		{
			this.salary = salaire;
			this.matricule = mat;
		}

		public int Salary
		{
			get
			{
				return this.salary;
			}
		}
	}

	public class Student : Person
	{
		public List<Evaluation> Cours = new List<Evaluation>();

		public string matricule;

		public Student(string firstname, string lastname, string mat) : base(firstname, lastname)
		{
			this.matricule = mat;
		}

		public void Add(Evaluation eval)
		{
			this.Cours.Add(eval);
		}

		public double Average()
		{
			var cote = 0;
			foreach (Evaluation eval in this.Cours)
			{
				cote += eval.Note();

			}
			return cote / this.Cours.Count;
		}
		/*
		public void Bulletin(string path)
		{
			StreamWriter file = new StreamWriter(path, true);
			file.WriteLine("----- Bulletin -----");
			file.WriteLine(string.Format("Nom : {0}\nPrenom : {1}", this.Firstname, this.Lastname));
			file.Close();
		}
		*/
		public void Bulletin()
		{
			
			Console.WriteLine("----- Bulletin -----");
			Console.WriteLine(string.Format("Nom : {0}\n" +
			                                "Prenom : {1}\n" +
			                                "Mat : {2}\n"
			                                , this.Firstname, this.Lastname, this.matricule));
			foreach (Evaluation eval in this.Cours)
			{
				Console.WriteLine(string.Format("Nom du cours : {0}\n" +
				                                "ECTS : {1}\n" +
				                                "Nom du professeur : {2}\n" +
												"Note : {3}\n"
				                                , eval.activity.Name, eval.activity.ECTS, eval.activity.Teacher.matricule, eval.Note()));
			}

			Console.WriteLine(string.Format("Moyenne générale : {0} / 20\n", Average()));
		}
	}
}
