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
	public class UnitTest1
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
		public void TestMethod1()
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

			Assert.AreEqual(aList.Count(), 3);
		}
	}
}
