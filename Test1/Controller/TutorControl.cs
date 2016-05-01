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
		public TutorControl()
		{
			_tutorManager = new TutorStudentManager();
			_timeManager = new TimePeriodManager();
			_sessionManager = new SessionManager();
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

		public int getWorkedHours(TutorStudent tutor)
		{
			List<Session> sessions = new List<Session>(_sessionManager.getAll().Where(t=>t.Tutor.Number==tutor.Number));
			int index = 0;
			while (index < sessions.Count)
			{
				if (sessions[index].Date > DateTime.Now) sessions.RemoveAt(index--);
				++index;
			}
			return sessions.Count;
		}

		public int getFutureHours(TutorStudent tutor)
		{
			List<Session> sessions = new List<Session>(_sessionManager.getAll().Where(t => t.Tutor.Number == tutor.Number));
			int index = 0;
			while (index < sessions.Count)
			{
				if (sessions[index].Date < DateTime.Now) sessions.RemoveAt(index--);
				++index;
			}
			return sessions.Count;
		}

		public void PrintTutorsByWorkedTime()
		{
			var tutors = new List<TutorStudent>(_tutorManager.getAll());
			var tutorObjects = new List<StudentHoursVO>();
			foreach (var tutor in tutors)
			{
				tutorObjects.Add(new StudentHoursVO()
				{
					_hour=getWorkedHours(tutor),
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
			List<Session> sessions = new List<Session>(_sessionManager.getAll());
			int index = 0;
			while (index < sessions.Count)
			{
				if (sessions[index].Date < DateTime.Now) sessions.RemoveAt(index--);
				++index;
			}
			var listedSessions = new List<Session>();
			var sessionObjects = new List<SessionVO>();
			foreach (var session in sessions)
			{
				index = 0;
				while (index < listedSessions.Count)
				{
					if (listedSessions[index].equals(session)) break;
					++index;
				}
				if (index == listedSessions.Count)
				{
					listedSessions.Add(session);
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
			}
			var view = new SessionView(sessionObjects);
			view.printView();
		}

		public void PrintSelectedPeriodTutors(List<DateTime> dates)
		{
			List<Student2HoursVO> studentObjects = new List<Student2HoursVO>();
			var tutors = new List<TutorStudent>(_tutorManager.getAll());
			foreach (var tutor in tutors)
			{
				var periods =new List<TimePeriod>( _timeManager.getAllTutors().Where(p => p.Student.Number == tutor.Number));
				int index = 0;
				int index2;
				while (index < periods.Count)
				{
					index2=0;
					while(index2<dates.Count)
					{
						if(periods[index].Day==dates[index2].DayOfWeek && periods[index].Hour == dates[index].Hour)break;
						++index2;
					}
					if(index2!=dates.Count)break;
					++index;
				}
				if(index!=periods.Count)
				{
					studentObjects.Add(new Student2HoursVO()
					{
						_hour1 = getWorkedHours(tutor),
						_hour2 = getFutureHours(tutor),
						_student = new StudentVO()
							{
								_firstName = tutor.FirstName,
								_lastName = tutor.LastName,
								_mail = tutor.Mail,
								_matricule = tutor.Number
							}
					});
				}
			}
			var view = new Student2HoursView(studentObjects);
			view.printView();
		}

		public void PrintConcurentPeriods()
		{
			List<TutorHelpedPeriodVO> periodObjects = new List<TutorHelpedPeriodVO>();
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
								_hour1 = getWorkedHours((TutorStudent)tutor.Student),
								_hour2 = getFutureHours((TutorStudent)tutor.Student),
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
