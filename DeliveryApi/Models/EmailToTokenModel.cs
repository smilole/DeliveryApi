using System.ComponentModel.DataAnnotations;

namespace DeliveryApi.Models
{
    public class EmailToTokenModel
    {
        [Key]

        public string email { get; set; }
        public string token { get; set; }

    }
}
