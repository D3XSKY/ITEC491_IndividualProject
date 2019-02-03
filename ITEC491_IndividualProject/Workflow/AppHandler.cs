using System;

namespace ITEC491_IndividualProject.Workflow
{
	/// <summary>
	/// Class that contains methods for application working context
	/// </summary>
	public static class AppHandler
	{
		public static void Run()
		{
			Init.App.Start();
			Console.Write("Application is starting");
			System.Threading.Thread.Sleep(500);
			Console.Write(".");
			System.Threading.Thread.Sleep(500);
			Console.Write(".");
			System.Threading.Thread.Sleep(500);
			Console.Write(".");
			Console.Clear();
			AppMenu.MainMenu();
		}
		public static void Close()
		{
			Console.Clear();
			Console.Write("Application is closing");
			System.Threading.Thread.Sleep(500);
			Console.Write(".");
			System.Threading.Thread.Sleep(500);
			Console.Write(".");
			System.Threading.Thread.Sleep(500);
			Console.Write(".");
			Environment.Exit(1);
		}
	}
}
