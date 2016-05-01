using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary;
using classLibrary.Entities;
using classLibrary.EntityFramework;

namespace DomainLayer
{
	public class SessionManager
	{
		private RepositoryInterface<Session_DAL> _sessionRepo;

		public SessionManager()
		{
			_sessionRepo = new EFRepository<Session_DAL>(new EFTutoringDBContext());
		}

		public IQueryable<Session> getAll()
		{
			var list = new List<Session>();

			var listDal = _sessionRepo.GetAll();

			foreach (var session in listDal)
			{
				list.Add(
					new Session()
					{
						Date=session.Date,
						Helped=new HelpedStudent()
						{
							FirstName=session.HelpedStudent_DAL.FirstName,
							LastName=session.HelpedStudent_DAL.LastName,
							Mail=session.HelpedStudent_DAL.Mail,
							Number=session.HelpedStudent_DAL.Number
						},
						Tutor = new TutorStudent()
						{
							FirstName = session.TutorStudent_DAL.FirstName,
							LastName = session.TutorStudent_DAL.LastName,
							Mail = session.TutorStudent_DAL.Mail,
							Number = session.TutorStudent_DAL.Number
						}
					}
				);
			}

			return list.AsQueryable();

		}
	}
}
