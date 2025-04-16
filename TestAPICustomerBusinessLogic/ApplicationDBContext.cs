using Microsoft.EntityFrameworkCore;

namespace TestAPICustomerBusinessLogic;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Customer> customer { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(c => c.customerId);
        modelBuilder.Entity<Customer>().Property(c => c.customerCode).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.customerName).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.customerAddress).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.createdBy).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.createdAt).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.modifiedBy);
        modelBuilder.Entity<Customer>().Property(c => c.modifiedAt);
    }
}
