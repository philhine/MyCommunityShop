namespace MyCommunityShop.Domain.Services.Products
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    public class GetProductsService : IService<IEnumerable<Product>>
    {
        private readonly IProductRepository repository;

        public GetProductsService(IProductRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Product>> Execute()
        {
            return await this.repository.Get();
        }
    }
}
