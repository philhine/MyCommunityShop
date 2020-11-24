namespace MyCommunityShop.App.Models
{
    public class BasketItemDto
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
    }
}
