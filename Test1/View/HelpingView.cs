using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;

namespace Test1.View
{
	class HelpingView
	{
		private IEnumerable<StudentVO> _helpedList;

		public HelpingView(IEnumerable<StudentVO> helpedList)
		{
			_helpedList = helpedList;
		}

		public void printView()
		{
			foreach (var helped in _helpedList)
			{
				Console.Write(helped.ToString());
			}
		}
	}
}
