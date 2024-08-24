using Microsoft.EntityFrameworkCore;

namespace Multitenancy.Database.Tenant;

public class TenantDbContext : DbContext
{
    private readonly Tenant _tenant;

    public DbSet<Data> Data { get; set; }
    public TenantDbContext(DbContextOptions<TenantDbContext> options, Tenant tenant)
    :base(options)
    {
        _tenant = tenant;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_tenant.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Data>(options =>
        {
            options.ToTable("Data");
            options.HasKey(e => e.Id);
            options.Property(e => e.Id).ValueGeneratedOnAdd();
            options.Property(e => e.Field).IsRequired().HasMaxLength(10);
            options.Property(e => e.Attribute).IsRequired().HasMaxLength(10);
        });
        
        modelBuilder.HasDefaultSchema("tenant");
    }
}