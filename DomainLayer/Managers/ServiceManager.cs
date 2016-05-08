using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
	public class ServiceManager
	{
		private TimePeriodManager _timeManager;
		public ServiceManager()
		{
			_timeManager = new TimePeriodManager();
		}

		public void setRepo(TimePeriodManager timeManager)
		{
			_timeManager=timeManager;
		}

		public ICollection<TimePeriod> getFreeTutorAtDate(List<DateTime> dates)
		{
			var periods = new List<TimePeriod>(_timeManager.getAllTutors());
			var index=0;
			while(index<periods.Count)
			{
				var index2 = 0;
				while (index2 < dates.Count)
				{
					if (periods[index].Day == dates[index2].DayOfWeek && periods[index].Hour == dates[index2].Hour)break;
					++index2;
				}
				if (index2 == dates.Count)periods.RemoveAt(index--);
				++index;
			}
			return periods;
		}

		public ICollection<SessionPeriod> getConcurentDates()
		{
			var sessions = new List<SessionPeriod>();
			var helpedPeriods = _timeManager.getAllHelpeds();
			var tutorPeriods = _timeManager.getAllTutors();
			foreach (var helpedPeriod in helpedPeriods)
			{
				if (helpedPeriod.Day == DayOfWeek.Wednesday)
				{
					helpedPeriod.Hour = helpedPeriod.Hour;
				}
				foreach (var tutorPeriod in tutorPeriods)
				{
					if (tutorPeriod.Day == DayOfWeek.Wednesday)
					{
						tutorPeriod.Hour = tutorPeriod.Hour;
					}
					if (helpedPeriod.equals(tutorPeriod))
					{
						sessions.Add(new SessionPeriod()
						{
							Date = tutorPeriod,
							Helped = (HelpedStudent)helpedPeriod.Student,
							Tutor = (TutorStudent)tutorPeriod.Student
						});
					}
				}
			}
			return sessions;
		}
	}
}
