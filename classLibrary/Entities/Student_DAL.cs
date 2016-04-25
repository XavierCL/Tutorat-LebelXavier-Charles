using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace classLibrary.Entities
{
	public class Student_DAL:Entity_DAL
	{
		public int Number { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public String Mail { get; set; }
		public IEnumerable<int> PeriodKey { get; set; }
	}
}
