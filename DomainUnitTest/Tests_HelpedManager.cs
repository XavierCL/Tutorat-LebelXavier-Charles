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
	public class Tests_HelpedManager
	{
		private HelpedStudentManager _helpedService;
		private RepositoryInterface<HelpedStudent_DAL> _repo;

		[TestInitialize]
		public void Initializer()
		{
			_helpedService = new HelpedStudentManager();
			_repo = Substitute.For<RepositoryInterface<HelpedStudent_DAL>>();
		}

		[TestMethod]
		public void helpedServiceShouldCallGetAllRepoAndReturnRightCount()
		{
			HelpedStudent_DAL t1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			HelpedStudent_DAL t2 = new HelpedStudent_DAL()
			{
				Number = 1442344072,
				LastName = "Julw"
			};
			HelpedStudent_DAL t3 = new HelpedStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			var aList = new List<HelpedStudent_DAL>() { t1, t2, t3 };


			_repo.GetAll().Returns(aList.AsQueryable());
			_helpedService.setRepo(_repo);

			Assert.AreEqual(_helpedService.getAll().Count(), aList.Count);
		}

		[TestMethod]
		public void registerTutorServiceShouldReturnRightNumbers()
		{
			HelpedStudent t1 = new HelpedStudent()
			{
				Number = 144072,
				LastName = "C17"
			};
			_helpedService.setRepo(_repo);
			_helpedService.registerHelped(t1);

			Assert.IsTrue(_repo.ReceivedCalls().Count()==1);
		}

		[TestMethod]
		public void updateTutorServiceShouldReturnRightNumbers()
		{
			HelpedStudent_DAL t1 = new HelpedStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};

			HelpedStudent t2 = new HelpedStudent()
			{
				Number = 144072,
				LastName = "C18"
			};
			_repo.GetAll().Returns(new List<HelpedStudent_DAL>(){t1}.AsQueryable());
			_helpedService.setRepo(_repo);
			_helpedService.updateHelped(t2);

			Assert.IsTrue(_repo.ReceivedCalls().Count() == 2);
		}
	}
}
