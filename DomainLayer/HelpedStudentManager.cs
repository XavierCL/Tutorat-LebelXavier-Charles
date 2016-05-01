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
	public class HelpedStudentManager
	{
		private RepositoryInterface<HelpedStudent_DAL> _helpedRepo;

		public HelpedStudentManager()
		{
			_helpedRepo = new EFRepository<HelpedStudent_DAL>(new EFTutoringDBContext());
		}

		public void registerHelped(HelpedStudent helped)
		{
			_helpedRepo.addObject(
				new HelpedStudent_DAL()
				{
					Number = helped.Number,
					LastName = helped.LastName,
					FirstName = helped.FirstName,
					Mail = helped.Mail,
				}
			);
		}

		public IQueryable<TutorStudent> getAll()
		{
			var list = new List<TutorStudent>();

			var listDal = _helpedRepo.GetAll();

			foreach (var helped in listDal)
			{
				list.Add(
					new TutorStudent()
					{
						LastName = helped.LastName,
						FirstName = helped.FirstName,
						Mail = helped.Mail,
						Number = helped.Number
					}
				);
			}
			return list.AsQueryable();
		}

		public void updateHelped(HelpedStudent helped)
		{
			IEnumerable<HelpedStudent_DAL> oldHelpeds = _helpedRepo.GetAll().Where(h => h.Number == helped.Number);
			HelpedStudent_DAL oldHelped = null;
			foreach (var individual in oldHelpeds)
			{
				oldHelped = individual;
			}
			oldHelped.Mail = helped.Mail;
			oldHelped.FirstName = helped.FirstName;
			oldHelped.LastName = helped.LastName;
			_helpedRepo.update(oldHelped);
		}
	}
}
