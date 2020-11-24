namespace MyCommunityShop.Data.Repository.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using MyCommunityShop.Data.Entities;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Models;

    public class BasketRepository : IBasketRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public BasketRepository(DataContext context, IMapper mapper)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<Basket> Create()
        {
            var basket = new BasketEntity();

            await this.context.Baskets.AddAsync(basket);
            await this.context.SaveChangesAsync();

            return mapper.Map<Basket>(basket); 
        }

        public async Task<Basket> GetById(int id)
        {
            var basket = await GetBasketById(id);

            if (basket == null)
            {
                return null;
            }

            var mappedBasket = this.mapper.Map<Basket>(basket);

            return mappedBasket;
        }

        public async Task<Basket> AddProductToBasket(int basketId, int productId)
        {
            var basket = await GetBasketById(basketId);

            if (basket == null)
            {
                throw new System.InvalidOperationException($"Unable to add product to basket with id {basketId}");
            }

            var existingBasketItems = basket.BasketItems.ToList();
            if (existingBasketItems.Any(x => x.ProductId == productId))
            {
                existingBasketItems.First(x => x.ProductId == productId).Quantity += 1;
            }
            else
            {
                var product = await this.context.Products.FirstOrDefaultAsync(x => x.Id == productId);
                var basketItem = new BasketItemEntity()
                {
                    BasketId = basketId,
                    Basket = basket,
                    ProductId = productId,
                    Product = product,
                    Quantity = 1,
                };

                basket.BasketItems.Add(basketItem);
            }

            await this.context.SaveChangesAsync();

            var mappedBasket = this.mapper.Map<Basket>(basket);

            return mappedBasket;
        }

        public async Task<Basket> RemoveProductFromBasket(int basketId, int productId)
        {
            var basket = await GetBasketById(basketId);

            if (basket == null)
            {
                throw new System.InvalidOperationException($"Unable to find basket with id {basketId}");
            }

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            
            if (basketItem == null)
            {
                throw new System.InvalidOperationException($"Unable to find product {productId} in basket with id {basketId}");
            }

            if (basketItem.Quantity > 1)
            {
                basketItem.Quantity -= 1;
            }
            else
            {
                basket.BasketItems.Remove(basketItem);
            }

            await this.context.SaveChangesAsync();

            var mappedBasket = this.mapper.Map<Basket>(basket);

            return mappedBasket;
        }

        private async Task<BasketEntity> GetBasketById(int id)
        {
            return await this.context.Baskets
                    .Include(x => x.BasketItems)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
