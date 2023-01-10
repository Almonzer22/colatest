using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Areas
    {
        public Areas()
        {
            Streets = new HashSet<Streets>();
        }

        [Key]
        [Column("AreaID")]
        public int AreaId { get; set; }
        [Required]
        [StringLength(100)]
        public string AreaName { get; set; }

        [InverseProperty("Area")]
        public virtual ICollection<Streets> Streets { get; set; }
    }
}
