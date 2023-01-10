using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColaProject.Models
{
    public partial class Users
    {
        public Users()
        {
            KiosksCreatedByNavigation = new HashSet<Kiosks>();
            KiosksUpdatedByNavigation = new HashSet<Kiosks>();
            OperatorsCreatedByNavigation = new HashSet<Operators>();
            OperatorsUpdatedByNavigation = new HashSet<Operators>();
            SupervisersCreatedByNavigation = new HashSet<Supervisers>();
            SupervisersUpdatedByNavigation = new HashSet<Supervisers>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public bool UserStatus { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(Roles.Users))]
        public virtual Roles Role { get; set; }
        [InverseProperty(nameof(Kiosks.CreatedByNavigation))]
        public virtual ICollection<Kiosks> KiosksCreatedByNavigation { get; set; }
        [InverseProperty(nameof(Kiosks.UpdatedByNavigation))]
        public virtual ICollection<Kiosks> KiosksUpdatedByNavigation { get; set; }
        [InverseProperty(nameof(Operators.CreatedByNavigation))]
        public virtual ICollection<Operators> OperatorsCreatedByNavigation { get; set; }
        [InverseProperty(nameof(Operators.UpdatedByNavigation))]
        public virtual ICollection<Operators> OperatorsUpdatedByNavigation { get; set; }
        [InverseProperty(nameof(Supervisers.CreatedByNavigation))]
        public virtual ICollection<Supervisers> SupervisersCreatedByNavigation { get; set; }
        [InverseProperty(nameof(Supervisers.UpdatedByNavigation))]
        public virtual ICollection<Supervisers> SupervisersUpdatedByNavigation { get; set; }
    }
}
