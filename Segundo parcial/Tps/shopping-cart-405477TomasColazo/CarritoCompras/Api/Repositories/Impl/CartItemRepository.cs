using Api.Context;
using Api.Domain;

namespace Api.Repositories.Impl
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ShoppingContext context) : base(context)
        {
        }
    }
}
