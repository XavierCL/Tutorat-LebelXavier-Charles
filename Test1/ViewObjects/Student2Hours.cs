using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.ViewObjects
{
	public class Student2HoursVO
	{
		public StudentVO _student { get; set; }
		public int _hour1 { get; set; }
		public int _hour2 { get; set; }

		public string ToString()
		{
			return _student.ToString() + "Heures Travaillées: " + _hour1 + "Heures Prévues: " + _hour2 + '\n';
		}
	}
}
