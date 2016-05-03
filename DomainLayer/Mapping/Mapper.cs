using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.Entities;

namespace DomainLayer.Mapping
{
	public class DalMapper
	{
		public static TutorStudent dalToTutor(TutorStudent_DAL tutor)
		{
			return new TutorStudent()
			{
				FirstName=tutor.FirstName,
				LastName=tutor.LastName,
				Mail=tutor.Mail,
				Number=tutor.Number
			};
		}
		public static TutorStudent_DAL tutorToDal(TutorStudent tutor)
		{
			return new TutorStudent_DAL()
			{
				FirstName = tutor.FirstName,
				LastName = tutor.LastName,
				Mail = tutor.Mail,
				Number = tutor.Number
			};
		}

		public static HelpedStudent dalToHelped(HelpedStudent_DAL helped)
		{
			return new HelpedStudent()
			{
				FirstName = helped.FirstName,
				LastName = helped.LastName,
				Mail = helped.Mail,
				Number = helped.Number
			};
		}

		public static HelpedStudent_DAL helpedToDal(HelpedStudent helped)
		{
			return new HelpedStudent_DAL()
			{
				FirstName = helped.FirstName,
				LastName = helped.LastName,
				Mail = helped.Mail,
				Number = helped.Number
			};
		}

		public static TimePeriod dalToTutorPeriod(TimePeriod_DAL period)
		{
			return new TimePeriod()
			{
				Day = period.Day,
				Hour = period.Hour,
				Student = dalToTutor((TutorStudent_DAL)period.Student_DAL)
			};
		}

		public static TimePeriod_DAL tutorPeriodToDal(TimePeriod period)
		{
			return new TimePeriod_DAL()
			{
				Day = period.Day,
				Hour = period.Hour,
				Student_DAL = tutorToDal((TutorStudent)period.Student)
			};
		}

		public static TimePeriod dalToHelpedPeriod(TimePeriod_DAL period)
		{
			return new TimePeriod()
			{
				Day = period.Day,
				Hour = period.Hour,
				Student = dalToHelped((HelpedStudent_DAL)period.Student_DAL)
			};
		}

		public static TimePeriod_DAL helpedPeriodToDal(TimePeriod period)
		{
			return new TimePeriod_DAL()
			{
				Day = period.Day,
				Hour = period.Hour,
				Student_DAL = helpedToDal((HelpedStudent)period.Student)
			};
		}

		public static Session dalToSession(Session_DAL session)
		{
			return new Session()
			{
				Date = session.Date,
				Helped = dalToHelped(session.HelpedStudent_DAL),
				Tutor = dalToTutor(session.TutorStudent_DAL)
			};
		}

		public static Session_DAL sessionToDal(Session session)
		{
			return new Session_DAL()
			{
				Date = session.Date,
				HelpedStudent_DAL = helpedToDal(session.Helped),
				TutorStudent_DAL = tutorToDal(session.Tutor)
			};
		}
	}
}
