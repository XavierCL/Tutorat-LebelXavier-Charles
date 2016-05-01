using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.ViewObjects
{
	class TutorHelpedPeriodVO
	{
		public Student2HoursVO tutor{get;set;}
		public StudentVO helped { get; set; }
		public TimePeriodVO period { get; set; }
		public string ToString()
		{
			return "Tutor: " + tutor.ToString() + "\nHelped: " + helped.ToString() + "\nPeriod: " + period.ToString() + '\n';
		}
	}
}
