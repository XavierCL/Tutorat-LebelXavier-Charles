using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
	public class TimePeriod
	{
		public DayOfWeek Day { get; set; }
		public int Hour { get; set; }
		public Student Student { get; set; }

		public bool equals(TimePeriod other)
		{
			return Day == other.Day && Hour == other.Hour;
		}
	}
}
