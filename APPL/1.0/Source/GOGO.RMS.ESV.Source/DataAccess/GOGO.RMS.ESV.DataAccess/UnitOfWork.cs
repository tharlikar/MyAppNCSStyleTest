using GOGO.RMS.ESV.Core.Interface;
using System;
using System.Data.Entity;


namespace GOGO.RMS.ESV.EF.Impl.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataAccessContext dataContext;
        private DbContextTransaction transaction;
        public UnitOfWork(DataAccessContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void BeginTransaction()
        {
            this.transaction = this.dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            this.transaction.Commit();
        }

        public void Dispose()
        {
            this.transaction.Dispose();
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }
    }
}
