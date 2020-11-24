using MyCommunityShop.Domain.Strategy.Dtos;

namespace MyCommunityShop.Domain.Interfaces
{
    public interface IOfferStrategy
    {
        bool IsApplicable(OfferStrategyDto dto);

        decimal Execute(OfferStrategyDto dto);
    }
}
