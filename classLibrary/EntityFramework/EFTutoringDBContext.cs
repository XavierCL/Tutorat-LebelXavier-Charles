using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using classLibrary.EntityFramework;
using classLibrary.Entities;

namespace classLibrary.EntityFramework
{
	public class EFTutoringDBContext:DbContext
	{
		public DbSet<TutorStudent_DAL> Tutors {get;set;}

		public EFTutoringDBContext()
		{
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFTutoringDBContext>());
		}
	}
}
