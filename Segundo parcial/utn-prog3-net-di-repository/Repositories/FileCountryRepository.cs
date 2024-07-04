using DependencyInjection.Domain;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DependencyInjection.Repositories;

public class FileCountryRepository : ICountryRepository
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileCountryRepository(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public Task<Country> CreateAsync(Country country)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Country>> GetAllAsync()
    {
        var basePath = _webHostEnvironment.ContentRootPath;

        var filePath = Path.Combine(basePath, "countries.json");

        var countriesAsString = await File.ReadAllTextAsync(filePath);

        var countries = JsonConvert.DeserializeObject<List<Country>>(countriesAsString);

        return countries;
    }
}
