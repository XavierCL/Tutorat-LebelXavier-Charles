using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classLibrary.Entities;

namespace classLibrary
{
	public interface RepositoryInterface<_ty> where _ty : Entity_DAL
	{
		IQueryable<_ty> GetAll();

		_ty getById(int id);

		void removeById(int id);

		void removeAll();

		void update(_ty tutor);

		void addTutor(_ty tutor);
	}
}
