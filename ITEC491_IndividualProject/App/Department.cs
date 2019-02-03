using System;
using System.Collections.Generic;
using System.Text;

namespace ITEC491_IndividualProject.App
{
	/// <summary>
	/// Department class that contains department properties
	/// </summary>
	public class Department
	{
		private string departmentName;
		private int departmentType;
		private string departmentDescription;

		/// <summary>
		/// Constructors
		/// </summary>
		public Department()
		{
			departmentName = "";
			departmentType = 0;
			departmentDescription = "";
		}
		public Department(string departmentName, int departmentType, string departmentDescription)
		{
			this.departmentName = departmentName;
			this.departmentType = departmentType;
			this.departmentDescription = departmentDescription;
		}
		/// <summary>
		/// Getters and setters
		/// </summary>
		public string DepartmentName
		{
			get { return departmentName; }
			set { departmentName = value; }
		}
		public int DepartmentType
		{
			get { return departmentType; }
			set { departmentType = value; }
		}
		public string DepartmentDescription
		{
			get { return departmentDescription; }
			set { departmentDescription = value; }
		}
	}
}
