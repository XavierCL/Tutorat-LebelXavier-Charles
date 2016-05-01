using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.ViewObjects
{
	public class SessionVO
	{
		public DateTime _date { get; set; }
		public StudentVO _helped { get; set; }
		public StudentVO _tutor { get; set; }

		public override string ToString()
		{
			return "Date: " + _date.ToString() + "\nTutor: " + _tutor + "\nHelped: " + _helped.ToString() + '\n';
		}
	}
}
