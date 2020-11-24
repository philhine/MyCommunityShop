namespace MyCommunityShop.Domain.Services.Basket
{
    using System.Threading.Tasks;
    using Models;
    using MyCommunityShop.Domain.Interfaces;

    public class CreateBasketService : IService<Basket>
    {
        private readonly IBasketRepository repository;

        public CreateBasketService(IBasketRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task<Basket> Execute()
        {
            return await this.repository.Create();
        }
    }
}
