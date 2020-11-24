namespace MyCommunityShop.Api.Profiles
{
    using AutoMapper;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Models;

    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketViewModel>();

            CreateMap<BasketEntity, Basket>()
                .ForMember(dest => dest.Saving, opts => opts.Ignore());
        }
    }
}
