using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Country")]
    public class Country
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String CountryName { get; set; }

        public List<Country> Countries { get; set; } = new List<Country>(); 

    }
}
