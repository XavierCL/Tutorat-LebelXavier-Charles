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

		public void addTutors()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number=144072,
				LastName="C17"
			};
			_tutors.addTutor(t1);
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 1442344072,
				LastName = "Julw"
			};
			_tutors.addTutor(t2);
			TutorStudent_DAL t3 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			_tutors.addTutor(t3);
		}

		public void addTutor(int number, string lastName, string firstName, string mail, IEnumerable<TimePeriod_DAL> period)
		{
			_tutors.addObject(new TutorStudent_DAL(){
				Number=number,
				LastName=lastName,
				FirstName=firstName,
				Mail=mail,
				Period=period
			});
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
