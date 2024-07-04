using Library.Domain;

namespace Library.Repositories
{
    public interface IGeneroRepository : IBaseRepository<Genero>
    {
        Task<Genero> GetByNombre(string nombre);
    }
}
