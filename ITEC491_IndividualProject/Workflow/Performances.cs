using ITEC491_IndividualProject.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace ITEC491_IndividualProject.Workflow
{
	public static class Performances
	{
		public static void Menu()
		{
			List<string> menuItems = new List<string> { "1. Display All Performances for an Employee", "2. Display All Performances Ordered By Date (Bubble Sort)", "3. Display All Employee Performances Ordered By Work Fullfillment Rate", "4. Exit" };
			const int maxMenuItems = 4;
			int selector = 0;
			bool good = false;
			while (selector != maxMenuItems)
			{
				Console.Clear();
				Display.DrawTitle("Performances Menu");
				Display.DrawMenu(maxMenuItems, menuItems);
				good = int.TryParse(Console.ReadLine(), out selector);
				if (good)
				{
					switch (selector)
					{
						case 1:
							DisplayAllPerformances();
							break;
						case 2:
							DisplayAllPerformancesByDate();
							break;
						case 3:
							DisplayAllPerformancesByWfr();
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
			Employees.Menu();
		}

		private static void DisplayAllPerformancesByWfr()
		{      
			// make a list of all employment performances and sort the list according to the work fullfillment rate from the highest to the lowest
			List<Performance> allPerformances = new List<Performance>();

			foreach (var employee in Init.App.employees)
			{
				foreach (var performance in employee.EmployeePerformances)
				{
					allPerformances.Add(performance);
				}
			}
			List<Performance> sortedList = SelectionSort(allPerformances);
			Console.WriteLine("Displaying all performances ordered by Work Fullfillment rate ");
			foreach (var performance in sortedList)
			{
				Display.DrawDashLine();
				Console.WriteLine("Employee Full Name: " + GetEmployeeFullName(performance.EmployeeId));
				Console.WriteLine("Date: " + performance.PerformanceDate.ToString());
				Console.WriteLine("Work Description: " + performance.WorkDescription);
				Console.WriteLine("Work Fullfillment Rate: " + performance.WorkFullfillmentRate + "%");
				Console.WriteLine("Work Description: " + (performance.CustomerReview ? "Yes" : "No"));
			}
		}
		/// <summary>
		/// Bubble sort on performance dates and display them ordered
		/// </summary>
		private static void DisplayAllPerformancesByDate()
		{
	

			List<Performance> allPerformances = new List<Performance>();

			foreach (var employee in Init.App.employees)
			{
				foreach (var performance in employee.EmployeePerformances)
				{
					allPerformances.Add(performance);
				}
			}
			// bubble sort
			List<Performance> sortedList = BubbleSort(allPerformances);
			Console.WriteLine("Displaying all performances ordered by Date ");
			foreach (var performance in sortedList)
			{
				Display.DrawDashLine();
				Console.WriteLine("Employee Full Name: " + GetEmployeeFullName(performance.EmployeeId));
				Console.WriteLine("Date: " + performance.PerformanceDate.ToString());
				Console.WriteLine("Work Description: " + performance.WorkDescription);
				Console.WriteLine("Work Fullfillment Rate: " + performance.WorkFullfillmentRate + "%");
				Console.WriteLine("Work Description: " + (performance.CustomerReview ? "Yes" : "No"));
			}
		}


		private static string GetEmployeeFullName(int employeeId)
		{
			Employee e = new Employee();
			e = Init.App.employees[employeeId - 1];
			return e.FirstName + " " + e.LastName;
		}

		private static void DisplayAllPerformances()
		{
			Employee e = ChooseEmployee();

			Console.WriteLine("Records for " + e.FirstName + " " + e.LastName);
			Console.WriteLine("\n");
			foreach (var performance in e.EmployeePerformances)
			{
				Console.WriteLine("Date: " + performance.PerformanceDate.ToString());
				Console.WriteLine("Work Description: " + performance.WorkDescription);
				Console.WriteLine("Work Fullfillment Rate: " + performance.WorkFullfillmentRate + "%");
				Console.WriteLine("Work Description: " + (performance.CustomerReview ? "Yes" : "No"));
				Display.DrawDashLine();
			}
		}
		private static Employee ChooseEmployee()
		{
			Employee chosen = new Employee();
			Console.WriteLine("Choose Employee for which you want to see performances:");
			foreach (var employee in Init.App.employees)
			{
				Console.WriteLine("[" + employee.Id + "] " + employee.FirstName + " " + employee.LastName);
			}
			Console.WriteLine("Enter number: ");
			string empId = Console.ReadLine();
			int.TryParse(empId, out int employeeId);
			chosen = Init.App.employees[employeeId - 1];
			Display.DrawStarLine();
			return chosen;

		}
		private static List<Performance> BubbleSort(List<Performance> performances)
		{
			// bubble sort
			for (int i = 0; i < performances.Count; i++)
			{
				for (int sort = 0; sort < performances.Count - 1; sort++)
				{
					if (performances[sort].PerformanceDate < performances[sort + 1].PerformanceDate)
					{
						Performance temp = performances[sort + 1];
						performances[sort + 1] = performances[sort];
						performances[sort] = temp;
					}
				}
			}
			return performances;
		}
		/// <summary>
		/// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-11.php
		/// </summary>
		/// <param name="performances"></param>
		/// <returns></returns>
		private static List<Performance> SelectionSort(List<Performance> performances)
		{
			int smallest;
			for (int i = 0; i < performances.Count - 1; i++)
			{
				smallest = i;

				for (int index = i + 1; index < performances.Count; index++)
				{
					if (performances[index].WorkFullfillmentRate > performances[smallest].WorkFullfillmentRate)
					{
						smallest = index;
					}
				}
				Swap(performances,i, smallest);

			}
			return performances;
		}
		private static void Swap(List<Performance> performances, int first, int second)
		{
			Performance temporary = performances[first];
			performances[first] = performances[second];
			performances[second] = temporary;
		}
	}
}


