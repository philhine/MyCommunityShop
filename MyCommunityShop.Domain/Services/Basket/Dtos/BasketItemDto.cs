namespace MyCommunityShop.Domain.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public BasketItemDto(int productId, decimal unitPrice, int quantity)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int ProductId { get;  }

        public decimal UnitPrice { get; }

        public int Quantity { get; }
    }
}
