using ITEC491_IndividualProject.App;
using System;
using System.Collections.Generic;

namespace ITEC491_IndividualProject.Workflow
{
	/// <summary>
	/// Class that handles all the performances actions. 
	/// This is where I  implemented bubble sort and selection sort algorithms.
	/// </summary>
	public static class Performances
	{
		/// <summary>
		/// Displays performances menu as well as calls other display methods for performances.
		/// </summary>
		public static void Menu()
		{
			List<string> menuItems = new List<string> { "1. Display All Performances for an Employee", "2. Display All Performances Ordered By Date (Bubble Sort)", "3. Display All Employee Performances Ordered By Work Fullfillment Rate", "4. Back" };
			const int maxMenuItems = 4;
			int selector = 0;
			bool good = false;
			while (selector != maxMenuItems)
			{
				Console.Clear();
				Display.DrawTitle("Performances Menu");
				Display.DrawSubMenu(maxMenuItems, menuItems);
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
		/// <summary>
		/// Method that displays all performances ( from all employees) sorted from highest to lowest work fullfillment rate. (Selection sort)
		/// </summary>
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
		/// <summary>
		/// Method to return employee's full name for the purpose of displaying performances 
		/// </summary>
		/// <param name="employeeId">Id of the employee</param>
		/// <returns></returns>
		private static string GetEmployeeFullName(int employeeId)
		{
			Employee e = new Employee();
			e = Init.App.employees[employeeId - 1];
			return e.FirstName + " " + e.LastName;
		}
		/// <summary>
		/// Method to display all performances tracking records for specific employee.
		/// </summary>
		private static void DisplayAllPerformances()
		{
			/// fetching employee that user has chosen and displaying all of his tracking performance records
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
		/// <summary>
		/// Method that handles choosing the employee for which performance records will be displayed.
		/// </summary>
		/// <returns>Object of the employee for which work performance records will be displayed.</returns>
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
		/// <summary>
		/// Method that does the bubble sorting on the list of performances which is passed.
		/// </summary>
		/// <param name="performances">List of performances</param>
		/// <returns>bubble sorted list of performances</returns>
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
		/// Selection sort implementation
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
				Swap(performances, i, smallest);
			}
			return performances;
		}
		/// <summary>
		/// Helper method for selection sort. It handles the swapping.
		/// </summary>
		/// <param name="performances"></param>
		/// <param name="first"></param>
		/// <param name="second"></param>
		private static void Swap(List<Performance> performances, int first, int second)
		{
			Performance temporary = performances[first];
			performances[first] = performances[second];
			performances[second] = temporary;
		}
	}
}


