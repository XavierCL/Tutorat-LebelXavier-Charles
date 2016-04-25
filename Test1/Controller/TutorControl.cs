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
	class TutorControl
	{

		private TutoringView _view;
		private TutorStudentManager _manager;
		private IEnumerable<TutorVO> _objects;
		public TutorControl()
		{
			_manager = new TutorStudentManager();
			_objects = new List<TutorVO>();
		}

		public void ListAdd()
		{
			var tutors = _manager.getAll();
			var list = new List<TutorVO>();
			foreach (var tutor in tutors)
			{
				list.Add(new TutorVO()
				{
					_matricule=tutor.Numbre,
					_nom=tutor.LastName
				});
			}
			_objects = list;
		}

		public void PrintView()
		{
			_view = new TutoringView(_objects);
			_view.printView();
		}
	}
}
