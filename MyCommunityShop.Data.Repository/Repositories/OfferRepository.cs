namespace MyCommunityShop.Data.Repository.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using MyCommunityShop.Data.Entities;
    using MyCommunityShop.Data.Entities.Entities;
    using MyCommunityShop.Domain.Models;

    public class OfferRepository : IOfferRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public OfferRepository(DataContext context, IMapper mapper)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<Offer> Create()
        {
            var offer = new OfferEntity();

            await this.context.Offers.AddAsync(offer);
            await this.context.SaveChangesAsync();

            return mapper.Map<Offer>(offer);
        }

        public async Task<Offer> GetById(int id)
        {
            var offers = await this.context.Offers.FirstOrDefaultAsync(x => x.Id == id);

            if (offers == null)
            {
                return null;
            }

            var mappedOffers = this.mapper.Map<Offer>(offers);

            return mappedOffers;
        }
        
        public async Task<IEnumerable<Offer>> Get()
        {
            var offers = await context.Offers.ToArrayAsync();

            return this.mapper.Map<IEnumerable<Offer>>(offers);
        }
    }
}
