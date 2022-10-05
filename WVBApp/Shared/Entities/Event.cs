using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Event")]
    public class Event
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public Int32 AreaOfPlayId { get; set; }

        [Required]
        public Int32 ParticipantCount { get; set; }

        [MaxLength(200)]
        public String EventComment { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String UpdatedBy { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();

    }
}
