using System;

namespace GOGO.RMS.ESV.Core.Entity
{
    public class BaseEntity: AuditableEntity
    {
        public virtual Guid Id { get; set; }
    }
}
