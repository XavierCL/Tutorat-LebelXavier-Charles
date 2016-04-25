using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace classLibrary.Entities
{
	public class Session_DAL:Entity_DAL
	{
		public TimePeriod_DAL Period { get; set; }
		public TutorStudent_DAL Tutor { get; set; }
		public HelpedStudent_DAL Helped { get; set; }

	}
}
