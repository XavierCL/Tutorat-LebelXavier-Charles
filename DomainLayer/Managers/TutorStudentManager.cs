using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary;
using classLibrary.Entities;
using classLibrary.EntityFramework;
using DomainLayer.Mapping;

namespace DomainLayer
{
	public class TutorStudentManager
	{
		private RepositoryInterface<TutorStudent_DAL> _tutorRepo;

		public TutorStudentManager()
		{
			_tutorRepo = new EFRepository<TutorStudent_DAL>(new EFTutoringDBContext());
		}

		public void setRepo(RepositoryInterface<TutorStudent_DAL> tutorRepo)
		{
			_tutorRepo = tutorRepo;
		}

		public void registerTutor(TutorStudent tutor)
		{
			_tutorRepo.addObject(DalMapper.tutorToDal(tutor));
		}

		public void updateTutor(TutorStudent tutor)
		{
			TutorStudent_DAL oldTutor= _tutorRepo.GetAll().FirstOrDefault(t=>t.Number==tutor.Number);
			oldTutor.Mail = tutor.Mail;
			oldTutor.FirstName = tutor.FirstName;
			oldTutor.LastName = tutor.LastName;
			_tutorRepo.update(oldTutor);
		}

		public IQueryable<TutorStudent> getAll()
		{
			var list = new List<TutorStudent>();

			var listDal = _tutorRepo.GetAll();

			foreach (var tutor in listDal)
			{
				list.Add(DalMapper.dalToTutor(tutor));
			}

			return list.AsQueryable();

		}
	}
}
