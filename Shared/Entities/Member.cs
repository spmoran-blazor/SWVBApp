﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WVBApp.Shared.Entities
{
    [Table("Member")]
    public class Member
    {
        [Required]
        public Int32 Id { get; set; }

        [Required]
        public string? AzureId { get; set; } = "0";

        [Required]
        [MaxLength(50)]
        public String? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public String? LastName { get; set; }

        [MaxLength(50)]
        public String? Email { get; set; }

        [Required]
        [MaxLength(10)]
        public String? MobileNumber { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public Int32 PlayLevel { get; set; }

        [Required]
        public Int32 PlayScore { get; set; }

        [Required]
        public Boolean IsCurrent { get; set; }

        public List<Member> Members { get; set; } = new List<Member>();

    }
}
