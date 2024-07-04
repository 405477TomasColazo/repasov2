using Library.Domain;

namespace Library.Repositories
{
    public interface ILibroRepository : IBaseRepository<Libro>
    {
        Task<Libro> GetByIsbn(string isbn);
        Task<Libro> DeleteAsync(string isbn);
    }

}
