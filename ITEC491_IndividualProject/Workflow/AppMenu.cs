using System;
using System.Collections.Generic;

namespace ITEC491_IndividualProject.Workflow
{
	/// <summary>
	/// Class that will handle menu displaying workflow
	/// </summary>
	public static class AppMenu
	{
		/// <summary>
		/// dispays main menu when application starts
		/// https://www.daniweb.com/programming/software-development/code/371819/code-template-for-a-menu-in-a-console-application
		/// </summary>
		public static void MainMenu()
		{
			List<string> menuItems = new List<string> { "1. Departments", "2. Employees", "3. Exit" };
			const int maxMenuItems = 3;
			int selector = 0;
			bool good = false;
			while (selector != maxMenuItems)
			{
				Console.Clear();
				Display.DrawTitle("Main Menu");
				Display.DrawMenu(maxMenuItems, menuItems);
				good = int.TryParse(Console.ReadLine(), out selector);
				if (good)
				{
					switch (selector)
					{
						case 1:
							Departments.Menu();
							break;
						case 2:
							Employees.Menu();
							break;
						// possibly more cases here
						default:
							if (selector != maxMenuItems)
							{
								Display.ErrorMessage();
							}
							break;
					}
				}
				else
				{
					Display.ErrorMessage();
				}
				if (selector != maxMenuItems)
					Console.ReadKey();
			}
			AppHandler.Close();
		}



		}
	}


