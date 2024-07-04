using DependencyInjection.Context;
using DependencyInjection.Domain;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Repositories;

public class DbCountryRepository : ICountryRepository
{
    private readonly CountryDbContext _context;

    public DbCountryRepository(CountryDbContext context)
    {
        _context = context;
    }

    public async Task<Country> CreateAsync(Country country)
    {
        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();

        return country;
    }

    public Task<List<Country>> GetAllAsync()
    {
        return _context.Countries.ToListAsync();
    }
}
