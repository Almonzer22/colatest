using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Supervisers
    {
        public Supervisers()
        {
            Kiosks = new HashSet<Kiosks>();
            Visites = new HashSet<Visites>();
        }

        [Key]
        [Column("SuperviserID")]
        public int SuperviserId { get; set; }
        [Required]
        [StringLength(100)]
        public string SuperviserName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }
        public bool SuperviserStatus { get; set; }
        public int CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Users.SupervisersCreatedByNavigation))]
        public virtual Users CreatedByNavigation { get; set; }
        [ForeignKey(nameof(UpdatedBy))]
        [InverseProperty(nameof(Users.SupervisersUpdatedByNavigation))]
        public virtual Users UpdatedByNavigation { get; set; }
        [InverseProperty("Superviser")]
        public virtual ICollection<Kiosks> Kiosks { get; set; }
        [InverseProperty("Superviser")]
        public virtual ICollection<Visites> Visites { get; set; }
    }
}
