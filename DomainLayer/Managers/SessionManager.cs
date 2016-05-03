using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary;
using classLibrary.Entities;
using classLibrary.EntityFramework;
using DomainLayer.Mapping;

namespace DomainLayer
{
	public class SessionManager
	{
		private RepositoryInterface<Session_DAL> _sessionRepo;

		public SessionManager()
		{
			_sessionRepo = new EFRepository<Session_DAL>(new EFTutoringDBContext());
		}

		public void setRepo(RepositoryInterface<Session_DAL> sessionRepo)
		{
			_sessionRepo = sessionRepo;
		}

		public IQueryable<Session> getAll()
		{
			var list = new List<Session>();

			var listDal = _sessionRepo.GetAll();

			foreach (var session in listDal)
			{
				list.Add(DalMapper.dalToSession(session));
			}
			return list.AsQueryable();
		}

		public int getWorkedHours(TutorStudent tutor)
		{
			List<Session> sessions = new List<Session>(getAll().Where(t => t.Tutor.Number == tutor.Number));
			int index = 0;
			while (index < sessions.Count)
			{
				if (sessions[index].Date > DateTime.Now) sessions.RemoveAt(index--);
				++index;
			}
			return sessions.Count;
		}

		public int getFutureHours(TutorStudent tutor)
		{
			List<Session> sessions = new List<Session>(getAll().Where(t => t.Tutor.Number == tutor.Number));
			int index = 0;
			while (index < sessions.Count)
			{
				if (sessions[index].Date < DateTime.Now) sessions.RemoveAt(index--);
				++index;
			}
			return sessions.Count;
		}

		public IEnumerable<Session> getFutureSessions()
		{
			List<Session> sessions = new List<Session>(getAll());
			int index = 0;
			while (index < sessions.Count)
			{
				if (sessions[index].Date < DateTime.Now) sessions.RemoveAt(index--);
				++index;
			}
			return sessions;
		}
	}
}
