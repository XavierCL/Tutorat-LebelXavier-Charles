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
		private IEnumerable<TutorVO> _tutorList;

		public TutoringView(IEnumerable<TutorVO> tutorList)
		{
			_tutorList = tutorList;
		}

		public void printView()
		{
			foreach (var tutor in _tutorList)
			{
				Console.Write("\nMatricule: " + tutor._matricule + "\nNom: " + tutor._nom + "\n");
			}
		}
	}
}
