using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities {

    [Table("MemberExceptionDates")]
    public class MemberExceptionDates
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String? UpdatedBy { get; set; }

    }
}
