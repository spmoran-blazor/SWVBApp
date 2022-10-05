using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Venue")]
    public class Venue
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String VenueName { get; set; }

        [Required]
        [MaxLength(50)]
        public String VenueLocation { get; set; }

    }
}
