using Delivery.Api.Classes;
using DeliveryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApi.Contexts

{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<UserRegisterModel> Users { get; set; }
        public DbSet<EmailToTokenModel> EmailToTokens { get; set; }

    }
}
