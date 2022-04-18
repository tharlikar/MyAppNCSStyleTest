using System;

namespace GOGO.RMS.ESV.Core.Entity
{
    abstract public class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual String CreatedBy { get; set; }
        public virtual DateTime? LastUpdate { get; set; }
        public virtual String LastUpdatedBy { get; set; }
        public virtual String Owner { get; set; }
    }
}
