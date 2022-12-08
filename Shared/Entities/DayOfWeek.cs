using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    [Table("DayOfWeek")]
    public partial class DayOfWeek
    {
        public DayOfWeek()
        {
            MemberPreferredDays = new HashSet<MemberPreferredDay>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string? Day { get; set; }

        //public bool DayOfWeekStatus { get; set;}

        [InverseProperty(nameof(MemberPreferredDay.DayOfWeek))]
        public virtual ICollection<MemberPreferredDay> MemberPreferredDays { get; set; }
    }
}
