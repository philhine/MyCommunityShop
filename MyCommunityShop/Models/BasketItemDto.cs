namespace MyCommunityShop.Api.Models
{
    public class BasketItemDto
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
