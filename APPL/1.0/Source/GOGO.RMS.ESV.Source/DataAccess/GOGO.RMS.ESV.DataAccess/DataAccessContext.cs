using GOGO.RMS.ESV.Core.Entity;
using System;
using System.Data.Entity;
using System.Linq;
namespace GOGO.RMS.ESV.EF.Impl.Repository
{
    public class DataAccessContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataAccessContext() : base()
        {
        }

        public override int SaveChanges()
        {
            DateTime now = DateTime.Now;
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var auditableEntity = entry.Entity as AuditableEntity;

                if (auditableEntity != null)
                    auditableEntity.LastUpdated = now;
            }

            var entries2 = ChangeTracker.Entries()
                                       .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries2)
            {
                var auditableEntity = entry.Entity as AuditableEntity;

                if (auditableEntity != null)
                {
                    auditableEntity.LastUpdated = now;
                    auditableEntity.Created = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
