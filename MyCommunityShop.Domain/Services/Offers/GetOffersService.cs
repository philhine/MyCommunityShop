namespace MyCommunityShop.Domain.Services.Offers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MyCommunityShop.Domain.Interfaces;
    using MyCommunityShop.Domain.Models;

    public class GetOffersService : IService<IEnumerable<Offer>>
    {
        private readonly IOfferRepository repository;

        public GetOffersService(IOfferRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Offer>> Execute()
        {
            return await this.repository.Get();
        }
    }
}
