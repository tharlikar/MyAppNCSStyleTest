using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOGO.RMS.ESV.Core.Entity
{
    public abstract class AuditableEntity
    {
        public virtual DateTime? Created { get; set; }
        public virtual String CreatedBy { get; set; }
        public virtual DateTime? LastUpdated { get; set; }
        public virtual String LastUpdatedBy { get; set; }
    }
}
