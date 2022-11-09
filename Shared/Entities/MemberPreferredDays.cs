using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [Table("MemberPreferredDays")]
    public class MemberPreferredDays
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(10)]
        public Int32 MemberId { get; set; }

        [Required]
        public Int32 DayOfWeekId { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String? UpdatedBy { get; set; }

    }
}
