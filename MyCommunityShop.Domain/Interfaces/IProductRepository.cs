namespace MyCommunityShop.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();

        Task<Product> Get(int productId);
    }
}
