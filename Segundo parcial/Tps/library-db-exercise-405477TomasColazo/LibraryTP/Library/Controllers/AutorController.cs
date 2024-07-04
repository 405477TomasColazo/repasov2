using Library.Domain;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        public AutorController(IAutorRepository autorRepository)
        {
              _autorRepository = autorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autores = await _autorRepository.GetAllAsync();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GeaById(int id)
        {
            var autor = await _autorRepository.GetByIdAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return Ok(autor);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Autor autor)
        {
            if (autor == null) { return BadRequest(); }
            return Ok(await _autorRepository.CreateAsync(autor));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] Autor autor)
        {
            if(id != autor.Id) { return BadRequest(); }
            return Ok(await _autorRepository.UpdateAsync(autor));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          return Ok(await _autorRepository.DeleteAsync(id));
        }
    }
}
