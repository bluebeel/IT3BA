using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
		[JsonIgnore]
		public List<Evaluation> Cours = new List<Evaluation>();

		public int matricule;

		public Student(string firstname, string lastname, int mat) : base(firstname, lastname)
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

		public void Bulletin()
		{
			
			Console.WriteLine("Bulletin :");
			foreach (Evaluation eval in this.Cours)
			{
				Console.WriteLine(string.Format("\tNom du cours : {0}\n" +
				                                "\tECTS : {1}\n" +
				                                "\tNom du professeur : {2}\n" +
												"\tNote : {3}\n"
				                                , eval.activity.Name, eval.activity.ECTS, eval.activity.Teacher.matricule, eval.Note()));
			}

			Console.WriteLine(string.Format("\tMoyenne générale : {0} / 20\n", Average()));
		}
	}
}
