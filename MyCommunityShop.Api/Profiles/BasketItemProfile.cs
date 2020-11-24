namespace MyCommunityShop.Api.Profiles
{
    using AutoMapper;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Models;

    public class BasketItemProfile : Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItemEntity, BasketItem>()
                .ForMember(dest => dest.BasketId, opts => opts.MapFrom(src => src.BasketId))
                .ForMember(dest => dest.Product, opts => opts.MapFrom(src => src.Product))
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Quantity));

            CreateMap<BasketItem, BasketItemDto>()
                .ForMember(dest => dest.BasketId, opts => opts.MapFrom(src => src.BasketId))
                .ForMember(dest => dest.Product, opts => opts.MapFrom(src => src.Product))
                .ForMember(dest => dest.ProductId, opts => opts.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Quantity));
        }
    }
}
