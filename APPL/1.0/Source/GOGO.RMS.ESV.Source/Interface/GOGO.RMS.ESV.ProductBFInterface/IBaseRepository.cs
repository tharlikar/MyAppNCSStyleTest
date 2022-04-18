using GOGO.RMS.ESV.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GOGO.RMS.ESV.Core.Interface
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		T Get(Guid id);
		IList<T> List();
		IList<T> List(Expression<Func<T, bool>> expression);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}