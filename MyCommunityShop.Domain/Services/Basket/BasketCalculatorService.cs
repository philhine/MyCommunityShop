namespace MyCommunityShop.Domain.Services.Basket
{
    using System.Threading.Tasks;
    using MyCommunityShop.Domain.Interfaces;
    using Models;
    using System.Linq;
    using MyCommunityShop.Domain.Services.Basket.Dtos;
    using System.Collections.Generic;
    using MyCommunityShop.Domain.Strategy.Dtos;

    public class BasketCalculatorService : IService<Basket, decimal>
    {
        private readonly IService<IEnumerable<Offer>> getOffersService;
        private readonly IFactory<IEnumerable<Offer>, IEnumerable<IOfferStrategy>> offerFactory;

        public BasketCalculatorService(
            IService<IEnumerable<Offer>> getOffersService, 
            IFactory<IEnumerable<Offer>, IEnumerable<IOfferStrategy>> offerFactory)
        {
            this.getOffersService = getOffersService ?? throw new System.ArgumentNullException(nameof(getOffersService));
            this.offerFactory = offerFactory ?? throw new System.ArgumentNullException(nameof(offerFactory));
        }

        public async Task<decimal> Execute(Basket basket)
        {
            if (!basket.BasketItems.Any())
            {
                return 0;
            }

            var offers = await this.getOffersService.Execute();
            var offerStrategies = this.offerFactory.Get(offers);

            var items = basket.BasketItems.Select(x => new BasketItemDto(x.ProductId, x.Product.UnitPrice, x.Quantity));
            var dto = new OfferStrategyDto(items);

            decimal saving = 0;
            foreach (IOfferStrategy strategy in offerStrategies.Where(x => x.IsApplicable(dto)))
            {
                saving += strategy.Execute(dto);
            }

            return saving;            
        }
    }
}
