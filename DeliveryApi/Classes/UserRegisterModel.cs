﻿using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Delivery.Api.Classes
{
    public class UserRegisterModel
    {

        public Guid id { get; set; }

        [Required]
        [MinLength(1)]

        public string fullName { get; set; }

        [Required]
        [MinLength(6)]

        public string password { get; set; }

        [Required]
        [MinLength(1)]

        [Key]
        [EmailAddress]
        public string email { get; set; }

        public DateOnly? birthDate { get; set; }

        [Required]
        public Gender gender { get; set; }

        public string? phoneNumber { get; set; }
    }
}
