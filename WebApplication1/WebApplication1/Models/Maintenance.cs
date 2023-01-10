using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Maintenance
    {
        [Key]
        [Column("MaintenanceProcessID")]
        public int MaintenanceProcessId { get; set; }
        [Column("MaintenanceTypeID")]
        public int MaintenanceTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string KioskCode { get; set; }
        [Column("VisiteID")]
        public int VisiteId { get; set; }
        [Column("SuperviserID")]
        public int? SuperviserId { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string MaintenanceStatus { get; set; }
        [StringLength(100)]
        public string Details { get; set; }
        [StringLength(200)]
        public string Note { get; set; }
        [Column(TypeName = "date")]
        public DateTime MaintenanceDate { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey(nameof(MaintenanceTypeId))]
        [InverseProperty("Maintenance")]
        public virtual MaintenanceType MaintenanceType { get; set; }
        [ForeignKey(nameof(VisiteId))]
        [InverseProperty(nameof(Visites.Maintenance))]
        public virtual Visites Visite { get; set; }
    }
}
