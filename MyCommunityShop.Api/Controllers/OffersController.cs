namespace MyCommunityShop.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyCommunityShop.Api.Interfaces;
    using MyCommunityShop.Api.Models;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Models;

    /// <summary>
    /// The Offers Resource
    /// </summary>
    [Route("api/offers")]
    public class OffersController : ControllerBase
    {
        private readonly ILinkFactory<OfferViewModel> linkFactory;
        private readonly IService<IEnumerable<Offer>> getOffersService;
        private readonly IMapper mapper;

        public OffersController(
            ILinkFactory<OfferViewModel> linkFactory,
            IService<IEnumerable<Offer>> getOffersService, 
            IMapper mapper)
        {
            this.linkFactory = linkFactory ?? throw new System.ArgumentNullException(nameof(linkFactory));
            this.getOffersService = getOffersService ?? throw new System.ArgumentNullException(nameof(getOffersService));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Gets all offers
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetOffers")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            var response = await this.getOffersService.Execute();

            var offers = this.mapper.Map<IEnumerable<OfferViewModel>>(response);
            foreach (var offer in offers)
            {
                offer.Links = this.linkFactory.Create(offer, Url);
            }

            return Ok(offers);
        }
    }
}
