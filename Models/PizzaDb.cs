using Microsoft.EntityFrameworkCore;
namespace PizzaStore.Models
{
class PizzaDb : DbContext
{
public PizzaDb(DbContextOptions options) : base(options) { }
public DbSet<PizzaEhod> Pizzas { get; set; } = null!;
}
    
}