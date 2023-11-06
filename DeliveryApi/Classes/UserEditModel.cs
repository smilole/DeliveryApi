using System.ComponentModel.DataAnnotations;

namespace Delivery.Api.Classes
{
    public class UserEditModel
    {
        [Required]
        [MinLength(1)]

        public string fullName { get; set; }

        public DateOnly? birthDate { get; set; }

        [Required]
        public Gender gender { get; set; }

        public Guid? addressId { get; set; }

        public string? phoneNumber { get; set; }
    }
}
