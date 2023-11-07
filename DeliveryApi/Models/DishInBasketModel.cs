using System.ComponentModel.DataAnnotations;

namespace DeliveryApi.Models
{
    public class DishInBasketModel
    {
        public Guid DishId { get; set; }

        [Key]
        public Guid UserId { get; set; }
    }
}
