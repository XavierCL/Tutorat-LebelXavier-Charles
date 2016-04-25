using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Student
    {
		[Key]
		public int Id { get; set; }
		public int Number { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Mail { get; set; }
		public TimePeriod Period { get; set; }
		//services mothodes
    }
}
