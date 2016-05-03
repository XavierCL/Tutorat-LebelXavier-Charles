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
	public class Tests_POCO
	{

		[TestInitialize]
		public void Initializer()
		{
		}
		
		[TestMethod]
		public void timePeriodsShouldEqualIndependentlyOfStudent()
		{
			TimePeriod period1 = new TimePeriod()
			{
				Day = DayOfWeek.Monday,
				Hour = 3,
				Student=new TutorStudent()
				{
					Number=1
				}
			};
			TimePeriod period2 = new TimePeriod()
			{
				Day = DayOfWeek.Monday,
				Hour = 3,
				Student = new HelpedStudent()
				{
					Number = 2
				}
			};
			Assert.IsTrue(period1.equals(period2));
		}

		[TestMethod]
		public void timePeriodsShouldNotEqualWhenDayOfWeekDiffers()
		{
			TimePeriod period1 = new TimePeriod()
			{
				Day = DayOfWeek.Wednesday,
				Hour = 3
			};
			TimePeriod period2 = new TimePeriod()
			{
				Day = DayOfWeek.Monday,
				Hour = 3
			};
			Assert.IsFalse(period1.equals(period2));
		}

		[TestMethod]
		public void timePeriodsShouldNotEqualWhenHourDiffers()
		{
			TimePeriod period1 = new TimePeriod()
			{
				Day = DayOfWeek.Monday,
				Hour = 4
			};
			TimePeriod period2 = new TimePeriod()
			{
				Day = DayOfWeek.Monday,
				Hour = 3
			};
			Assert.IsFalse(period1.equals(period2));
		}
	}
}
