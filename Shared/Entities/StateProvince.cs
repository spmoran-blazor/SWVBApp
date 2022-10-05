using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("StateProvince")]
    public class StateProvince
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        public Int32 CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public String StateOrProvince { get; set; }

        [Required]
        [MaxLength(2)]
        public String StateOrProvinceCode { get; set; }
    }
}
