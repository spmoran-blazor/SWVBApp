using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Event")]
    public class Event
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime? EventDate { get; set; }

        [Required]
        public String? EventTime { get; set; }

        [Required]
        public Int32 AreaOfPlayId { get; set; }

        [Required]
        public Int32 EventSchedulingCodeId { get; set; }

        public Int32 PartialGameId { get; set; }

        [Required]
        public Int32 ParticipantLimit { get; set; }

        [MaxLength(200)]
        public String? EventComment { get; set; }

        [Required]
        public Boolean IsCancelled { get; set; }

        [Required]
        public Boolean IsPartial { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String? UpdatedBy { get; set; }

    }
}
