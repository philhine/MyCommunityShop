namespace MyCommunityShop.Domain.Factory
{
    using System;
    using System.Collections.Generic;
    using MyCommunityShop.Domain.Enum;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Models;
    using MyCommunityShop.Domain.Strategy;

    public class OfferFactory : IFactory<IEnumerable<Offer>, IEnumerable<IOfferStrategy>>
    {
        public IEnumerable<IOfferStrategy> Get(IEnumerable<Offer> offers)
        {
            foreach (Offer offer in offers)
            {
                switch(offer.OfferType)
                {
                    case OfferEnum.BuyOneGetOneFree:
                        yield return new BuyOneGetOneFreeStrategy(offer.MatchingProductId);
                        break;
                    case OfferEnum.BuyOneGetOneHalfPrice:
                        yield return new BuyOneProductGetAnotherHalfPriceStrategy(offer.MatchingProductId, offer.SavingProductId);
                        break;
                    case OfferEnum.ThirdOff:
                        yield return new ThirdOffStrategy(offer.MatchingProductId);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Offer type is out of expected range {offer.OfferType}");
                }
            }
        }
    }
}
