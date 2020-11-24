namespace MyCommunityShop.Api.Profiles
{
    using AutoMapper;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Models;

    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<OfferEntity, Offer>();
            CreateMap<Offer, OfferViewModel>();
        }
    }
}
