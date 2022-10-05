using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("EventRoster")]
    public class EventRoster
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        public Int32 MemberId { get; set; }

        [Required]
        public Int32 EventId { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String UpdatedBy { get; set; }

    }
}
