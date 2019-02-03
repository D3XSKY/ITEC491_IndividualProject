using ITEC491_IndividualProject.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEC491_IndividualProject.Workflow
{
	public static class Employees
	{
		public static void Menu()
		{
			List<string> menuItems = new List<string> {"1. Display All Employees","2. Add Employee", "3. Add Performance Record for an Employee", "4. Display Employee Performances", "5. Back" };
			const int maxMenuItems = 5;
			int selector = 0;
			bool good = false;
			while (selector != maxMenuItems)
			{
				Console.Clear();
				Display.DrawTitle("Employees Menu");
				Display.DrawSubMenu(maxMenuItems, menuItems);
				good = int.TryParse(Console.ReadLine(), out selector);
				if (good)
				{
					switch (selector)
					{
						case 1:
							DisplayAllEmployees();
							break;
						case 2:
							Add();
							break;
						case 3:
							Performance();
							break;
						case 4:
							Performances.Menu();
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
			AppMenu.MainMenu();
		}

		private static void DisplayAllEmployees()
		{
			foreach (var employee in Init.App.employees)
			{
				Display.DrawDashLine();
				Console.WriteLine("Id: " + employee.Id);
				Console.WriteLine("Name: " + employee.FirstName + " " + employee.LastName);
				Console.WriteLine("Employee Type: " + (EmployeeTypes)employee.EmployeeType);
				Console.WriteLine("Department: " + ((DepartmentTypes)employee.DepartmentId));
				Console.WriteLine("Contract Length (years): " + employee.ContractLength);
				Console.WriteLine("Date of Birth: " + employee.DateOfBirth.ToString());
				Display.DrawDashLine();
				Console.WriteLine("\n");
			}
		}

		public static void Add()
		{
			Employee e = new Employee
			{
				Id = Init.App.employees.Count + 1
			};
			Display.DrawDashLine();
			Console.WriteLine("Add new employee");
			Console.WriteLine("Employee's First Name:\t");
			e.FirstName = Console.ReadLine();
			Console.WriteLine("Employee's Last Name:\t");
			e.LastName = Console.ReadLine();
			Console.WriteLine("Enter Date of Birth (YYYY-MM-DD): ");
			string dob = Console.ReadLine();
			DateTime date = DateTime.Parse(dob);
			e.DateOfBirth = date;
			Departments.DisplayDepartmentTypes();
			Console.WriteLine("Department Type:\t");
			string departmentType = Console.ReadLine();
			int.TryParse(departmentType, out int departmentId);
			e.DepartmentId = departmentId;
			DisplayEmployeeTypes();
			Console.WriteLine("Employee Type:\t");
			string employeeType = Console.ReadLine();
			int.TryParse(employeeType, out int employeeTypeInt);
			e.EmployeeType = employeeTypeInt;
			Console.WriteLine("Employee Contract Length (years):\t");
			string contractLength = Console.ReadLine();
			int.TryParse(contractLength, out int ctrLength);
			e.ContractLength = ctrLength;
			Display.DrawDashLine();
			Console.WriteLine("\n");
			Init.App.employees.Add(e);
			Console.WriteLine("Employee successfully added");
			System.Threading.Thread.Sleep(1000);
			Menu();
		}
		public static void Performance()
		{
			Employee e = ChooseEmployee();
			Display.DrawDashLine();
			Performance p = new Performance();
			Console.WriteLine("Add performance tracking");
			Console.WriteLine("Enter performance date (YYYY-MM-DD): ");
			string pDate = Console.ReadLine();
			DateTime date = DateTime.Parse(pDate);
			p.PerformanceDate = date;
			Console.WriteLine("Work description:\t");
			p.WorkDescription = Console.ReadLine();
			Console.WriteLine("Work fullfilment rate (%):\t");
			string wpfRate = Console.ReadLine();
			double.TryParse(wpfRate, out double wpfRatePercentage);
			p.WorkFullfillmentRate = wpfRatePercentage;
			p.EmployeeId = e.Id;
			Console.WriteLine("Enter if employee received customer review (yes/no):\t");
			string cReview = Console.ReadLine();
			if (cReview == "yes") 
			{
				p.CustomerReview = true;
			}
			else
			{
				p.CustomerReview = false;
			}
			Display.DrawDashLine();
			Console.WriteLine("\n");
			Init.App.employees[e.Id-1].EmployeePerformances.Add(p);
			Console.WriteLine("Work performance successfully added for " + e.FirstName + " " + e.LastName);
			System.Threading.Thread.Sleep(1000);
			Menu();
		}

		private static Employee ChooseEmployee()
		{
			Employee chosen = new Employee();
			Console.WriteLine("Choose Employee for which you want to add performance:");
			foreach (var employee in Init.App.employees)
			{
				Console.WriteLine("["+employee.Id+"] " + employee.FirstName + " " + employee.LastName);
			}
			Console.WriteLine("Enter number: ");
			string empId = Console.ReadLine();
			int.TryParse(empId, out int employeeId);
			chosen = Init.App.employees[employeeId - 1];
			Display.DrawStarLine();
			return chosen;

		}

		public static void DisplayEmployeeTypes()
		{
			Console.WriteLine("\nEnter employee type reference number");
			for (int i = 1; i <= Enum.GetValues(typeof(EmployeeTypes)).Length; i++)
			{
				Console.WriteLine("Id: " + i + " (" + (EmployeeTypes)i + ")");
			}
		}
	}
}
