namespace MyCommunityShop.Domain.Strategy
{
    using System.Collections.Generic;
    using System.Linq;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Services.Basket.Dtos;
    using MyCommunityShop.Domain.Strategy.Dtos;

    public class ThirdOffStrategy : IOfferStrategy
    {
        private readonly int matchingProductId;

        public ThirdOffStrategy(int matchingProductId)
        {
            this.matchingProductId = matchingProductId;
        }

        public bool IsApplicable(OfferStrategyDto dto)
        {
            return dto.Items.Any(x => x.ProductId == this.matchingProductId);
        }

        public decimal Execute(OfferStrategyDto dto)
        {
            if (!this.IsApplicable(dto))
            {
                throw new System.InvalidOperationException("Calculation not applicable");
            }

            return Calculate(dto.Items);
        }

        private decimal Calculate(IEnumerable<BasketItemDto> items)
        {
            var matchingProduct = items.First(x => x.ProductId == this.matchingProductId);

            return (matchingProduct.UnitPrice * matchingProduct.Quantity) / 3;
        }
    }
}
