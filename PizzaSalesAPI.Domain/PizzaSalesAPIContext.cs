using Microsoft.EntityFrameworkCore;
using PizzaSalesAPI.Domain.Models;

namespace PizzaSalesAPI.Domain
{
    public class PizzaSalesAPIContext : DbContext
    {
        public PizzaSalesAPIContext(DbContextOptions<PizzaSalesAPIContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzas>()
                .HasOne<PizzaTypes>(m => m.PizzaTypes)
                .WithMany(m => m.Pizzas)
                .HasForeignKey(m => m.PizzaTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
                .HasOne<Orders>(m => m.Orders)
                .WithMany(m => m.OrderDetails)
                .HasForeignKey(m => m.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetails>()
               .HasOne<Pizzas>(m => m.Pizzas)
               .WithMany(m => m.OrderDetails)
               .HasForeignKey(m => m.PizzaId);
        }

        public DbSet<PizzaTypes> PizzaTypes { get; set;}
        public DbSet<Pizzas>  Pizzas { get; set;}
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
