using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Bulletin
{
	class Program
	{
		public class Globals
		{
			// Global variables
			private static Parser m;
			private static int compteur;
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
			public static int Compteur
			{
				get
				{
					return compteur;
				}
				set
				{
					compteur = value;
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
			/* The quickest method of converting between JSON text and a .NET object is using the JsonSerializer. 
			 * The JsonSerializer converts .NET objects into their JSON equivalent 
			 * and back again by mapping the .NET object property names to the JSON property names 
			 * and copies the values for you.
			 * After the deserializing, creation of the Evaluation for each student thanks to the Bulletin Class.
			 */
			using (StreamReader sr = new StreamReader("../../db.json"))
			{
				Globals.M = JsonConvert.DeserializeObject<Parser>(sr.ReadToEnd());
			}
			//StreamReader r = new StreamReader("../../db.json");
			//string content = r.ReadToEnd();
			//Globals.M = JsonConvert.DeserializeObject<Parser>(content);
			Globals.Compteur = Globals.M.Compteur;
			foreach (Activity activity in Globals.M.Activity)
			{
				activity.Teacher = Globals.M.Teacher.Find(t => t.matricule == activity.Professeur);
			}
			foreach (Student eleve in Globals.M.Student)
			{
				foreach (Bulletin b in Globals.M.Bulletin.FindAll(b => Int32.Parse(b.Eleve) == eleve.matricule))
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

			// build a collection of menus
			// give each menu a unique integer MenuId
			// link to other menus by setting HasSubMenu to true, and the SubMenuId to the MenuId of the menu you wish to link to
			// or, set HasSubMenu to false, and have an Action performed when the menuitem is selected
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
							Text = "Add a activity",
							HasSubMenu = false,
								Action = () =>
							{
									Add("activity");
							}
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
							Text = "Add a teacher",
							HasSubMenu = false,
								Action = () =>
							{
									Add("teacher");
							}
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
							Text = "Add a student",
							HasSubMenu = false,
								Action = () =>
							{
									Add("student");
							}
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
		}

		static void ShowAllActivities()
		{
			Console.Clear();
			foreach (Activity activity in Globals.M.Activity)
			{
				Console.WriteLine("[{0}] {1}", activity.Code, activity.Name);
			}
			Console.WriteLine("--------------------\n");
			Key(11);
		}

		static void FindActivityByCode()
		{
			Console.Write("Code : ");
			string code = Console.ReadLine();
			Activity course = Globals.M.Activity.Find(c => c.Code == code);
			Console.Clear();
			Console.WriteLine(string.Format("Name : {0}\n" +
											"ECTS : {1}\n" +
											"Code : {2}\n" +
											"Teacher : {3} {4}\n"
											, course.Name, course.ECTS, course.Code, course.Teacher.Firstname, course.Teacher.Lastname));
			Console.WriteLine("--------------------\n");
			Key(11);
		}

		static void ShowAllTeachers()
		{
			Console.Clear();
			foreach (Teacher teacher in Globals.M.Teacher)
			{
				Console.WriteLine("[{0}] - {1} {2}", teacher.matricule, teacher.Firstname, teacher.Lastname);
			}
			Console.WriteLine("--------------------\n");
			Key(12);
		}

		static void FindTeacherByMatricule()
		{
			Console.Write("Matricule : ");
			string code = Console.ReadLine();
			Teacher prof = Globals.M.Teacher.Find(c => c.matricule == code);
			Console.Clear();
			Console.WriteLine(string.Format("Name : {0} {1}\n" +
											"Matricule : {2}\n" +
											"Salary : {3} €\n"
											, prof.Lastname, prof.Firstname, prof.matricule, prof.Salary));
			Console.WriteLine("--------------------\n");
			Key(12);
		}

		static void ShowAllStudents()
		{
			Console.Clear();
			foreach (Student eleve in Globals.M.Student)
			{
				Console.WriteLine("[{0}] - {1} {2}", eleve.matricule, eleve.Lastname, eleve.Firstname);
			}
			Console.WriteLine("--------------------\n");
			Key(13);
		}

		static void FindStudentByMatricule()
		{
			Console.Write("Code : ");
			string code = Console.ReadLine();
			Student std = Globals.M.Student.Find(c => c.matricule == Int32.Parse(code));
			Console.Clear();
			Console.WriteLine(string.Format("Nom : {0} {1}\n" +
											"Matricule : {2}\n"
											, std.Lastname, std.Firstname, std.matricule));
			std.Bulletin();
			Console.WriteLine("--------------------\n");
			Key(13);
		}

		static void Add(string context)
		{

			switch (context)
			{
				case "student":
					Console.Clear();
					Console.WriteLine("Add student");
					Console.WriteLine("---------------\n");
					Console.Write("Firstname : \t");
					string fStdName = Console.ReadLine();
					Console.Write("Lastname : \t");
					string lStdName = Console.ReadLine();
					Globals.M.Student.Add(new Student(fStdName, lStdName, Globals.Compteur));
					Globals.Compteur += 1;
					Console.WriteLine("\nStudent created\n");
					Save();
					Key(13);
					break;

				case "teacher":
					Console.Clear();
					Console.WriteLine("Add teacher");
					Console.WriteLine("---------------\n");
					Console.Write("Firstname : \t");
					string fTchName = Console.ReadLine();
					Console.Write("Lastname : \t");
					string lTchName = Console.ReadLine();
					Console.Write("Salary : \t");
					int TchSalary;
					while (true)
					{
						int trySalary;
						try
						{
							trySalary = Int32.Parse(Console.ReadLine());
							if (trySalary > 0)
							{

								TchSalary = trySalary;
								break;
							}
							else {
								Console.WriteLine("Please enter a possitif integer as salary.");
								Console.Write("Salary : \t");
							}
						}
						catch
						{
							Console.WriteLine("Please enter an integer as salary.");
							Console.Write("Salary : \t");

						}
					}
					Console.Write("Matricule : \t");
					string matTch;
					while (true)
					{
						matTch = Console.ReadLine();
						bool alreadyExists = Globals.M.Teacher.Any(std => std.matricule == matTch);
						if (alreadyExists)
						{
							Console.WriteLine("A teacher with this matricule already exists");
							Console.Write("Matricule : \t");
						}
						else { break; }
					}
					Globals.M.Teacher.Add(new Teacher(fTchName, lTchName, matTch, TchSalary));
					Console.WriteLine("\nTeacher created\n");
					Save();
					Key(12);
					break;

				case "activity":
					Console.Clear();
					Console.WriteLine("Add activity");
					Console.WriteLine("---------------\n");
					Console.Write("Name : \t");
					string fActName = Console.ReadLine();
					Console.Write("ECTS : \t");
					int ActEcts;
					while (true)
					{
						int tryEcts;
						try
						{
							tryEcts = Int32.Parse(Console.ReadLine());
							if (tryEcts > 0)
							{

								ActEcts = tryEcts;
								break;
							}
							else {
								Console.WriteLine("Please enter a possitif integer as ECTS.");
								Console.Write("ECTS : \t");
							}
						}
						catch
						{
							Console.WriteLine("Please enter an integer as ects.");
							Console.Write("ECTS : \t");
						}
					}
					Console.Write("Code : \t");
					string ActCode;
					while (true)
					{
						ActCode = Console.ReadLine();
						bool codeExists = Globals.M.Activity.Any(std => std.Code == ActCode);
						if (codeExists)
						{
							Console.WriteLine("A activity with this code already exists");
							Console.Write("Code : \t");
						}
						else { break; }
					}
					Console.Write("Prof : \t");
					string ActProf = Console.ReadLine();
					bool profExists = Globals.M.Teacher.Any(std => std.matricule == ActProf);
					if (profExists)
					{
						Activity activity = new Activity(ActEcts, fActName, ActCode);
						activity.Teacher = Globals.M.Teacher.Find(t => t.matricule == activity.Professeur);
						Globals.M.Activity.Add(activity);
						Console.WriteLine("\nActivity created\n");
						Save();
						Key(11);
					}
					else
					{
						Console.WriteLine("The name you gave does not exist. Would you like to create a new teacher ? (y/n) ");
						string answer = "s";
						while (answer != "y" || answer != "n")
						{
							answer = Console.ReadLine();
							if (answer == "y")
							{
								Add("teacher");
							}
							else if (answer == "n")
							{
								Console.Clear();
								Globals.Collection.ShowMenu(11);
							}
							else {
								Console.WriteLine("Please choose between y or n ");
								Console.WriteLine("The name you gave does not exist. Would you like to create a new teacher ? (y/n) ");
							}
						}
					}

					break;
			}
		}

		static void Key(int x)
		{
			while (true)
			{
				Console.WriteLine("\nHit [enter] to go back in the menu ...");
				Console.WriteLine("\nHit [Escape] to exit the program ...");
				var ch = Console.ReadKey(false).Key;
				switch (ch)
				{
					case ConsoleKey.Enter:
						Console.Clear();
						Globals.Collection.ShowMenu(x);
						break;

					case ConsoleKey.Escape:
						Environment.Exit(0);
						break;
				}
			}
		}

		static void Save()
		{
			using (StreamWriter file =
			new StreamWriter("../../db.json"))
			{
				file.WriteLine(JsonConvert.SerializeObject(Globals.M));
			}
		}
	}
}