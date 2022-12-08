using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    [Table("Event")]
    [Index(nameof(AreaOfPlayId), nameof(EventDate), Name = "IX_Event", IsUnique = true)]
    public partial class Event
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EventDate { get; set; }
        public TimeSpan? EventTime { get; set; }
        public int AreaOfPlayId { get; set; }
        public int EventSchedulingCodeId { get; set; }
        public int? PartialGameId { get; set; }
        public int ParticipantLimit { get; set; }
        [StringLength(200)]
        public string? EventComment { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsPartial { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? UpdatedBy { get; set; }

        [ForeignKey(nameof(AreaOfPlayId))]
        [InverseProperty("Events")]
        public virtual AreaOfPlay? AreaOfPlay { get; set; }
        [ForeignKey(nameof(EventSchedulingCodeId))]
        [InverseProperty("Events")]
        public virtual EventSchedulingCode? EventSchedulingCode { get; set; }
    }
}
