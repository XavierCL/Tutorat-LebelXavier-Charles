using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using classLibrary.Entities;
using classLibrary;

namespace classLibrary.EntityFramework
{
	public class EFRepository<_ty>:RepositoryInterface<_ty> where _ty:Entity_DAL
	{
		private readonly DbContext _context;

		public EFRepository(DbContext context)
		{
			_context = context;
		}

		public IQueryable<_ty> GetAll()
		{
			return _context.Set<_ty>().AsQueryable();
		}

		public _ty getById(int id)
		{
			return _context.Set<_ty>().FirstOrDefault(t => t.Id == id);
		}

		public void removeById(int id)
		{
			_context.Set<_ty>().Remove(getById(id));
			_context.SaveChanges();
		}

		public void removeAll()
		{
			_context.Set<_ty>().RemoveRange(GetAll());
			_context.SaveChanges();
		}

		public void update(_ty item)
		{
			_context.Set<_ty>().Attach(item);
			_context.Entry(item).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public void addObject(_ty item)
		{
			_context.Set<_ty>().Add(item);
			_context.SaveChanges();
		}
	}
}
