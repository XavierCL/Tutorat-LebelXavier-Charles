using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary;
using classLibrary.Entities;
using classLibrary.EntityFramework;

namespace DomainLayer
{
	public class TutorStudentManager
	{
		private RepositoryInterface<TutorStudent_DAL> _tutorRepo;

		public TutorStudentManager()
		{
			_tutorRepo = new EFRepository<TutorStudent_DAL>(new EFTutoringDBContext());
		}

		public void registerTutor(TutorStudent tutor)
		{
			//validation
			_tutorRepo.addTutor(new TutorStudent_DAL() { Number = tutor.Numbre, LastName = tutor.LastName });
		}

		public IQueryable<TutorStudent> getAll()
		{
			var list = new List<TutorStudent>();

			var listDal = _tutorRepo.GetAll();

			foreach (var tutor in listDal)
			{
				list.Add(new TutorStudent(){LastName=tutor.LastName, Numbre=tutor.Number});
			}

			return list.AsQueryable();

		}
	}
}
