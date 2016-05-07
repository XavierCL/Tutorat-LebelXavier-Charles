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
	public class Tests_ServiceManager
	{
		private ServiceManager _serviceManager;
		private RepositoryInterface<TimePeriod_DAL> _repo;

		[TestInitialize]
		public void Initializer()
		{
			_serviceManager = new ServiceManager();
			_repo = Substitute.For<RepositoryInterface<TimePeriod_DAL>>();
		}

		[TestMethod]
		public void serviceManagerShouldReturnRightCountWhenQueryingFreeTutors()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day=DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL=t1
			};
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 7422,
				LastName = "Jufawflw"
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t1
			};
			
			var aList = new List<TimePeriod_DAL>() { p1,p2 };
			_repo.GetAll().Returns(aList.AsQueryable());
			TimePeriodManager timeManager = new TimePeriodManager();
			timeManager.setRepo(_repo);
			_serviceManager.setRepo(timeManager);
			var actualList = _serviceManager.getFreeTutorAtDate(new List<DateTime>() { DateTime.Now });

			Assert.AreEqual(actualList.Count(), aList.Count);
		}

		[TestMethod]
		public void serviceManagerShouldReturnRightCountWhenQueryingFreeTutorsAtWrongDay()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.AddDays(1).DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t1
			};
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 7422,
				LastName = "Jufawflw"
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t1
			};

			var aList = new List<TimePeriod_DAL>() { p1, p2 };
			_repo.GetAll().Returns(aList.AsQueryable());
			TimePeriodManager timeManager = new TimePeriodManager();
			timeManager.setRepo(_repo);
			_serviceManager.setRepo(timeManager);
			var actualList = _serviceManager.getFreeTutorAtDate(new List<DateTime>() { DateTime.Now });

			Assert.AreEqual(actualList.Count(), aList.Count-1);
		}

		[TestMethod]
		public void serviceManagerShouldReturnRightCountWhenQueryingFreeTutorsAtWrongHour()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.AddHours(1).Hour,
				Student_DAL = t1
			};
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 7422,
				LastName = "Jufawflw"
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t1
			};

			var aList = new List<TimePeriod_DAL>() { p1, p2 };
			_repo.GetAll().Returns(aList.AsQueryable());
			TimePeriodManager timeManager = new TimePeriodManager();
			timeManager.setRepo(_repo);
			_serviceManager.setRepo(timeManager);
			var actualList = _serviceManager.getFreeTutorAtDate(new List<DateTime>() { DateTime.Now });

			Assert.AreEqual(actualList.Count(), aList.Count - 1);
		}

		[TestMethod]
		public void serviceManagerShouldReturnRightConcurentSessionsWithSamePeriods()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t1
			};
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 7422,
				LastName = "Jufawflw"
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = h1
			};

			var aList = new List<TimePeriod_DAL>() { p1, p2 };
			_repo.GetAll().Returns(aList.AsQueryable());
			TimePeriodManager timeManager = new TimePeriodManager();
			timeManager.setRepo(_repo);
			_serviceManager.setRepo(timeManager);
			var actualList = _serviceManager.getConcurentDates();

			Assert.AreEqual(actualList.Count(), 1);
		}

		[TestMethod]
		public void serviceManagerShouldReturnRightConcurentSessionsWithDifferentPeriods()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t1
			};
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 1272,
				LastName = "Ju9((lw"
			};
			TimePeriod_DAL p4 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = t2
			};
			HelpedStudent_DAL h1 = new HelpedStudent_DAL()
			{
				Number = 7422,
				LastName = "Jufawflw"
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = h1
			};
			HelpedStudent_DAL h2 = new HelpedStudent_DAL()
			{
				Number = 7422,
				LastName = "Jufawflw"
			};
			TimePeriod_DAL p3 = new TimePeriod_DAL()
			{
				Day = DateTime.Now.AddDays(1).DayOfWeek,
				Hour = DateTime.Now.Hour,
				Student_DAL = h2
			};

			var aList = new List<TimePeriod_DAL>() { p1, p2, p3, p4 };
			_repo.GetAll().Returns(aList.AsQueryable());
			TimePeriodManager timeManager = new TimePeriodManager();
			timeManager.setRepo(_repo);
			_serviceManager.setRepo(timeManager);
			var actualList = _serviceManager.getConcurentDates();

			Assert.AreEqual(actualList.Count(), 2);
		}
	}
}
