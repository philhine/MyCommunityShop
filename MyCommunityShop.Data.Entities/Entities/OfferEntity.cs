namespace MyCommunityShop.Data.Entities.Entities
{
    public class OfferEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int OfferType { get; set; }

        public int MatchingProductId { get; set;}

        public int SavingProductId { get; set; }
    }
}
