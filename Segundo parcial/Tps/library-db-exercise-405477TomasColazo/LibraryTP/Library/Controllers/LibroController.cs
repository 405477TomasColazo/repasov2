using Library.Domain;
using Library.Dtos;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IGeneroRepository _generoRepository;
        public LibroController(ILibroRepository libroRepository, IAutorRepository autorRepository,IGeneroRepository generoRepository)
        {
            _libroRepository = libroRepository;
            _autorRepository = autorRepository;
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await _libroRepository.GetAllAsync();
            return Ok(libros);
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetByIsbn(string isbn)
        {
            var libro = await _libroRepository.GetByIsbn(isbn);
            if(libro == null)
            {
                return NotFound();
            }
            return Ok(libro);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LibroDto libroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Autor autor = await _autorRepository.GetByIdAsync(libroDto.Autor.Id);
            if (autor == null)
            {
                autor = new Autor { Nombre = libroDto.Autor.Nombre };
                await _autorRepository.CreateAsync(autor);
            }
            Genero genero = await _generoRepository.GetByIdAsync(libroDto.Genero.Id);
            if(genero == null)
            {
                genero = new Genero { Nombre = libroDto.Genero.Nombre };
                await _generoRepository.CreateAsync(genero);
            }
            var nuevoLibro = new Libro
            {
                Isbn = libroDto.Isbn,
                Titulo = libroDto.Titulo,
                FechaDePublicacion = libroDto.FechaDePublicacion,
                Autor = autor,
                Genero = genero
            };
            await _libroRepository.CreateAsync(nuevoLibro);
            return Ok(nuevoLibro);

        }
        [HttpPut("{isbn}")]
        public async Task<IActionResult> Update(string isbn, [FromBody] Libro libro)
        {
            if (isbn != libro.Isbn) { return BadRequest(); }
            return Ok(await _libroRepository.UpdateAsync(libro));
        }
        [HttpDelete("{isbn}")]
        public async Task<IActionResult> Delete(string isbn)
        {
            return Ok(await _libroRepository.DeleteAsync(isbn));
        }
    }
}

