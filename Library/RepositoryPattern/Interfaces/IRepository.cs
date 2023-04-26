using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Library.RepositoryPattern.Interfaces
{
	public interface IRepository<T> where T : BaseEntity  // t base entity den miras alan her şey demek .
	{
		List<T> GetAll();
		List<T> GetActives();
		T GetById(int id);
		void Add(T item);
		void Update(T item);
		void Delete(int id);
		void SpecialDelete(int id);
		List<T> GetByFilter(Expression<Func<T, bool>> exp);
		T Default(Expression<Func<T, bool>> exp);
		int Count();
		bool Any(Expression<Func<T, bool>> exp);
		List<T> SelectActivesByLimit(int count);

	}
}
