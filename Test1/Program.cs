using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.EntityFramework;
using classLibrary.Entities;
using testUtility;
using Test1.Controller;

namespace Test1
{
	class Program
	{
		static void Main(string[] args)
		{
			EFRepository<TutorStudent_DAL> myRepo = new EFRepository<TutorStudent_DAL>(new EFTutoringDBContext());
			TestDataSeeder testSeeder = new TestDataSeeder();
			testSeeder.removeAll();
			testSeeder.addSeeds();

			TutorControl controller = new TutorControl();
			controller.ListAdd();
			controller.PrintView();

			/*var tutorList = myRepo.GetAll();
			foreach (var tutor in tutorList)
			{
				printTutor(tutor);
			}
			Console.ReadKey();
			testSeeder.removeAll();
			tutorList = myRepo.GetAll();
			Console.Write("\nListe totor>");
			foreach (var tutor in tutorList)
			{
				printTutor(tutor);
			}
			Console.Write("^Liste totor");
			Console.ReadKey();*/

			/*myRepo.removeAll();
			TutorStudent_DAL aStudent1 = new TutorStudent_DAL()
			{
				Number=144072,
				LastName="C17"
			};

			TutorStudent_DAL aStudent2 = new TutorStudent_DAL()
			{
				Number = 123,
				LastName = "Alex"
			};
			
			myRepo.addTutor(aStudent1);
			myRepo.addTutor(aStudent2);
			var tutorList = myRepo.GetAll();
			foreach (var tutor in tutorList)
			{
				printTutor(tutor);
			}
			Console.ReadKey();
			myRepo.removeById(aStudent1.Id);
			tutorList = myRepo.GetAll();
			foreach (var tutor in tutorList)
			{
				printTutor(tutor);
			}
			Console.ReadKey();
			aStudent2.LastName = "Reb";
			myRepo.update(aStudent2);
			tutorList = myRepo.GetAll();
			foreach (var tutor in tutorList)
			{
				printTutor(tutor);
			}
			Console.ReadKey();
			myRepo.addTutor(aStudent1);
			printTutor(myRepo.getById(aStudent1.Id));*/
			Console.ReadKey();
		}

		static void printTutor(TutorStudent_DAL tutor)
		{
			Console.Write("\nID: " + tutor.Id + "\nname: " + tutor.LastName + "\nnumber: " + tutor.Number);
		}
	}
}
