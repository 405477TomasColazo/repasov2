using Library.Context;
using Library.Domain;

namespace Library.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(LibraryDBContext context) : base(context)
        {
        }

        public Task<Autor> GetByNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
