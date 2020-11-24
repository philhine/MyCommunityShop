namespace MyCommunityShop.Api.LinkFactories
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Interfaces;
    using Models;

    public class BasketLinkFactory : ILinkFactory<BasketViewModel>
    {
        public IEnumerable<LinkDto> Create(BasketViewModel basket, IUrlHelper urlhelper)
        {
             return new List<LinkDto>()
            {
                new LinkDto(urlhelper.Link("GetBasket", new { basket.Id }), "self", "GET"),
            };
        }
    }
}
