using System;
using System.Collections.Generic;
using System.Linq;

namespace Bulletin
{
	//represents a line/option in a menu
	class MenuItem
	{
		// displayed in the menu
		public string Text { get; set; }

		//is there a sub menu
		public bool HasSubMenu { get; set; }

		// if there's a submenu, what's its id
		public int? SubMenuId { get; set; }

		//if there isn't a sub menu, what should we do
		public Action Action { get; set; }
	}

	//represents one menu i.e. a collection of options
	class Menu
	{
		public Menu()
		{
			MenuItems = new List<MenuItem>();
		}

		public int MenuId { get; set; }
		public List<MenuItem> MenuItems { get; set; }
		public string Title { get; set; }

		public void PrintToConsole()
		{
			Console.WriteLine(Title);
			foreach (MenuItem item in MenuItems)
			{
				Console.WriteLine(MenuItems.IndexOf(item) + " : " + item.Text);
			}
		}
	}

	//represents all the menus
	class MenuCollection
	{
		public MenuCollection()
		{
			Menus = new List<Menu>();
		}

		public List<Menu> Menus { get; set; }

		public void ShowMenu(int id)
		{
			//get the menu we want to display and call its PrintToConsole method
			var currentMenu = Menus.Where(m => m.MenuId == id).Single();
			currentMenu.PrintToConsole();

			//wait for user input
			string choice = Console.ReadLine();
			int choiceIndex;

			//once we have the users selection make sure its an integer and in range of our menu options
			//if not then show an error message and re-display the menu
			if (!int.TryParse(choice, out choiceIndex) || currentMenu.MenuItems.Count < choiceIndex +1 || choiceIndex < 0)
			{
				Console.Clear();
				Console.WriteLine("Invalid selection - try again\n");
				ShowMenu(id);
			}
			else
			{
				// if the selection is good, then retrieve the corresponding menu item
				var menuItemSelected = currentMenu.MenuItems[choiceIndex];

				// if there's a sub menu then display it
				if (menuItemSelected.HasSubMenu)
				{
					Console.Clear();
					ShowMenu(menuItemSelected.SubMenuId.Value);
				}
				// otherwise perform whatever action we need
				else
				{
					menuItemSelected.Action();
				}
			}
		}
	}
}

