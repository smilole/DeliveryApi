using Delivery.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace Delivery.Api.Classes
{
    public class OrderDto
    {
        public Guid id { get; set; }

        [Required]
        public DateTime deliveryTime { get; set; }

        [Required]
        public DateTime orderTime { get; set; }

        [Required]
        public OrderStatus status { get; set; }

        [Required]
        public double price { get; set; }

        [Required]
        public DishBasketDto dishes { get; set; }

        [Required]
        [MinLength(1)]
        public string address { get; set; }
    }
}
