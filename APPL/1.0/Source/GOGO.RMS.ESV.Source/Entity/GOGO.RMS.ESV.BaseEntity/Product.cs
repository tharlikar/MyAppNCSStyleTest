using System;

namespace GOGO.RMS.ESV.Core.Entity
{
    public class Product : BaseEntity
    {
        public virtual String SKU { get; set; }
        public virtual String Name { get; set; }
    }
}
