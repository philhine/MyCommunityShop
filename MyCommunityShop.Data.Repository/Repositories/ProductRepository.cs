namespace MyCommunityShop.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyCommunityShop.Data.Entities;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Models;

    public class ProductRepository : IProductRepository
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public ProductRepository(IMapper mapper, DataContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await context.Products.ToArrayAsync();

            return this.mapper.Map<IEnumerable<Product>>(products);
        }

        public async Task<Product> Get(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == productId);

            return this.mapper.Map<Product>(product);
        }
    }
}
