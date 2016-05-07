using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLayer;
using classLibrary;
using classLibrary.Entities;
using NSubstitute;
using System.Linq;
using System.Collections.Generic;

namespace DomainUnitTest
{
	[TestClass]
	public class Tests_SessionManager
	{
		private SessionManager _sessionService;
		private RepositoryInterface<Session_DAL> _repo;

		[TestInitialize]
		public void Initializer()
		{
			_sessionService = new SessionManager();
			_repo = Substitute.For<RepositoryInterface<Session_DAL>>();
		}

		[TestMethod]
		public void sessionServiceShouldCallGetAllRepoAndReturnRightCount()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 71242,
				LastName = "Juldww"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t2
			};
			var aList = new List<Session_DAL>() { s1, s2 };


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);

			Assert.AreEqual(_sessionService.getAll().Count(), aList.Count);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateHoursWhenBefore()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date=DateTime.Now.AddDays(-1),
				HelpedStudent_DAL=h1,
				TutorStudent_DAL=t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t1
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			TutorStudent t2 = new TutorStudent()
			{
				Number = 72,
				LastName = "Julw"
			};


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			int amountHours = _sessionService.getWorkedHours(t2);

			Assert.AreEqual(amountHours, aList.Count);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateHoursWhenAfter()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t1
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			TutorStudent t2 = new TutorStudent()
			{
				Number = 72,
				LastName = "Julw"
			};


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			int amountHours = _sessionService.getWorkedHours(t2);

			Assert.AreEqual(amountHours, aList.Count-1);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateHoursWhenNumberDiffers()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			TutorStudent_DAL t11 = new TutorStudent_DAL()
			{
				Number = 73,
				LastName = "Julw"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t11
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			TutorStudent t2 = new TutorStudent()
			{
				Number = 72,
				LastName = "Julw"
			};


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			int amountHours = _sessionService.getWorkedHours(t2);

			Assert.AreEqual(amountHours, aList.Count - 1);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateFutureHoursWhenBefore()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t1
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			TutorStudent t2 = new TutorStudent()
			{
				Number = 72,
				LastName = "Julw"
			};


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			int amountHours = _sessionService.getFutureHours(t2);

			Assert.AreEqual(amountHours, aList.Count);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateFutureHoursWhenAfter()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t1
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			TutorStudent t2 = new TutorStudent()
			{
				Number = 72,
				LastName = "Julw"
			};


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			int amountHours = _sessionService.getFutureHours(t2);

			Assert.AreEqual(amountHours, aList.Count - 1);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateFutureHoursWhenNumberDiffers()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			TutorStudent_DAL t11 = new TutorStudent_DAL()
			{
				Number = 73,
				LastName = "Julw"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t11
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			TutorStudent t2 = new TutorStudent()
			{
				Number = 72,
				LastName = "Julw"
			};


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			int amountHours = _sessionService.getFutureHours(t2);

			Assert.AreEqual(amountHours, aList.Count - 1);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateFutureSessionsWhenBefore()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t1
			};
			var aList = new List<Session_DAL>() { s1, s2 };


			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			var actualList = _sessionService.getFutureSessions();

			Assert.AreEqual(actualList.Count(), aList.Count);
		}

		[TestMethod]
		public void sessionServiceShouldReturnAppropriateFutureSessionsWhenAfter()
		{
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			Session_DAL s1 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(1),
				HelpedStudent_DAL = h1,
				TutorStudent_DAL = t1
			};

			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 1440,
				LastName = "C1d27"
			};
			Session_DAL s2 = new Session_DAL()
			{
				Date = DateTime.Now.AddDays(-1),
				HelpedStudent_DAL = h2,
				TutorStudent_DAL = t1
			};
			var aList = new List<Session_DAL>() { s1, s2 };

			_repo.GetAll().Returns(aList.AsQueryable());
			_sessionService.setRepo(_repo);
			var actualList = _sessionService.getFutureSessions();

			Assert.AreEqual(actualList.Count(), aList.Count-1);
		}
	}
}
