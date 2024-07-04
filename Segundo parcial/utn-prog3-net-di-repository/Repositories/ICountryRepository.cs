using DependencyInjection.Domain;

namespace DependencyInjection.Repositories;

public interface ICountryRepository
{
    Task<List<Country>> GetAllAsync();
    Task<Country> CreateAsync(Country country);
}
