using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("AreaOfPlay")]
    public class AreaOfPlay
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Area { get; set; }

        [Required]
        public Int32 VenueId { get; set; }

        public List<AreaOfPlay> AreasOfPlay {get; set; } = new List<AreaOfPlay>();

    }
}
