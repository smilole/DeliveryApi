using Delivery.Api;
using Delivery.Api.Classes;
using DeliveryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApi.Contexts
{
    public class DishesDbContext : DbContext
    {
        public DishesDbContext(DbContextOptions<DishesDbContext> options) : base(options) { }

        public DbSet<DishDto> Dishes { get; set; }

    }
}
