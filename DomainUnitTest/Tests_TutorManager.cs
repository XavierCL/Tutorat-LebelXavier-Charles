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
	public class Tests_TutorManager
	{
		private TutorStudentManager _tutorService;
		private RepositoryInterface<TutorStudent_DAL> _repo;

		[TestInitialize]
		public void Initializer()
		{
			_tutorService = new TutorStudentManager();
			_repo = Substitute.For<RepositoryInterface<TutorStudent_DAL>>();
		}

		[TestMethod]
		public void tutorServiceShouldCallGetAllRepoAndReturnRightCount()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 1442344072,
				LastName = "Julw"
			};
			TutorStudent_DAL t3 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			var aList = new List<TutorStudent_DAL>() { t1, t2, t3 };


			_repo.GetAll().Returns(aList.AsQueryable());
			_tutorService.setRepo(_repo);

			Assert.AreEqual(_tutorService.getAll().Count(), aList.Count);
		}

		[TestMethod]
		public void registerTutorServiceShouldReturnRightNumbers()
		{
			TutorStudent t1 = new TutorStudent()
			{
				Number = 144072,
				LastName = "C17"
			};
			_tutorService.setRepo(_repo);
			_tutorService.registerTutor(t1);

			Assert.IsTrue(_repo.ReceivedCalls().Count()==1);
		}

		[TestMethod]
		public void updateTutorServiceShouldReturnRightNumbers()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number = 144072,
				LastName = "C17"
			};

			TutorStudent t2 = new TutorStudent()
			{
				Number = 144072,
				LastName = "C18"
			};
			_repo.GetAll().Returns(new List<TutorStudent_DAL>(){t1}.AsQueryable());
			_tutorService.setRepo(_repo);
			_tutorService.updateTutor(t2);

			Assert.IsTrue(_repo.ReceivedCalls().Count() == 2);
		}
	}
}
