using Microsoft.EntityFrameworkCore;
using PissaSalesAPI.Domain.Models;

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
                .OnDelete(DeleteBehavior.Cascade); ;
                        
        }

        public DbSet<PizzaTypes> PizzaTypes { get; set;}
        public DbSet<Pizzas>  Pizzas { get; set;}
    }
}
