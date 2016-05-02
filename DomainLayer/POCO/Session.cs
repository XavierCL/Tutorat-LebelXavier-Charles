using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class Session
    {
		public DateTime Date { get; set; }
		public TutorStudent Tutor { get; set; }
		public HelpedStudent Helped { get; set; }

		public bool equals(Session other)
		{
			return Date == other.Date && Tutor.Number == other.Tutor.Number && Helped.Number == other.Helped.Number;
		}
    }
}
