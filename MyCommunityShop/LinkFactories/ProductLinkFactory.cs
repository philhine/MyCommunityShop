namespace MyCommunityShop.Api.LinkFactories
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Interfaces;
    using Models;

    public class ProductLinkFactory : ILinkFactory<ProductViewModel>
    {
        public IEnumerable<LinkDto> Create(ProductViewModel product, IUrlHelper urlhelper)
        {
             return new List<LinkDto>()
            {
                new LinkDto(urlhelper.Link("GetProducts", new { }), "all", "GET"),
                new LinkDto(urlhelper.Link("GetProductById", new { product.Id }), "self", "GET"),
            };
        }
    }
}
