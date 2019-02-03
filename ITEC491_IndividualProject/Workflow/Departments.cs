using ITEC491_IndividualProject.App;
using System;
using System.Collections.Generic;

namespace ITEC491_IndividualProject.Workflow
{
	/// <summary>
	/// Class that handles addition and displaying all of the departments
	/// </summary>
	public static class Departments
	{
		/// <summary>
		/// Method that displays menu of department options, if user selects 1 on main menu. 
		/// </summary>
		public static void Menu()
		{
			List<string> menuItems = new List<string> { "1. Add Department", "2. Display Departments", "3. Back" };
			const int maxMenuItems = 3;
			int selector = 0;
			bool good = false;
			while (selector != maxMenuItems)
			{
				Console.Clear();
				Display.DrawTitle("Department Menu");
				Display.DrawSubMenu(maxMenuItems, menuItems);
				good = int.TryParse(Console.ReadLine(), out selector);
				if (good)
				{
					switch (selector)
					{
						case 1:
							Add();
							break;
						case 2:
							DisplayDepartments();
							break;
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
			AppMenu.MainMenu();
		}
		/// <summary>
		/// Method to display all departments and some or all of their properties
		/// </summary>
		private static void DisplayDepartments()
		{
			foreach (var department in Init.App.departments)
			{
				Display.DrawDashLine();
				Console.WriteLine("Department Name:\t" + department.DepartmentName);
				Console.WriteLine("Department Type:\t" + (DepartmentTypes)department.DepartmentType);
				Console.WriteLine("Department Description:\t" + department.DepartmentDescription);
				Display.DrawDashLine();
				Console.WriteLine("\n");
			}
		}
		/// <summary>
		/// Method to display add new department.
		/// </summary>
		public static void Add()
		{
			Department d = new Department();
			Display.DrawDashLine();
			Console.WriteLine("Add new department");
			Console.WriteLine("Department Name:\t");
			d.DepartmentName = Console.ReadLine();
			DisplayDepartmentTypes();
			Console.WriteLine("Department Type:\t");
			string departmentType = Console.ReadLine();
			int.TryParse(departmentType, out int departmentId);
			d.DepartmentType = departmentId;
			Console.WriteLine("Department Description:\t");
			d.DepartmentDescription = Console.ReadLine();
			Display.DrawDashLine();
			Console.WriteLine("\n");
			Init.App.departments.Add(d);
			Console.WriteLine("Department successfully added");
			System.Threading.Thread.Sleep(1000);
			Menu();
		}
		/// <summary>
		/// Method to display all departments types while user is adding new department, this way user will set department type.
		/// </summary>
		public static void DisplayDepartmentTypes()
		{
			Console.WriteLine("\nEnter department ID number");
			for (int i = 1; i <= Enum.GetValues(typeof(DepartmentTypes)).Length; i++)
			{
				Console.WriteLine("Id: " + i + " (" + (DepartmentTypes)i + ")");
			}
		}
	}
}
