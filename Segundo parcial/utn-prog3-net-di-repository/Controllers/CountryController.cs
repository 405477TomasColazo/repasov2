using DependencyInjection.Domain;
using DependencyInjection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countryRepository = new InMemoryRepository();

            var countries = await countryRepository.GetAllAsync();

            return Ok(countries);
        }

        [HttpGet("v2")]
        public async Task<IActionResult> GetV2()
        {
            var countries = await _countryRepository.GetAllAsync();

            return Ok(countries);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Country dto)
        {
            var response = await _countryRepository.CreateAsync(dto);

            return Ok(response);
        }
    }
}
