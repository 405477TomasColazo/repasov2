using DependencyInjection.Domain;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Context;

public class CountryDbContext : DbContext
{
    public CountryDbContext(DbContextOptions dbContextOptions)
           : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>().HasData(
            new Country { Id = "1", Name = "Argentina" },
            new Country { Id = "2", Name = "Francia" },
            new Country { Id = "3", Name = "Brasil" },
            new Country { Id = "4", Name = "Chile" },
            new Country { Id = "5", Name = "Paraguay" }
        );
    }

    public DbSet<Country> Countries { get; set; }
}
