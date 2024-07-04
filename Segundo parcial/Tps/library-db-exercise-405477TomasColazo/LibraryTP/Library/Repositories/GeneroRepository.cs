using Library.Context;
using Library.Domain;

namespace Library.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(LibraryDBContext context) : base(context)
        {
        }

        public Task<Genero> GetByNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
