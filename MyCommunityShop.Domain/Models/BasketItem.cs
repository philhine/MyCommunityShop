namespace MyCommunityShop.Domain.Models
{
    public class BasketItem
    {
        public int BasketId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
