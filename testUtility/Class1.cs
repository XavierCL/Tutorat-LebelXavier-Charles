using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.EntityFramework;
using classLibrary.Entities;
using classLibrary;

namespace testUtility
{
    public class TestDataSeeder
    {
		EFRepository<TutorStudent_DAL> _myRepo;
		public TestDataSeeder()
		{
			_myRepo = new EFRepository<TutorStudent_DAL>(new EFTutoringDBContext());
		}

		public void addSeeds()
		{
			TutorStudent_DAL t1 = new TutorStudent_DAL()
			{
				Number=144072,
				LastName="C17"
			};
			_myRepo.addTutor(t1);
			TutorStudent_DAL t2 = new TutorStudent_DAL()
			{
				Number = 1442344072,
				LastName = "Julw"
			};
			_myRepo.addTutor(t2);
			TutorStudent_DAL t3 = new TutorStudent_DAL()
			{
				Number = 72,
				LastName = "Julw"
			};
			_myRepo.addTutor(t3);
		}

		public void removeAll()
		{
			_myRepo.removeAll();
		}
    }
}
