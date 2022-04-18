using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOGO.RMS.ESV.Product
{
    public class Product : GOGO.RMS.ESV.BaseEntity.BaseEntity
    {
        [StringLength(50)]
        public String SKU { get; set; }

        [StringLength(100)]
        public String Name { get; set; }
    }
}
