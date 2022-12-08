using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WVBApp.Shared.DTOs
{
    public partial class PreferredDayOfWeek
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string? Day { get; set; }

        public bool IsPreferred { get; set; }
    }
}
