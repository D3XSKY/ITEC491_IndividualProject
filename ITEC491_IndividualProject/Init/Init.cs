using ITEC491_IndividualProject.App;
using System;
using System.Collections.Generic;

namespace ITEC491_IndividualProject.Init
{
	/// <summary>
	/// Class that will be used to seed some data required for testing the application
	/// </summary>
	public class Init
	{
		public static List<Department> departments = new List<Department>()
		{
			new Department("Finance",1,"Department that deals with finances"),
			new Department("Accounting",2,"Department that deals with accounting"),
			new Department("IT",3,"Department that takes care about developers"),
			new Department("Human Resources",4,"Department that deals with HR"),
			new Department("Test",5,"Department that deals with test")
		};
		public static List<Performance> e1 = new List<Performance>() {
			new Performance("Developing",99.5,DateTime.Parse("2019-02-03"),1,false),
			new Performance("Individual Project",35.5,DateTime.Parse("1999-08-03"),1,true),
			new Performance("Test",72.2,DateTime.Parse("2007-08-03"),1,false),
			new Performance("Test 2",72.9,DateTime.Parse("2004-08-03"),1,true)
		};
		public static List<Performance> e2 = new List<Performance>() {
			new Performance("Developing",48.5,DateTime.Parse("2019-02-02"),2,false),
			new Performance("Individual Project",12.88,DateTime.Parse("2000-08-03"),2,true),
			new Performance("Test",96,DateTime.Parse("2002-08-03"),2,false),
			new Performance("Test 2",77,DateTime.Parse("2012-08-03"),2,true)
		};
		public static List<Performance> e3 = new List<Performance>() {
			new Performance("Developing",39.5,DateTime.Parse("2019-02-02"),3,false),
			new Performance("Individual Project",56.5,DateTime.Parse("2019-08-03"),2,true),
			new Performance("Test",72.2,DateTime.Parse("2019-01-31"),2,true),
			new Performance("Test 2",5.9,DateTime.Parse("2015-08-03"),2,true)
		};
		public static List<Performance> e4 = new List<Performance>() {
			new Performance("Developing",85.1,DateTime.Parse("2017-02-02"),4,false),
			new Performance("Individual Project",83,DateTime.Parse("2016-08-03"),4,false),
			new Performance("Test",25,DateTime.Parse("2014-01-31"),4,false),
			new Performance("Test 2",31.85,DateTime.Parse("2018-01-01"),4,true)
		};
		public static List<Employee> employees = new List<Employee>()
		{
			new Employee(1,"Dejan","Misic",DateTime.Parse("1992-08-03"),5,2,4,e1),
			new Employee(2,"Adi","Imamovic",DateTime.Parse("1995-08-03"),3,1,2,e2),
			new Employee(3,"Asmir","Konjevic",DateTime.Parse("1994-11-10"),5,2,5,e3),
			new Employee(4,"Anel","Taric",DateTime.Parse("1996-05-05"),8,4,1,e4)
		};

	}
}
