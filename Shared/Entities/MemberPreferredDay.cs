using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    [Index(nameof(MemberId), nameof(DayOfWeekId), Name = "IX_MemberPreferredDays", IsUnique = true)]
    public partial class MemberPreferredDays
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int DayOfWeekId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        //[ForeignKey(nameof(DayOfWeekId))]
        //[InverseProperty("MemberPreferredDays")]
        //public virtual DayOfWeek DayOfWeek { get; set; }
    }
}
