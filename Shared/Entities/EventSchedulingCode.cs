using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.Entities
{
    [Table("EventSchedulingCode")]
    public partial class EventSchedulingCode
    {
        public EventSchedulingCode()
        {
            Events = new HashSet<Event>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Code { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        [Required]
        [StringLength(100)]
        public string? Frequency { get; set; }
        [Required]
        [StringLength(100)]
        public string? Notes { get; set; }
        public int MinLevelMain { get; set; }
        public int MaxLevelMain { get; set; }
        public int MinLevelEdge { get; set; }
        public int MaxLevelEdge { get; set; }
        public bool IsActive { get; set; }

        [InverseProperty(nameof(Event.EventSchedulingCode))]
        public virtual ICollection<Event> Events { get; set; }
    }
}
