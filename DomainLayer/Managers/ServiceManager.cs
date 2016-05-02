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
		private SessionManager _sessionManager;
		private TutorStudentManager _tutorManager;
		public ServiceManager()
		{
			_timeManager = new TimePeriodManager();
			_sessionManager = new SessionManager();
			_tutorManager = new TutorStudentManager();
		}

		public ICollection<TimePeriod> getFreeTutorAtDate(List<DateTime> dates)
		{
			var periods = new List<TimePeriod>(_timeManager.getAllTutors());
			var index=0;
			while(index<periods.Count)
			{
				var index2 = 0;
				while (index < dates.Count)
				{
					if (periods[index].Day == dates[index2].DayOfWeek && periods[index].Hour == dates[index2].Hour)break;
					++index2;
				}
				if (index2 == dates.Count)periods.RemoveAt(index--);
				++index;
			}
			return periods;
		}
	}
}
