using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.View;
using Test1.ViewObjects;
using DomainLayer;

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
				list.Add(new StudentVO()
				{
					_matricule=tutor.Number,
					_lastName=tutor.LastName,
					_firstName=tutor.FirstName,
					_mail=tutor.Mail
				});
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
					_student = new StudentVO()
					{
						_firstName = tutor.FirstName,
						_lastName = tutor.LastName,
						_mail = tutor.Mail,
						_matricule = tutor.Number
					}
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
						_helped = new StudentVO()
						{
							_firstName = session.Helped.FirstName,
							_lastName = session.Helped.LastName,
							_mail = session.Helped.Mail,
							_matricule = session.Helped.Number
						},
						_tutor = new StudentVO()
						{
							_firstName = session.Tutor.FirstName,
							_lastName = session.Tutor.LastName,
							_mail = session.Tutor.Mail,
							_matricule = session.Tutor.Number
						}
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
					_student = new StudentVO()
						{
							_firstName = period.Student.FirstName,
							_lastName = period.Student.LastName,
							_mail = period.Student.Mail,
							_matricule = period.Student.Number
						}
				});
			}
			var view = new Student2HoursView(studentObjects);
			view.printView();
		}

		public void PrintConcurentPeriods()
		{
			List<TutorHelpedPeriodVO> periodObjects = new List<TutorHelpedPeriodVO>();
			//var tutors = _serviceManager.getConcurentPeriods();
			var tutors = new List<TimePeriod>(_timeManager.getAllTutors());
			var helpeds = new List<TimePeriod>(_timeManager.getAllHelpeds());
			foreach(var tutor in tutors)
			{
				foreach (var helped in helpeds)
				{
					if (helped.equals(tutor))
					{
						periodObjects.Add(new TutorHelpedPeriodVO()
						{
							period = new TimePeriodVO()
							{
								Day = helped.Day,
								Hour = helped.Hour
							},
							helped = new StudentVO()
							{
								_firstName = helped.Student.FirstName,
								_lastName = helped.Student.LastName,
								_mail = helped.Student.Mail,
								_matricule = helped.Student.Number
							},
							tutor = new Student2HoursVO()
							{
								_hour1 = _sessionManager.getWorkedHours((TutorStudent)tutor.Student),
								_hour2 = _sessionManager.getFutureHours((TutorStudent)tutor.Student),
								_student = new StudentVO()
								{
									_firstName = tutor.Student.FirstName,
									_lastName = tutor.Student.LastName,
									_mail = tutor.Student.Mail,
									_matricule = tutor.Student.Number
								}
							}
						});
					}
				}
			}
			var view = new TutorHelpedPeriodView(periodObjects);
			view.printView();
		}
	}
}
