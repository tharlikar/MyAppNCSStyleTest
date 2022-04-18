using GOGO.RMS.ESV.BaseEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GOGO.RMS.ESV.DataAccess
{
    public class DataAccessContext: DbContext
    {
        public DbSet<GOGO.RMS.ESV.Product.Product> Products { get; set; }
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
                var auditableEntity = entry.Entity as GOGO.RMS.ESV.BaseEntity.BaseEntity;

                if (auditableEntity != null)
                    auditableEntity.LastUpdate = now;
            }

            var entries2 = ChangeTracker.Entries()
                                       .Where(e => e.State == EntityState.Added);

            foreach (var entry in entries2)
            {
                var auditableEntity = entry.Entity as GOGO.RMS.ESV.BaseEntity.BaseEntity;

                if (auditableEntity != null)
                {
                    auditableEntity.LastUpdate = now;
                    auditableEntity.Created = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
