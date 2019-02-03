using System;
using System.Collections.Generic;

namespace ITEC491_IndividualProject.Workflow
{
	/// <summary>
	/// This class contains methods that are used to output to console and methods that draw menu and submenu accordingly.
	/// </summary>
	public static class Display
	{
		/// <summary>
		/// Below are methods that handle console outputs so code is easier to read, these methods simply write to the console some repetitve lines.
		/// </summary>
		public static void ErrorMessage()
		{
			Console.WriteLine("Invalid input, press any key to try again");
		}
		public static void DrawStarLine()
		{
			Console.WriteLine("************************");
		}
		public static void DrawDashLine()
		{
			Console.WriteLine("------------------------");
		}
		public static void DrawTitle(string title)
		{
			DrawStarLine();
			Console.WriteLine("+++   " + title + "   +++");
			DrawStarLine();
		}
		/// <summary>
		/// Method that draws menu based on maximum number of items and list of strings (menu items) 
		/// </summary>
		/// <param name="maxitems">Maximum number of menuitems</param>
		/// <param name="menuItems">list of menu items to display</param>
		public static void DrawMenu(int maxitems, List<string> menuItems)
		{
			DrawStarLine();
			foreach (var item in menuItems)
			{
				Console.WriteLine(item);
			}
			DrawStarLine();
			Console.Write("Make your choice: ");
			for (int i = 0; i < menuItems.Count; i++)
			{
				if (i == 0)
				{
					Console.Write("type " + 1 + ",");
				}
				else
				{
					if (i != menuItems.Count - 1)
					{
						Console.Write(" " + (i + 1) + " ");
					}
				}
			}
			Console.Write("or {0} for exit\n", maxitems);
			DrawStarLine();
		}
		/// <summary>
		/// Method that draws submenu based on maximum number of items and list of strings (sub menu items) 
		/// </summary>
		/// <param name="maxSubItems">Maximum number of submenu items</param>
		/// <param name="subMenuItems">list of sub menu items to display</param>
		public static void DrawSubMenu(int maxSubItems, List<string> subMenuItems)
		{
			DrawStarLine();
			foreach (var item in subMenuItems)
			{
				Console.WriteLine(item);
			}
			DrawStarLine();
			Console.Write("Make your choice: ");
			for (int i = 0; i < subMenuItems.Count; i++)
			{
				if (i == 0)
				{
					Console.Write("type " + 1 + ",");
				}
				else
				{
					if (i != subMenuItems.Count - 1)
					{
						Console.Write(" " + (i + 1) + " ");
					}
				}
			}
			Console.Write("or {0} to go back\n", maxSubItems);
			DrawStarLine();
		}
	}
}
