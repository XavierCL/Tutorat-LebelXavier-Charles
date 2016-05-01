using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace classLibrary.Entities
{
	public class TimePeriod_DAL:Entity_DAL
	{
		public DayOfWeek Day { get; set; }
		public int Hour { get; set; }

		public Nullable<int> Student_DALId { get; set; }
		public virtual Student_DAL Student_DAL { get; set; }
	}
}
