using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Delivery.Api.Classes
{
    public class UserDto
    {
        //public Guid id { get; set; }

        [Required]
        [MinLength(1)]
        public string fullName { get; set; }

        public DateOnly? birthDate { get; set; }

        [Required]
        public Gender gender { get; set; }

        public Guid address { get; set; }

        [Required]
        [MinLength(1)]
        [EmailAddress]
        public string email { get; set; }

        public string? phoneNumber { get; set; }
    }
}
