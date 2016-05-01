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
			addHelpeds();
			addSessions();
		}

		public void addDisponibilities()
		{
			addDisponibility(DayOfWeek.Monday, 13, 15);
			addDisponibility(DayOfWeek.Wednesday, 12, 14);
			addDisponibility(DayOfWeek.Friday, 8, 12);
			addDisponibility(DayOfWeek.Monday, 10, 12);
			addDisponibility(DayOfWeek.Monday, 16, 18);
			addDisponibility(DayOfWeek.Thursday, 16, 17);
			addDisponibility(DayOfWeek.Friday, 12, 16);
		}

		public void addDisponibility(DayOfWeek day, int begin, int end)
		{
			while (begin < end)
			{
				_periods.addObject(new TimePeriod_DAL() { Day = day, Hour = begin });
				++begin;
			}
		}

		public void addTutors()
		{
			List<TimePeriod_DAL> dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Monday, 13, 15));
			dispo.AddRange(getDisponibilities(DayOfWeek.Wednesday, 12, 14));
			addTutor(11111, "Gagnon", "Éric", "EG1@yopmail.com", dispo);
			dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Wednesday, 12, 14));
			addTutor(22222, "Hamel", "Isabelle", "IH1@yopmail.com", dispo);
			dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Wednesday, 12, 14));
			addTutor(22222, "Simard", "Léo", "LS1@yopmail.com", dispo);
			dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Monday, 13, 15));
			dispo.AddRange(getDisponibilities(DayOfWeek.Friday, 8, 12));
			addTutor(33333, "Lepage", "Marc", "ML1@yopmail.com", dispo);
			dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Tuesday, 10, 12));
			dispo.AddRange(getDisponibilities(DayOfWeek.Thursday, 16, 18));
			addTutor(55555, "Vachon", "Karine", "KV1@yopmail.com", dispo);
		}

		public ICollection<TimePeriod_DAL> getDisponibilities(DayOfWeek day, int begin, int end)
		{
			List<TimePeriod_DAL> result = new List<TimePeriod_DAL>();
			while (begin < end)
			{
				result.Add(getDisponibility(day, begin));
				++begin;
			}
			return result;
		}

		public TimePeriod_DAL getDisponibility(DayOfWeek day, int hour)
		{
			var list = _periods.GetAll();
			foreach (var period in list)
			{
				if (period.Day == day && period.Hour == hour) return period;
			}
			_periods.addObject(new TimePeriod_DAL() { Day = day, Hour = hour });
			return getDisponibility(day, hour);
		}

		public void addTutor(int number, string lastName, string firstName, string mail, ICollection<TimePeriod_DAL> period)
		{
			_tutors.addObject(new TutorStudent_DAL()
			{
				Number = number,
				LastName = lastName,
				FirstName = firstName,
				Mail = mail,
				TimePeriod_DAL = period
			});
		}

		public void addHelpeds()
		{
			List<TimePeriod_DAL> dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Monday, 13, 14));
			dispo.AddRange(getDisponibilities(DayOfWeek.Wednesday, 12, 14));
			dispo.AddRange(getDisponibilities(DayOfWeek.Friday, 10, 12));
			addHelped(99911, "Roy", "Gary", "GR1@yopmail.com", dispo);
			dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Monday, 14, 15));
			dispo.AddRange(getDisponibilities(DayOfWeek.Thursday, 16, 17));
			addHelped(99922, "Gagnon", "Samuel", "SG1@yopmail.com", dispo);
			dispo = new List<TimePeriod_DAL>();
			dispo.AddRange(getDisponibilities(DayOfWeek.Wednesday, 12, 14));
			dispo.AddRange(getDisponibilities(DayOfWeek.Friday, 10, 16));
		}

		public void addHelped(int number, string lastName, string firstName, string mail, ICollection<TimePeriod_DAL> period)
		{
			_helpeds.addObject(new HelpedStudent_DAL()
			{
				Number = number,
				LastName = lastName,
				FirstName = firstName,
				Mail = mail,
				TimePeriod_DAL = period
			});
		}

		public void addSessions()
		{
			addSession(new DateTime(2016, 4, 27, 12, 0, 0), 11111, 99911);
			addSession(new DateTime(2016, 4, 27, 12, 0, 0), 33333, 99922);
			addSession(new DateTime(2016, 4, 28, 16, 0, 0), 55555, 99922);
			addSession(new DateTime(2016, 5, 2, 13, 0, 0), 11111, 99911);
			addSession(new DateTime(2016, 5, 4, 13, 0, 0), 33333, 99922);
			addSession(new DateTime(2016, 5, 9, 13, 0, 0), 11111, 99911);
			addSession(new DateTime(2016, 5, 11, 12, 0, 0), 22222, 99922);
		}

		public void addSession(DateTime date, int tutorNumber, int helpedNumber)
		{
			_sessions.addObject(new Session_DAL()
			{
				Date=date,
				HelpedStudent_DAL = _helpeds.GetAll().FirstOrDefault(helped=>helped.Number==helpedNumber),
				TutorStudent_DAL = _tutors.GetAll().FirstOrDefault(tutor => tutor.Number == tutorNumber)
			});
		}

		public void removeAll()
		{
			_sessions.removeAll();
			_periods.removeAll();
			_tutors.removeAll();
			_helpeds.removeAll();
		}
    }
}
