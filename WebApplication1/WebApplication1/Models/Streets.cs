using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Streets
    {
        [Key]
        [Column("StreetID")]
        public int StreetId { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetCode { get; set; }
        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }
        [Column("AreaID")]
        public int AreaId { get; set; }

        [ForeignKey(nameof(AreaId))]
        [InverseProperty(nameof(Areas.Streets))]
        public virtual Areas Area { get; set; }
    }
}
