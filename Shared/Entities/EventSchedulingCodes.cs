using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("EventSchedulingCode")]
    public class EventSchedulingCode
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String? Code { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Frequency { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Notes { get; set; }

        [Required]
        public Int32 MinLevelMain { get; set; }

        [Required]
        public Int32 MaxLevelMain { get; set; }

        [Required]
        public Int32 MinLevelEdge { get; set; }

        [Required]
        public Int32 MaxLevelEdge { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

    }
}
