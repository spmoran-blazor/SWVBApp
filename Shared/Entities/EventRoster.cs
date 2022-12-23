using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    [Table("EventRoster")]
    //[Index(nameof(MemberId), nameof(EventId), Name = "IX_EventRoster")]
    public partial class EventRoster
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int EventId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        //[ForeignKey(nameof(MemberId))]
        //[InverseProperty("EventRosters")]
        //public virtual Member Member { get; set; }
    }
}
