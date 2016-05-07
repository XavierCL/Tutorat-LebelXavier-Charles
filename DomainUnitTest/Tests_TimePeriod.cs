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
	public class Tests_TimePeriod
	{
		private TimePeriodManager _timeService;
		private RepositoryInterface<TimePeriod_DAL> _repo;

		[TestInitialize]
		public void Initializer()
		{
			_timeService = new TimePeriodManager();
			_repo = Substitute.For<RepositoryInterface<TimePeriod_DAL>>();
		}

		[TestMethod]
		public void timeServiceShouldCallRegisterRepoAndCallRightCountForHelpeds()
		{
			HelpedStudent t1 = new HelpedStudent()
			{
				Number = 144072,
				LastName = "C17"
			};
			TimePeriod p1 = new TimePeriod()
			{
				Day=DayOfWeek.Monday,
				Hour=3,
				Student=t1
			};

			_timeService.setRepo(_repo);
			_timeService.registerHelpedDisponibility(p1);

			Assert.AreEqual(_repo.ReceivedCalls().Count(), 1);
		}

		[TestMethod]
		public void timeServiceShouldCallRegisterRepoAndCallRightCountForTutors()
		{
			TutorStudent t1 = new TutorStudent()
			{
				Number = 144072,
				LastName = "C17"
			};
			TimePeriod p1 = new TimePeriod()
			{
				Day = DayOfWeek.Monday,
				Hour = 3,
				Student = t1
			};

			_timeService.setRepo(_repo);
			_timeService.registerTutorDisponibility(p1);

			Assert.AreEqual(_repo.ReceivedCalls().Count(), 1);
		}

		[TestMethod]
		public void timeServiceShouldCallGetAllRepoAndReturnRightCountForHelpeds()
		{
			HelpedStudent_DAL t1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day = DayOfWeek.Monday,
				Hour = 3,
				Student_DAL = t1
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DayOfWeek.Thursday,
				Hour = 2,
				Student_DAL = t1
			};
			TimePeriod_DAL p3 = new TimePeriod_DAL()
			{
				Day = DayOfWeek.Wednesday,
				Hour = 8,
				Student_DAL = t1
			};

			List<TimePeriod_DAL> periods = new List<TimePeriod_DAL>() { p1, p2, p3 };

			_repo.GetAll().Returns(periods.AsQueryable());
			_timeService.setRepo(_repo);
			var actualPeriods = _timeService.getAllHelpeds();

			Assert.IsTrue(actualPeriods.Count() == periods.Count);
		}

		[TestMethod]
		public void timeServiceShouldCallGetAllRepoAndReturnRightCountForTutors()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TimePeriod_DAL p1 = new TimePeriod_DAL()
			{
				Day = DayOfWeek.Monday,
				Hour = 3,
				Student_DAL = t1
			};
			TimePeriod_DAL p2 = new TimePeriod_DAL()
			{
				Day = DayOfWeek.Thursday,
				Hour = 2,
				Student_DAL = t1
			};
			TimePeriod_DAL p3 = new TimePeriod_DAL()
			{
				Day = DayOfWeek.Wednesday,
				Hour = 8,
				Student_DAL = t1
			};

			List<TimePeriod_DAL> periods = new List<TimePeriod_DAL>() { p1, p2, p3 };

			_repo.GetAll().Returns(periods.AsQueryable());
			_timeService.setRepo(_repo);
			var actualPeriods = _timeService.getAllTutors();

			Assert.IsTrue(actualPeriods.Count() == periods.Count);
		}
	}
}
