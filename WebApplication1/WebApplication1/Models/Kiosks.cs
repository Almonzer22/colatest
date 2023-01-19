using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Kiosks
    {
        public Kiosks()
        {
            Visites = new HashSet<Visites>();
        }

        [Key]
        [Column("KioskID")]
        public int KioskId { get; set; }
        [Required]
        [StringLength(50)]
        public string KioskCode { get; set; }
        [Column("StreetID")]
        public int StreetId { get; set; }
        [Column("OperatorID")]
        public int OperatorId { get; set; }
        [Column("SuperviserID")]
        public int SuperviserId { get; set; }
        [Column("KioskTypeID")]
        public int? KioskTypeId { get; set; }
        [Column("KioskStatusID")]
        public int KioskStatusId { get; set; }
        [StringLength(50)]
        public string CoolerStatus { get; set; }
        [StringLength(50)]
        public string LockDoor { get; set; }
        [StringLength(50)]
        public string LockWindow { get; set; }
        [StringLength(30)]
        public string Electricity { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Users.KiosksCreatedByNavigation))]
        public virtual Users CreatedByNavigation { get; set; }
        [ForeignKey(nameof(KioskStatusId))]
        [InverseProperty(nameof(KisokStatus.Kiosks))]
        public virtual KisokStatus KioskStatus { get; set; }
        [ForeignKey(nameof(KioskTypeId))]
        [InverseProperty(nameof(KioskTypes.Kiosks))]
        public virtual KioskTypes KioskType { get; set; }
        [ForeignKey(nameof(OperatorId))]
        [InverseProperty(nameof(Operators.Kiosks))]
        public virtual Operators Operator { get; set; }
        [ForeignKey(nameof(SuperviserId))]
        [InverseProperty(nameof(Supervisers.Kiosks))]
        public virtual Supervisers Supervioser { get; set; }
        [ForeignKey(nameof(UpdatedBy))]
        [InverseProperty(nameof(Users.KiosksUpdatedByNavigation))]
        public virtual Users UpdatedByNavigation { get; set; }
        [InverseProperty("Kiosk")]
        public virtual ICollection<Visites> Visites { get; set; }
    }
}
