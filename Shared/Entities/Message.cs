using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVBApp.Shared.Entities
{
    public class Message
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String? Title { get; set; }

        [Required]
        [MaxLength(10)]
        public String? Body { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        public Int32 Type { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(50)]
        public String UpdatedBy { get; set; }

    }
}
