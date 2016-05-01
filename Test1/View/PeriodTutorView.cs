using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;

namespace Test1.View
{
	class PeriodTutorView
	{
		private IEnumerable<Student2HoursVO> _studentHours;

		public PeriodTutorView(IEnumerable<Student2HoursVO> studentHours)
		{
			_studentHours = studentHours;
		}

		public void printView()
		{
			foreach (var student in _studentHours)
			{
				Console.Write(student.ToString());
			}
		}
	}
}
