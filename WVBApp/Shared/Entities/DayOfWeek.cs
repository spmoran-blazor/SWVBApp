using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("DayOfWeek")]
    public class DayOfWeek
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(10)]
        public String Day { get; set; }

    }
}
