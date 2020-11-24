namespace MyCommunityShop.Domain.Strategy
{
    using System.Collections.Generic;
    using System.Linq;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Services.Basket.Dtos;
    using MyCommunityShop.Domain.Strategy.Dtos;

    public class BuyOneGetOneFreeStrategy : IOfferStrategy
    {
        private readonly int matchingProductId;

        public BuyOneGetOneFreeStrategy(int matchingProductId)
        {
            this.matchingProductId = matchingProductId;
        }

        public bool IsApplicable(OfferStrategyDto dto)
        {
            var matchingProduct = dto.Items.FirstOrDefault(x => x.ProductId == this.matchingProductId);

            if (matchingProduct == null)
            {
                return false;
            }

            return matchingProduct.Quantity >= 2;
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
            var matchingItem = items.FirstOrDefault(x => x.ProductId == this.matchingProductId);
            var numberOfItems = matchingItem.Quantity;
            var unitPrice = matchingItem.UnitPrice;

            var numberOfApplicableItems = numberOfItems % 2 == 0
                ? numberOfItems
                : (numberOfItems - 1);

            var numberOfFreeItems = numberOfApplicableItems / 2;

            return unitPrice * numberOfFreeItems;
        }
    }
}
