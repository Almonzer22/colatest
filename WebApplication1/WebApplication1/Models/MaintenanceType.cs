using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class MaintenanceType
    {
        public MaintenanceType()
        {
            Maintenance = new HashSet<Maintenance>();
        }

        [Key]
        [Column("MaintenanceTypeID")]
        public int MaintenanceTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string MaintenanceName { get; set; }

        [InverseProperty("MaintenanceType")]
        public virtual ICollection<Maintenance> Maintenance { get; set; }
    }
}
