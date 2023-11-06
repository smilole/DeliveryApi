using System.ComponentModel.DataAnnotations;

namespace Delivery.Api.Classes
{
    public class OrderCreateDto
    {
        [Required]
        public DateTime deliveryTime { get; set; }

        [Required]
        public Guid addressId { get; set; }
    }
}
