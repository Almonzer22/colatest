using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class KioskTypes
    {
        public KioskTypes()
        {
            Kiosks = new HashSet<Kiosks>();
        }

        [Key]
        [Column("KioskTypeID")]
        public int KioskTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string KioskTypeName { get; set; }

        [InverseProperty("KioskType")]
        public virtual ICollection<Kiosks> Kiosks { get; set; }
    }
}
