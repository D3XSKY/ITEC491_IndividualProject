using System;
using System.Collections.Generic;

namespace ITEC491_IndividualProject.App
{
	/// <summary>
	/// Employee class that contains employee properties
	/// </summary>
	public class Employee
	{
		private int id;
		private string firstName;
		private string lastName;
		private DateTime dateOfBirth = new DateTime();
		private int employeeType;
		private int departmentId;
		private int contractLength;
		private List<Performance> employeePerformances;

		/// <summary>
		/// Constructors
		/// </summary>
		public Employee()
		{
			id = 0;
			firstName = "";
			lastName = "";
			dateOfBirth = new DateTime();
			employeeType = 0;
			departmentId = 0;
			contractLength = 0;
		}
		public Employee(int id, string firstName, string lastName, DateTime dateOfBirth, int employeeType, int departmentId, int contractLength, List<Performance> employeePerformances)
		{
			this.id = id;
			this.firstName = firstName;
			this.lastName = lastName;
			this.dateOfBirth = dateOfBirth;
			this.employeeType = employeeType;
			this.departmentId = departmentId;
			this.contractLength = contractLength;
			this.employeePerformances = employeePerformances;
		}
		/// <summary>
		/// Getters and setters for Employee
		/// </summary>
		public int Id
		{
			get => id;
			set => id = value;
		}
		public string FirstName
		{
			get => firstName;
			set => firstName = value;
		}
		public string LastName
		{
			get => lastName;
			set => lastName = value;
		}
		public DateTime DateOfBirth
		{
			get => dateOfBirth;
			set => dateOfBirth = value;

		}
		public int EmployeeType
		{
			get => employeeType;
			set => employeeType = value;
		}
		public int DepartmentId
		{
			get => departmentId;
			set => departmentId = value;
		}
		public int ContractLength
		{
			get => contractLength;
			set => contractLength = value;
		}
		public List<Performance> EmployeePerformances
		{
			get => employeePerformances;
			set => employeePerformances = value;
		}
	}
}
