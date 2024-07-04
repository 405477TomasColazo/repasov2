using Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
    }
}
