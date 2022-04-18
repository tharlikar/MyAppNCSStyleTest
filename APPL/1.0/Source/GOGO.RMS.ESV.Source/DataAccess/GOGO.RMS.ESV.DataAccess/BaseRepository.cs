using GOGO.RMS.ESV.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOGO.RMS.ESV.Core.Entity;
using System.Data.Entity;
using System.Linq.Expressions;

namespace GOGO.RMS.ESV.EF.Impl.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DataAccessContext dataContext;

        public BaseRepository(DataAccessContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Delete(T entity)
        {
            this.dataContext.Set<T>().Remove(entity);
            this.dataContext.SaveChanges();
        }



        public T Get(Guid id)
        {
            return this.dataContext.Set<T>().Find(id);
        }



        public void Insert(T entity)
        {
            this.dataContext.Set<T>().Add(entity);
            this.dataContext.SaveChanges();
        }

        public IList<T> List()
        {
            return this.dataContext.Set<T>().ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> expression)
        {
            return this.dataContext.Set<T>().Where(expression).ToList();
        }


        public void Update(T entity)
        {
            this.dataContext.Entry<T>(entity).State = EntityState.Modified;
            this.dataContext.SaveChanges();
        }
    }
}
