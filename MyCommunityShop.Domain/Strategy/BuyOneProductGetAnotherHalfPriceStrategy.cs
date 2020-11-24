namespace MyCommunityShop.Domain.Strategy
{
    using System.Collections.Generic;
    using System.Linq;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Services.Basket.Dtos;
    using MyCommunityShop.Domain.Strategy.Dtos;

    public class BuyOneProductGetAnotherHalfPriceStrategy : IOfferStrategy
    {
        private readonly int matchingProductId;
        private readonly int halfPriceProductId;

        public BuyOneProductGetAnotherHalfPriceStrategy(int matchingProductId, int halfPriceProductId)
        {
            this.matchingProductId = matchingProductId;
            this.halfPriceProductId = halfPriceProductId;
        }

        public bool IsApplicable(OfferStrategyDto dto)
        {
            return dto.Items.Any(x => x.ProductId == this.matchingProductId) &&
                dto.Items.Any(x => x.ProductId == this.halfPriceProductId);
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
            var matchingProductQuantity = items.FirstOrDefault(x => x.ProductId == this.matchingProductId).Quantity;

            var potentialHalfPriceProduct = items.First(x => x.ProductId == this.halfPriceProductId);
            var potentialHalfPricesProductQuantity = potentialHalfPriceProduct.Quantity;

            var halfPrice = potentialHalfPriceProduct.UnitPrice / 2;

            var applicableItems = matchingProductQuantity >= potentialHalfPricesProductQuantity
                ? potentialHalfPricesProductQuantity
                : matchingProductQuantity;

            return applicableItems * halfPrice;
        }
    }
}
