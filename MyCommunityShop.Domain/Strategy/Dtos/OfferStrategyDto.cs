namespace MyCommunityShop.Domain.Strategy.Dtos
{
    using System.Collections.Generic;
    using MyCommunityShop.Domain.Services.Basket.Dtos;

    public class OfferStrategyDto
    {
        public OfferStrategyDto(IEnumerable<BasketItemDto> items)
        {
            this.Items = items;
        }

        public IEnumerable<BasketItemDto> Items { get; }
    }
}
