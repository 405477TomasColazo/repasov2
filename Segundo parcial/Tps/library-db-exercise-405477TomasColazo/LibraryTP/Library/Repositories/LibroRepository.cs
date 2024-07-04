using Library.Context;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {
        public LibroRepository(LibraryDBContext context) : base(context)
        {
        }
        public async Task<List<Libro>> GetAllAsync()
        {
            return await _context.Libros.Include(libro => libro.Autor).Include(libro => libro.Genero).ToListAsync();
        }
        public async Task<Libro> DeleteAsync(string isbn)
        {
            var entity = await _context.Libros.FindAsync(isbn);
            if (entity == null)
            {
                return null;
            }

            _context.Libros.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<Libro> GetByIsbn(string isbn)
        {
            return await _context.Libros
                    .Include(libro => libro.Autor)
                    .Include(libro => libro.Genero)
                    .FirstOrDefaultAsync(libro => libro.Isbn == isbn);
        }
    }
}
