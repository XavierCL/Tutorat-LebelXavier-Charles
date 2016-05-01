using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary;

namespace Test1.ViewObjects
{
	public class TimePeriodVO
	{
		public DayOfWeek Day { get; set; }
		public int Hour { get; set; }

		public string ToString()
		{
			string day;
			if (Day == DayOfWeek.Monday) day = "Monday";
			else if (Day == DayOfWeek.Tuesday) day = "Tuesday";
			else if (Day == DayOfWeek.Wednesday) day = "Wednesday";
			else if (Day == DayOfWeek.Thursday) day = "Thursday";
			else if (Day == DayOfWeek.Friday) day = "Friday";
			else if (Day == DayOfWeek.Saturday) day = "Saturday";
			else day = "Sunday";
			return day + " at " + Hour;
		}
	}
}
