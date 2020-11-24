namespace MyCommunityShop.Domain.Services.Basket
{
    using System.Threading.Tasks;
    using Domain.Interfaces;
    using Models;

    public class GetBasketServiceById : IService<int, Basket>
    {
        private readonly IBasketRepository repository;
        private readonly IService<Basket, decimal> calculatorService;

        public GetBasketServiceById(IBasketRepository repository, IService<Basket, decimal> calculatorService)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            this.calculatorService = calculatorService ?? throw new System.ArgumentNullException(nameof(calculatorService));
        }

        public async Task<Basket> Execute(int id)
        {
            var basket = await this.repository.GetById(id);
            basket.Saving = await this.calculatorService.Execute(basket);

            return basket;
        }
    }
}
