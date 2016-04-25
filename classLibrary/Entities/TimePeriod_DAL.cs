using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace classLibrary.Entities
{
	public class TimePeriod_DAL:Entity_DAL
	{
		[Key]
		public int Id { get; set; }
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
