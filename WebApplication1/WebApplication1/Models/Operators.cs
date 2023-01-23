using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Operators
    {
        public Operators()
        {
            Kiosks = new HashSet<Kiosks>();
            Visites = new HashSet<Visites>();
        }

        [Key]
        [Column("OperatorID")]
        public int OperatorId { get; set; }
        [Required]
        [StringLength(50)]
        public string OperatorName { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        public bool OperatorStatus { get; set; }
        [Required]
        [StringLength(50)]
        public string Disablity { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Users.OperatorsCreatedByNavigation))]
        public virtual Users CreatedByNavigation { get; set; }
        [ForeignKey(nameof(UpdatedBy))]
        [InverseProperty(nameof(Users.OperatorsUpdatedByNavigation))]
        public virtual Users UpdatedByNavigation { get; set; }
        [InverseProperty("Operator")]
        public virtual ICollection<Kiosks> Kiosks { get; set; }
        [InverseProperty("Operator")]
        public virtual ICollection<Visites> Visites { get; set; }
    }
}
