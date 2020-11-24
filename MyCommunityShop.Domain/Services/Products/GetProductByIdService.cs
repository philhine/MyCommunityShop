namespace MyCommunityShop.Domain.Services.Products
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    public class GetProductByIdService : IService<int, Product>
    {
        private readonly IProductRepository repository;

        public GetProductByIdService(IProductRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Product> Execute(int id)
        {
            return await this.repository.Get(id);
        }
    }
}
