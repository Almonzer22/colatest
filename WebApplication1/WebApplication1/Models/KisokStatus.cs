using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class KisokStatus
    {
        public KisokStatus()
        {
            Kiosks = new HashSet<Kiosks>();
        }

        [Key]
        [Column("KioskStatusID")]
        public int KioskStatusId { get; set; }
        [Required]
        [StringLength(20)]
        public string StatusCode { get; set; }
        [Required]
        [StringLength(20)]
        public string StatusName { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty("KioskStatus")]
        public virtual ICollection<Kiosks> Kiosks { get; set; }
    }
}
