using System;
using System.Collections.Generic;
using System.Text;

namespace ITEC491_IndividualProject.Workflow
{
	public static class Display
	{
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
		public static void DrawSubMenu(int maxitems, List<string> menuItems)
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
			Console.Write("or {0} to go back\n", maxitems);
			DrawStarLine();
		}
	}
}
