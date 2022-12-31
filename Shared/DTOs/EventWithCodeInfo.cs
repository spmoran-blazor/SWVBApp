using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.DTOs
{
    public class EventWithCodeInfo
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public string? Code { get; set; }   
        public int AreaOfPlayId { get; set; }
        public string? Area { get; set; }
        public int EventSchedulingCodeId { get; set; }
        public int? PartialGameId { get; set; }
        public int ParticipantLimit { get; set; }
        [StringLength(200)]
        public string? EventComment { get; set; }
        [Required]
        [StringLength(100)]
        public string? Description { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsPartial { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? UpdatedBy { get; set; }
    }
}
