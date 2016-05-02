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
	public class TimePeriodManager
	{
		private RepositoryInterface<TimePeriod_DAL> _timeRepo;

		public TimePeriodManager()
		{
			_timeRepo = new EFRepository<TimePeriod_DAL>(new EFTutoringDBContext());
		}

		public void registerTutorDisponibility(TimePeriod disponibility)
		{
			_timeRepo.addObject(
				new TimePeriod_DAL()
				{
					Day=disponibility.Day,
					Hour=disponibility.Hour,
					Student_DAL=new TutorStudent_DAL(){
						FirstName=disponibility.Student.FirstName,
						LastName = disponibility.Student.LastName,
						Mail=disponibility.Student.Mail,
						Number=disponibility.Student.Number
					}
				}
			);
		}

		public void registerHelpedDisponibility(TimePeriod disponibility)
		{
			_timeRepo.addObject(
				new TimePeriod_DAL()
				{
					Day = disponibility.Day,
					Hour = disponibility.Hour,
					Student_DAL = new HelpedStudent_DAL()
					{
						FirstName = disponibility.Student.FirstName,
						LastName = disponibility.Student.LastName,
						Mail = disponibility.Student.Mail,
						Number = disponibility.Student.Number
					}
				}
			);
		}
		public IQueryable<TimePeriod> getAllTutors()
		{
			var list = new List<TimePeriod>();

			var listDal = _timeRepo.GetAll();

			foreach (var time in listDal)
			{
				if(time.Student_DAL is TutorStudent_DAL)
				{
					list.Add(
						new TimePeriod()
						{
							Day = time.Day,
							Hour = time.Hour,
							Student = new TutorStudent(){
								FirstName=time.Student_DAL.FirstName,
								LastName=time.Student_DAL.LastName,
								Mail=time.Student_DAL.Mail,
								Number=time.Student_DAL.Number
							}
						}
					);
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
					list.Add(
						new TimePeriod()
						{
							Day = time.Day,
							Hour = time.Hour,
							Student = new HelpedStudent()
							{
								FirstName = time.Student_DAL.FirstName,
								LastName = time.Student_DAL.LastName,
								Mail = time.Student_DAL.Mail,
								Number = time.Student_DAL.Number
							}
						}
					);
				}
			}
			return list.AsQueryable();
		}

	}
}
