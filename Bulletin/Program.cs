using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bulletin
{
	class Program
	{
		public class Globals
		{
			private static Parser m;
			private static MenuCollection collection;
			public static Parser M
			{
				get
				{
					return m;
				}
				set
				{
					m = value;
				}
			}
			public static MenuCollection Collection
			{
				get
				{
					return collection;
				}
				set
				{
					collection = value;
				}
			}

		}

		static void Main(string[] args)
		{
			// build a collection of menus
			// can have as deep a structure as you like
			// give each menu a unique integer MenuId
			// link to other menus by setting HasSubMenu to true, and the SubMenuId to the MenuId of the menu you wish to link to
			// or, set HasSubMenu to false, and have an Action performed when the menuitem is selected

			StreamReader r = new StreamReader("../../db.json");
			string content = r.ReadToEnd();
			Globals.M = JsonConvert.DeserializeObject<Parser>(content);
			List<Bulletin> x = Globals.M.Bulletin;
			Console.WriteLine(Globals.M.Bulletin);
			foreach (Activity activity in Globals.M.Activity)
			{
				activity.Teacher = Globals.M.Teacher.Find(t => t.matricule == activity.Professeur);
			}
			foreach (Student eleve in Globals.M.Student)
			{
				foreach (Bulletin b in Globals.M.Bulletin.FindAll(b => b.Eleve == eleve.matricule))
				{
					if (b.Type == "grade")
					{
						eleve.Add(new Grade(Globals.M.Activity.Find(a => a.Code == b.Code), Int32.Parse(b.Note)));
					}
					else if (b.Type == "appreciation")
					{
						eleve.Add(new Appreciation(Globals.M.Activity.Find(a => a.Code == b.Code), b.Note));
					}
				}
			}
			string json = JsonConvert.SerializeObject(Globals.M);
			Console.WriteLine(json);

			Globals.Collection = new MenuCollection()
			{
				Menus =
			{
				new Menu()
				{
					MenuId = 1,
					Title = "Main Menu",
					MenuItems =
					{
						new MenuItem()
						{
							Text = "Show Activities",
							HasSubMenu = true,
							SubMenuId = 11
						},
						new MenuItem()
						{
							Text = "Show Teachers",
							HasSubMenu = true,
							SubMenuId = 12
						},
						new MenuItem()
						{
							Text = "Show Students",
							HasSubMenu = true,
							SubMenuId = 13
						},
						new MenuItem()
						{
							Text = "Exit the program",
							HasSubMenu = false,
							Action = () =>
							{
								 Environment.Exit(0);
							}
						}
					}
				},
				new Menu()
				{
					MenuId = 11,
						Title = "Activities",
					MenuItems =
					{
						new MenuItem()
						{
							Text = "Show all activities",
							HasSubMenu = false,
							Action = ShowAllActivities
						},
						new MenuItem()
						{
							Text = "Find a activity by his code",
							HasSubMenu = false,
							Action = FindActivityByCode
						},
						new MenuItem()
						{
							Text = "Back to the main menu",
							HasSubMenu = true,
							SubMenuId = 1
						},
						new MenuItem()
						{
							Text = "Exit the program",
							HasSubMenu = false,
							Action = () =>
							{
								Environment.Exit(0);
							}
						},
					}
				},
				new Menu()
				{
					MenuId = 12,
						Title = "Teachers",
					MenuItems =
					{
						new MenuItem()
						{
							Text = "Show all teachers",
							HasSubMenu = false,
							Action = ShowAllTeachers
						},
						new MenuItem()
						{
							Text = "Find a teacher by his matricule",
							HasSubMenu = false,
							Action = FindTeacherByMatricule
						},
						new MenuItem()
						{
							Text = "Back to the main menu",
							HasSubMenu = true,
							SubMenuId = 1
						},
						new MenuItem()
						{
							Text = "Exit the program",
							HasSubMenu = false,
							Action = () =>
							{
								Environment.Exit(0);
							}
						},
					}
				},
				new Menu()
				{
					MenuId = 13,
						Title = "Students",
					MenuItems =
					{
						new MenuItem()
						{
							Text = "Show all students",
							HasSubMenu = false,
							Action = ShowAllStudents
						},
						new MenuItem()
						{
							Text = "Find a student by his code",
							HasSubMenu = false,
							Action = FindStudentByMatricule
						},
						new MenuItem()
						{
							Text = "Back to the main menu",
							HasSubMenu = true,
							SubMenuId = 1
						},
						new MenuItem()
						{
							Text = "Exit the program",
							HasSubMenu = false,
							Action = () =>
							{
								Environment.Exit(0);
							}
						},
					}
				}

			}
			};

			Globals.Collection.ShowMenu(1);
			Console.ReadLine();
		}

		static void ShowAllActivities()
		{
			foreach (Activity activity in Globals.M.Activity)
			{
				Console.WriteLine("{0} - {1} - {2}", activity.Code, activity.Name, activity.ECTS);
			}
			Console.WriteLine("--------------------\n");
			Globals.Collection.ShowMenu(11);
		}

		static void FindActivityByCode()
		{
			string code = Console.ReadLine();
			Activity course = Globals.M.Activity.Find(c => c.Code == code);
			Console.Clear();
			Console.WriteLine(string.Format("Nom : {0}\n" +
											"ECTS : {1}\n" +
											"Code : {2}\n" +
											"Teacher : {3} {4}\n"
											, course.Name, course.ECTS, course.Code, course.Teacher.Firstname, course.Teacher.Lastname));
			Console.WriteLine("--------------------\n");
			Globals.Collection.ShowMenu(11);
		}

		static void ShowAllTeachers()
		{
			foreach (Teacher teacher in Globals.M.Teacher)
			{
				Console.WriteLine("{0} - {1} {2}", teacher.matricule, teacher.Firstname, teacher.Lastname);
			}
			Console.WriteLine("--------------------\n");
			Globals.Collection.ShowMenu(12);
		}

		static void FindTeacherByMatricule()
		{
			string code = Console.ReadLine();
			Teacher prof = Globals.M.Teacher.Find(c => c.matricule == code);
			Console.Clear();
			Console.WriteLine(string.Format("Nom : {0} {1}\n" +
											"Matricule : {2}\n" +
											"Salary : {3} €\n"
											, prof.Lastname, prof.Firstname, prof.matricule, prof.Salary));
			Console.WriteLine("--------------------\n");
			Globals.Collection.ShowMenu(12);
		}

		static void ShowAllStudents()
		{
			foreach (Student eleve in Globals.M.Student)
			{
				Console.WriteLine("{0} - {1} {2}", eleve.matricule, eleve.Firstname, eleve.Lastname);
			}
			Console.WriteLine("--------------------\n");
			Globals.Collection.ShowMenu(13);
		}

		static void FindStudentByMatricule()
		{
			string code = Console.ReadLine();
			Student std = Globals.M.Student.Find(c => c.matricule == code);
			Console.Clear();
			Console.WriteLine(string.Format("Nom : {0} {1}\n" +
											"Matricule : {2}\n"
											, std.Lastname, std.Firstname, std.matricule));
			std.Bulletin();
			Console.WriteLine("--------------------\n");
			Globals.Collection.ShowMenu(13);
		}
	}
}