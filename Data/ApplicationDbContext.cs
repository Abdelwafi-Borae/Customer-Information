using Base.Models;
using Microsoft.EntityFrameworkCore;

namespace Base.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasMany<Address>(c => c.address)
            .WithOne(c => c.customer)
            .HasForeignKey(c => c.CustomerId)
           ;

    }
  public DbSet<Address> addresses { get; set; }
   public DbSet<Customer> customers { get; set; }
}
