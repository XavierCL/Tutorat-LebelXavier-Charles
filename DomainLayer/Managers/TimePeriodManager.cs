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
	public class TimePeriodManager
	{
		private RepositoryInterface<TimePeriod_DAL> _timeRepo;

		public TimePeriodManager()
		{
			_timeRepo = new EFRepository<TimePeriod_DAL>(new EFTutoringDBContext());
		}

		public void setRepo(RepositoryInterface<TimePeriod_DAL> timeRepo)
		{
			_timeRepo = timeRepo;
		}

		public void registerTutorDisponibility(TimePeriod disponibility)
		{
			_timeRepo.addObject(DalMapper.tutorPeriodToDal(disponibility));
		}

		public void registerHelpedDisponibility(TimePeriod disponibility)
		{
			_timeRepo.addObject(DalMapper.helpedPeriodToDal(disponibility));
		}
		public IQueryable<TimePeriod> getAllTutors()
		{
			var list = new List<TimePeriod>();

			var listDal = _timeRepo.GetAll();

			foreach (var time in listDal)
			{
				if(time.Student_DAL is TutorStudent_DAL)
				{
					list.Add(DalMapper.dalToTutorPeriod(time));
				}
			}
			return list.AsQueryable();
		}

		public IQueryable<TimePeriod> getAllHelpeds()
		{
			var list = new List<TimePeriod>();

			var listDal = _timeRepo.GetAll();

			foreach (var time in listDal)
			{
				if (time.Student_DAL is HelpedStudent_DAL)
				{
					list.Add(DalMapper.dalToHelpedPeriod(time));
				}
			}
			return list.AsQueryable();
		}

	}
}
