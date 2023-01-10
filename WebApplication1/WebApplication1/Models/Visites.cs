using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Visites
    {
        public Visites()
        {
            Maintenance = new HashSet<Maintenance>();
        }

        [Key]
        [Column("VisiteID")]
        public int VisiteId { get; set; }
        [Column("KioskID")]
        public int KioskId { get; set; }
        [Column("SuperviserID")]
        public int SuperviserId { get; set; }
        [Column("OperatorID")]
        public int OperatorId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime VisiteDate { get; set; }
        [Required]
        [StringLength(50)]
        public string VisitStatuse { get; set; }
        public bool? Clean { get; set; }
        [StringLength(200)]
        public string Recommendation { get; set; }
        [StringLength(200)]
        public string Note { get; set; }
        [StringLength(20)]
        public string ImagePath { get; set; }

        [ForeignKey(nameof(KioskId))]
        [InverseProperty(nameof(Kiosks.Visites))]
        public virtual Kiosks Kiosk { get; set; }
        [ForeignKey(nameof(OperatorId))]
        [InverseProperty(nameof(Operators.Visites))]
        public virtual Operators Operator { get; set; }
        [ForeignKey(nameof(SuperviserId))]
        [InverseProperty(nameof(Supervisers.Visites))]
        public virtual Supervisers Superviser { get; set; }
        [InverseProperty("Visite")]
        public virtual ICollection<Maintenance> Maintenance { get; set; }
    }
}
