using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer
{
    public class SessionPeriod
    {
		public TimePeriod Date { get; set; }
		public TutorStudent Tutor { get; set; }
		public HelpedStudent Helped { get; set; }
    }
}
