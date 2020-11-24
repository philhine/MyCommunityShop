namespace MyCommunityShop.Domain.Services.Basket
{
    using System.Threading.Tasks;
    using Models;
    using Interfaces;
    using MyCommunityShop.Domain.Services.Basket.Dtos;

    public class AddProductToBasketService : IService<AddProductToBasketServiceDto, Basket>
    {
        private readonly IBasketRepository repository;
        private readonly IService<Basket, decimal> calculatorService;

        public AddProductToBasketService(IBasketRepository repository, IService<Basket, decimal> calculatorService)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            this.calculatorService = calculatorService ?? throw new System.ArgumentNullException(nameof(calculatorService));
        }

        public async Task<Basket> Execute(AddProductToBasketServiceDto dto)
        {
            var basket = await this.repository.AddProductToBasket(dto.BasketId, dto.ProductId);
            basket.Saving = await this.calculatorService.Execute(basket);

            return basket;
        }
    }
}
