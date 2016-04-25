using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class TutorStudent
    {
		public int Id { get; set; }
		public int Numbre { get; set; }
		public string LastName { get; set; }

		public int GetTutoringHours()
		{
			return 0;
		}
    }
}
