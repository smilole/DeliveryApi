using Delivery.Api;
using DeliveryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApi.Contexts
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options) { }
        public DbSet<DishBasketDto> Baskets { get; set; }
        public DbSet<DishInBasketModel> DishInBasket { get; set; }

    }
}
