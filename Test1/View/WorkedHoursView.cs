using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;

namespace Test1.View
{
	class WorkedHoursView
	{
		private IEnumerable<StudentHoursVO> _studentHours;

		public WorkedHoursView(IEnumerable<StudentHoursVO> studentHours)
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
