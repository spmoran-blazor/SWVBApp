using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Message")]
    public partial class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [Required]
        [StringLength(500)]
        public string? Body { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateSent { get; set; }
        public int? Type { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; }
        [Required]
        [StringLength(50)]
        public string? UpdatedBy { get; set; }
    }
}
