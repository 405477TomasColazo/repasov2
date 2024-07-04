using Api.Context;
using Api.Domain;

namespace Api.Repositories.Impl
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(ShoppingContext context) : base(context)
        {
        }
    }
}
