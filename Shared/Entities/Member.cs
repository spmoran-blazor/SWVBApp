using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    [Table("Member")]
    public partial class Member
    {
        public Member()
        {
            EventRosters = new HashSet<EventRoster>();
            MemberExceptionDates = new HashSet<MemberExceptionDate>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(40)]
        public string? AzureId { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(20)]
        public string? MobileNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        [StringLength(1)]
        [Unicode(false)]
        public string? Gender { get; set; }
        public int PlayLevel { get; set; }
        public int PlayScore { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        [InverseProperty(nameof(EventRoster.Member))]
        public virtual ICollection<EventRoster> EventRosters { get; set; }
        [InverseProperty(nameof(MemberExceptionDate.Member))]
        public virtual ICollection<MemberExceptionDate> MemberExceptionDates { get; set; }
    }
}
