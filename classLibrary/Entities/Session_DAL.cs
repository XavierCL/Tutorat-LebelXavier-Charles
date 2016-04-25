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
		[Key]
		public int Id { get; set; }
		public int PeriodKey { get; set; }
		public int TutorKey { get; set; }
		public int HelpedKey { get; set; }

	}
}
