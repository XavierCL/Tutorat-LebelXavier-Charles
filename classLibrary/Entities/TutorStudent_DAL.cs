using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace classLibrary.Entities
{
	public class TutorStudent_DAL:Entity_DAL
	{
		public int Number { get; set; }
		public String LastName { get; set; }

		public TutorStudent_DAL()
		{
 
		}
	}
}
