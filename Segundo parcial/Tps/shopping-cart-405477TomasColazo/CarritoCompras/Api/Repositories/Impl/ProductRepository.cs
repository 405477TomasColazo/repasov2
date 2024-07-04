using Api.Context;
using Api.Domain;

namespace Api.Repositories.Impl
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingContext context) : base(context)
        {
        }
    }
}
