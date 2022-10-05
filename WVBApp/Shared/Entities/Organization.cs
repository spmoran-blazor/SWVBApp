using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Organization")]
    public class Organization
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        public Int32 OrganizationTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public String OrganizationName { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String UpdatedBy { get; set; }

    }
}
