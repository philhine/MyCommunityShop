namespace MyCommunityShop.Domain.Models
{
    using MyCommunityShop.Domain.Enum;

    public class Offer
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int MatchingProductId { get; set; }

        public int SavingProductId { get; set; }

        public OfferEnum OfferType { get; set; }
    }
}
