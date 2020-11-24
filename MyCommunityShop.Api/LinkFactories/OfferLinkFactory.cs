namespace MyCommunityShop.Api.LinkFactories
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Interfaces;
    using Models;

    public class OfferLinkFactory : ILinkFactory<OfferViewModel>
    {
        public IEnumerable<LinkDto> Create(OfferViewModel offer, IUrlHelper urlhelper)
        {
             return new List<LinkDto>()
            {
                new LinkDto(urlhelper.Link("GetOffers", new { }), "all", "GET"),
            };
        }
    }
}
