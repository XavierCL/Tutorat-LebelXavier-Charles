using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.View;
using Test1.ViewObjects;
using DomainLayer;
using Test1.Mapping;

namespace Test1.Controller
{
	class TutorControl
	{
		private TutorStudentManager _tutorManager;
		private TimePeriodManager _timeManager;
		private SessionManager _sessionManager;
		private ServiceManager _serviceManager;
		public TutorControl()
		{
			_tutorManager = new TutorStudentManager();
			_timeManager = new TimePeriodManager();
			_sessionManager = new SessionManager();
			_serviceManager = new ServiceManager();
		}

		public void addTutor(TimePeriod time)
		{
			_timeManager.registerTutorDisponibility(time);
		}

		public void addTutor(TutorStudent tutor)
		{
			_tutorManager.registerTutor(tutor);
		}

		public void printTutors()
		{
			var tutors = _tutorManager.getAll();
			var list = new List<StudentVO>();
			foreach (var tutor in tutors)
			{
				list.Add(VOMapper.studentToVO(tutor));
			}
			var view = new TutoringView(list);
			view.printView(); ;
		}

		public void UpdateTutor(TutorStudent tutor)
		{
			_tutorManager.updateTutor(tutor);
		}

		public void PrintTutorsByWorkedTime()
		{
			var tutors = _tutorManager.getAll();
			var tutorObjects = new List<StudentHoursVO>();
			foreach (var tutor in tutors)
			{
				tutorObjects.Add(new StudentHoursVO()
				{
					_hour=_sessionManager.getWorkedHours(tutor),
					_student = VOMapper.studentToVO(tutor)
				});
			}
			var view = new WorkedHoursView(tutorObjects);
			view.printView();
		}

		public void PrintFutureSessions()
		{
			IEnumerable<Session> sessions = _sessionManager.getFutureSessions();
			var sessionObjects = new List<SessionVO>();
			foreach (var session in sessions)
			{
				sessionObjects.Add(
					new SessionVO()
					{
						_date = session.Date,
						_helped = VOMapper.studentToVO(session.Helped),
						_tutor = VOMapper.studentToVO(session.Tutor)
					}
				);
			}
			var view = new SessionView(sessionObjects);
			view.printView();
		}

		public void PrintSelectedPeriodTutors(List<DateTime> dates)
		{
			var periods = _serviceManager.getFreeTutorAtDate(dates);
			List<Student2HoursVO> studentObjects = new List<Student2HoursVO>();
			foreach(var period in periods)
			{
				studentObjects.Add(new Student2HoursVO()
				{
					_hour1 = _sessionManager.getWorkedHours((TutorStudent)period.Student),
					_hour2 = _sessionManager.getFutureHours((TutorStudent)period.Student),
					_student = VOMapper.studentToVO(period.Student)
				});
			}
			var view = new Student2HoursView(studentObjects);
			view.printView();
		}

		public void PrintConcurentPeriods()
		{
			var periodObjects = new List<TutorHelpedPeriodVO>();
			var sessionPeriods = _serviceManager.getConcurentDates();
			foreach (var sessionPeriod in sessionPeriods)
			{
				periodObjects.Add(new TutorHelpedPeriodVO()
				{
					period = new TimePeriodVO()
					{
						Day = sessionPeriod.Date.Day,
						Hour = sessionPeriod.Date.Hour
					},
					helped = VOMapper.studentToVO(sessionPeriod.Helped),
					tutor = new Student2HoursVO()
					{
						_hour1 = _sessionManager.getWorkedHours(sessionPeriod.Tutor),
						_hour2 = _sessionManager.getFutureHours(sessionPeriod.Tutor),
						_student = VOMapper.studentToVO(sessionPeriod.Tutor)
					}
				});
			}
			var view = new TutorHelpedPeriodView(periodObjects);
			view.printView();
		}
	}
}
