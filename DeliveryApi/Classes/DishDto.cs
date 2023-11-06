using System.ComponentModel.DataAnnotations;

namespace Delivery.Api
{
    public class DishDto
    {
        public Guid id { get; set; }

        [Required]
        [MinLength(1)]
        public string name { get; set; }

        public string? description { get; set; }

        [Required]
        public double price { get; set; }

        public string? image { get; set; }

        public Boolean vegeterian { get; set; }

        public double? rating { get; set; }

        public DishCategory category { get; set; }
    }
}
