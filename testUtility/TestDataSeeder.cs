using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using classLibrary.EntityFramework;
using classLibrary.Entities;
using classLibrary;

namespace testUtility
{
    public class TestDataSeeder
    {
		public EFRepository<TutorStudent_DAL> _tutors;
		public EFRepository<HelpedStudent_DAL> _helpeds;
		public EFRepository<Session_DAL> _sessions;
		public EFRepository<TimePeriod_DAL> _periods;
		public TestDataSeeder()
		{
			DbContext _context = new EFTutoringDBContext();
			_tutors = new EFRepository<TutorStudent_DAL>(_context);
			_helpeds = new EFRepository<HelpedStudent_DAL>(_context);
			_sessions = new EFRepository<Session_DAL>(_context);
			_periods = new EFRepository<TimePeriod_DAL>(_context);
		}

		public void addSeeds()
		{
			addDisponibilities();
			addTutors();
			//addHelpeds();
			//addSessions();
		}

		public void addDisponibilities()
		{
			addDisponibility(TimePeriod_DAL.WeekDay.Monday, 13, 15);
			addDisponibility(TimePeriod_DAL.WeekDay.Wednsday, 12, 14);
			addDisponibility(TimePeriod_DAL.WeekDay.Friday, 8, 12);
			addDisponibility(TimePeriod_DAL.WeekDay.Monday, 10, 12);
			addDisponibility(TimePeriod_DAL.WeekDay.Monday, 16, 18);
			addDisponibility(TimePeriod_DAL.WeekDay.Thursday, 16, 17);
			addDisponibility(TimePeriod_DAL.WeekDay.Friday, 12, 16);
		}

		public void addTutors()
		{
			List<int> dispo1 = new List<int>();
			//TODO: get IENUmerable <int> from get ids method
			dispo1.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Monday, 13));
			dispo1.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Monday, 14));
			dispo1.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Wednsday, 12));
			dispo1.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Wednsday, 13));
			addTutor(11111, "Gagnon", "Éric", "EG1@yopmail.com", dispo1);
			List<int> dispo2 = new List<int>();
			dispo2.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Wednsday, 12));
			dispo2.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Wednsday, 13));
			addTutor(22222, "Hamel", "Isabelle", "IH1@yopmail.com", dispo2);
			List<int> dispo3 = new List<int>();
			dispo3.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Wednsday, 12));
			dispo3.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Wednsday, 13));
			addTutor(22222, "Simard", "Léo", "LS1@yopmail.com", dispo3);
			List<int> dispo4 = new List<int>();
			dispo4.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Monday, 13));
			dispo4.Add(getDisponibilityId(TimePeriod_DAL.WeekDay.Monday, 14)); 

			addTutor(33333, "Lepage", "Marc", "ML1@yopmail.com", dispo4);
		}

		public void addTutor(int number, string lastName, string firstName, string mail, IEnumerable<int> period)
		{
			_tutors.addObject(new TutorStudent_DAL(){
				Number=number,
				LastName=lastName,
				FirstName=firstName,
				Mail=mail,
				PeriodKey=period
			});
		}

		public void addDisponibility(TimePeriod_DAL.WeekDay day, int begin, int end)
		{
			while (begin < end)
			{
				_periods.addObject(new TimePeriod_DAL() { Day = day, Hour = begin });
				++begin;
			}
		}

		public int getDisponibilityId(TimePeriod_DAL.WeekDay day, int hour)
		{
			var list = _periods.GetAll();
			foreach (var period in list)
			{
				if (period.Day == day && period.Hour == hour) return period.Id;
			}
			_periods.addObject(new TimePeriod_DAL(){Day=day, Hour=hour});
			return getDisponibilityId(day, hour);
		}

		public void removeAll()
		{
			_tutors.removeAll();
			_helpeds.removeAll();
			_periods.removeAll();
			_sessions.removeAll();
		}
    }
}
