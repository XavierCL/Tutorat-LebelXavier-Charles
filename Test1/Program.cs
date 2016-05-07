using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.EntityFramework;
using classLibrary.Entities;
using testUtility;
using Test1.Controller;
using classLibrary;
using DomainLayer;

namespace Test1
{
	class Program
	{
		static void Main(string[] args)
		{
			//EFTutoringDBContext context = new EFTutoringDBContext();
			TestDataSeeder testSeeder = new TestDataSeeder();
			testSeeder.removeAll();
			testSeeder.addSeeds();
			TutorControl tutorControl = new TutorControl();
			var tutors=testSeeder.getAll();
			foreach (var tutor in tutors)
			{
				Console.Write(tutor.FirstName+'\n');
				foreach (var session in tutor.Session_DAL)
				{
					Console.Write(session.Date.Day);
					Console.Write(session.TutorStudent_DAL.FirstName);
				}
			}
			/*tutorControl.PrintFutureSessions();
			HelpedControl helpedControl = new HelpedControl();*/
			Console.Write("\nOK!");
			Console.ReadKey();
		}

		static void printTutor(TutorStudent_DAL tutor)
		{
			Console.Write("\nID: " + tutor.Id + "\nname: " + tutor.LastName + "\nnumber: " + tutor.Number);
		}
	}
}
