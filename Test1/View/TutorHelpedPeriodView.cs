using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;

namespace Test1.View
{
	class TutorHelpedPeriodView
	{
		private IEnumerable<TutorHelpedPeriodVO> _periods;

		public TutorHelpedPeriodView(IEnumerable<TutorHelpedPeriodVO> periods)
		{
			_periods = periods;
		}

		public void printView()
		{
			foreach (var period in _periods)
			{
				Console.Write(period.ToString());
			}
		}
	}
}
