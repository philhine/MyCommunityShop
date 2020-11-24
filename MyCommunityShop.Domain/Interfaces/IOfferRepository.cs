namespace MyCommunityShop.Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IOfferRepository
    {
        Task<Offer> Create();

        Task<Offer> GetById(int id);

        Task<IEnumerable<Offer>> Get();
    }
}
