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
		public enum WeekDay
		{
			Monday,
			Tuesday,
			Wednsday,
			Thursday,
			Friday,
			Saturday,
			Sunday
		};

		public WeekDay Day { get; set; }
		public int Hour { get; set; }
	}
}
