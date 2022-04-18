using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOGO.RMS.ESV.BaseEntity
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public String CreatedBy { get; set; }

        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        public String LastUpdatedBy { get; set; }

        [StringLength(50)]
        public String DatabaseLoginId { get; set; }
    }
}
