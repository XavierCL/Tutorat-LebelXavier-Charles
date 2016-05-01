using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.ViewObjects
{
	public class StudentVO
	{
		public int _matricule { get; set; }
		public string _lastName { get; set; }
		public string _firstName { get; set; }
		public string _mail { get; set; }

		public override string ToString()
		{
			return "\nMatricule: " + _matricule + "\nNom: " + _lastName + "\nPrenom: "+_firstName+"\nCourriel: "+_mail+'\n';
		}
	}
}
