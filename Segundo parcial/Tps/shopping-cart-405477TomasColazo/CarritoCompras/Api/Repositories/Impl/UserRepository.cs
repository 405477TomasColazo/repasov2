using Api.Context;
using Api.Domain;

namespace Api.Repositories.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(ShoppingContext context,IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
