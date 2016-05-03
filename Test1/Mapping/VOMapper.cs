using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;
using DomainLayer;

namespace Test1.Mapping
{
	public class VOMapper
	{
		public static StudentVO studentToVO(Student student)
		{
			return new StudentVO()
			{
				_firstName=student.FirstName,
				_lastName=student.LastName,
				_mail=student.Mail,
				_matricule=student.Number
			};
		}
	}
}
