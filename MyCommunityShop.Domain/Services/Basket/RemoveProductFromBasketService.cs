namespace MyCommunityShop.Domain.Services.Basket
{
    using System.Threading.Tasks;
    using MyCommunityShop.Domain.Interfaces;
    using Models;
    using MyCommunityShop.Domain.Services.Basket.Dtos;

    public class RemoveProductFromBasketService : IService<RemoveProductFromBasketServiceDto, Basket>
    {
        private readonly IBasketRepository repository;

        public RemoveProductFromBasketService(IBasketRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public Task<Basket> Execute(RemoveProductFromBasketServiceDto dto)
        {
            return this.repository.RemoveProductFromBasket(dto.BasketId, dto.ProductId);
        }
    }
}
