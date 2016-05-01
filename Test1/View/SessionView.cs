using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.ViewObjects;

namespace Test1.View
{
	class SessionView
	{
		private IEnumerable<SessionVO> _sessions;

		public SessionView(IEnumerable<SessionVO> sessions)
		{
			_sessions = sessions;
		}

		public void printView()
		{
			foreach (var session in _sessions)
			{
				Console.Write(session.ToString());
			}
		}
	}
}
