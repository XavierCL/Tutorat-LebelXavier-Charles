using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;

namespace Test1.View
{
	class TutoringView
	{
		private IEnumerable<StudentVO> _tutorList;

		public TutoringView(IEnumerable<StudentVO> tutorList)
		{
			_tutorList = tutorList;
		}

		public void printView()
		{
			foreach (var tutor in _tutorList)
			{
				Console.Write(tutor.ToString());
			}
		}
	}
}
