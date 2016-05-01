using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1.View;
using Test1.ViewObjects;
using DomainLayer;

namespace Test1.Controller
{
	class HelpedControl
	{
		private HelpedStudentManager _helpedManager;
		private TimePeriodManager _timeManager;
		public HelpedControl()
		{
			_helpedManager = new HelpedStudentManager();
			_timeManager = new TimePeriodManager();
		}

		public void addHelped(TimePeriod time)
		{
			_timeManager.registerHelpedDisponibility(time);
		}

		public void AddHelpeds()
		{
			var helpeds = _helpedManager.getAll();
			var list = new List<StudentVO>();
			foreach (var helped in helpeds)
			{
				list.Add(new StudentVO()
				{
					_matricule = helped.Number,
					_lastName = helped.LastName,
					_firstName = helped.FirstName,
					_mail = helped.Mail
				});
			}
			var view = new HelpingView(list);
			view.printView();
		}

		public void updateHelped(HelpedStudent helped)
		{
			_helpedManager.updateHelped(helped);
		}
	}
}
