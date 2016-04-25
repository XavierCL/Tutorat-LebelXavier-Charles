using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace classLibrary.Entities
{
	public abstract class Entity_DAL
	{
		[Key]
		public int Id { get; set; }

	}
}
