using Library.Domain;

namespace Library.Repositories
{
    public interface IAutorRepository : IBaseRepository<Autor>
    {
        Task<Autor> GetByNombre(string nombre);
    }
}
