namespace MyCommunityShop.Api.Maps
{
    using AutoMapper;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Models;

    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductEntity, Product>();
        }
    }
}
