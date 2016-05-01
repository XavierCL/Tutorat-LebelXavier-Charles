using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace classLibrary.Entities
{
	public class Session_DAL:Entity_DAL
	{
		public DateTime Date { get; set; }

		public Nullable<int> HelpedStudent_DALId { get; set; }
		public virtual HelpedStudent_DAL HelpedStudent_DAL { get; set; }

		public int TutorStudent_DALId { get; set; }
		public virtual TutorStudent_DAL TutorStudent_DAL { get; set; }

	}
}
