using DependencyInjection.Domain;

namespace DependencyInjection.Repositories;

public class ApiCountryRepository : ICountryRepository
{
    private readonly HttpClient _httpClient;

    public ApiCountryRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("CountryApi");
    }

    public Task<Country> CreateAsync(Country country)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Country>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<CountryApiDto>>("all");

            //var list = new List<Country>();
            //foreach (var item in response)
            //{
            //    list.Add(new Country
            //    {
            //        Id = item.ccn3,
            //        Name = item.Name.official
            //    });
            //}

            return response.Select(x => new Country
            {
                Id = x.ccn3,
                Name = x.Name.official
            }).ToList();
        }
        catch (Exception ex)
        {
            return new List<Country>();
        }
    }
}

internal class CountryApiDto 
{
    public CountryApiNameDto Name { get; set; }
    public string ccn3 { get; set; }
}

internal class CountryApiNameDto
{
    public string official { get; set; }
}