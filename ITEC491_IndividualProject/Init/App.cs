using ITEC491_IndividualProject.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEC491_IndividualProject.Init
{
	/// <summary>
	/// Class from where we will run the console app
	/// </summary>
	public class App
	{
		public static List<Department> departments = new List<Department>();
		public static List<Employee> employees = new List<Employee>();
		public static void Start()
		{
			departments = Init.departments;
			employees = Init.employees;
		}
	}
}
