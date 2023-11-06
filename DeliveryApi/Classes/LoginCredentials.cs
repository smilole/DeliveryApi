using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Delivery.Api.Classes
{
    public class LoginCredentials
    {
        [Required]
        [MinLength(1)]
        [EmailAddress]
        public string email {  get; set; }

        [Required]
        [MinLength(1)]
        public string password { get; set; }
    }
}
