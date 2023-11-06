using System.ComponentModel.DataAnnotations;

namespace Delivery.Api.Classes
{
    public class TokenResponse
    {
        [Required]
        [MinLength(1)]

        public string Token { get; set; }
    }
}
