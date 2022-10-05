using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("OrganizationType")]
    public class OrganizationType
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Type { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String UpdatedBy { get; set; }

    }
}
