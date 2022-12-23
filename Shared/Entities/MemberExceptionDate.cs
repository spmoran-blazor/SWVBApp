using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    //[Index(nameof(BeginDate), Name = "IX_MemberExceptionDates_BeginDate")]
    //[Index(nameof(MemberId), nameof(BeginDate), nameof(EndDate), Name = "IX_MemberExceptionDates_Composite")]
    //[Index(nameof(EndDate), Name = "IX_MemberExceptionDates_EndDate")]
    public partial class MemberExceptionDate
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BeginDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        //[ForeignKey(nameof(MemberId))]
        //[InverseProperty("MemberExceptionDates")]
        //public virtual Member Member { get; set; }
    }
}
