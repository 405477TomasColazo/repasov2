using Library.Domain;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository repository)
        {
            _generoRepository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generos = await _generoRepository.GetAllAsync();
            return Ok(generos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GeaById(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok(genero);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Genero genero)
        {
            if (genero == null) { return BadRequest(); }
            return Ok(await _generoRepository.CreateAsync(genero));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Genero genero)
        {
            if (id != genero.Id) { return BadRequest(); }
            return Ok(await _generoRepository.UpdateAsync(genero));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _generoRepository.DeleteAsync(id));
        }
    }
}
