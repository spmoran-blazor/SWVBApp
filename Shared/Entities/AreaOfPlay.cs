using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using entities = WVBApp.Shared.Entities;

namespace WVBApp.Shared.Entities
{
    [Table("AreaOfPlay")]
    public partial class AreaOfPlay
    {
        public AreaOfPlay()
        {
            Events = new HashSet<entities.Event>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Area { get; set; }

        [InverseProperty(nameof(Event.AreaOfPlay))]
        public virtual ICollection<Event> Events { get; set; }
    }
}
