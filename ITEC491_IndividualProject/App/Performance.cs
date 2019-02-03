using System;
using System.Collections.Generic;
using System.Text;

namespace ITEC491_IndividualProject.App
{
	/// <summary>
	/// Class that contains performance properties for an employee
	/// </summary>
	public class Performance
	{
		private string workDescription;
		private double workFullfillmentRate;
		private int employeeId;
		private DateTime performanceDate;
		private bool customerReview;

		/// <summary>
		/// Constructors
		/// </summary>
		public Performance()
		{
			workDescription = "";
			workFullfillmentRate = 0;
			performanceDate = new DateTime();
			employeeId = 0;
			customerReview = false;
		}
		public Performance(string workDescription, double workFullfillmentRate, DateTime performanceDate,int employeeId,bool customerReview)
		{
			this.workDescription = workDescription;
			this.workFullfillmentRate = workFullfillmentRate;
			this.performanceDate = performanceDate;
			this.employeeId = employeeId;
			this.customerReview = customerReview;
		}
		/// <summary>
		/// Getters and setters
		/// </summary>
		public string WorkDescription
		{
			get { return workDescription; }
			set { workDescription = value; }
		}
		public double WorkFullfillmentRate
		{
			get { return workFullfillmentRate; }
			set { workFullfillmentRate = value; }
		}
		public DateTime PerformanceDate
		{
			get { return performanceDate; }
			set { performanceDate = value; }

		}
		public int EmployeeId
		{
			get { return employeeId; }
			set { employeeId = value; }
		}
		public bool CustomerReview
		{
			get { return customerReview; }
			set { customerReview = value; }
		}
	}
}
