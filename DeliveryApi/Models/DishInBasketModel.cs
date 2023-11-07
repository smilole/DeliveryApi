using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApi.Models
{
    public class DishInBasketModel
    {
        [Key]        
        
        public Guid DishId { get; set; }

        
        public Guid UserId { get; set; }

        

    }

    

}
