using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.ViewObjects
{
	public class StudentHoursVO
	{
		public StudentVO _student { get; set; }
		public int _hour { get; set; }

		public string ToString()
		{
			return _student.ToString()+"Heures: "+_hour+'\n';
		}
	}
}
