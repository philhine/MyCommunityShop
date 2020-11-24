namespace MyCommunityShop.Domain.Services.Basket.Dtos
{
    public class RemoveProductFromBasketServiceDto
    {
        public RemoveProductFromBasketServiceDto(int basketId, int productId)
        {
            BasketId = basketId;
            ProductId = productId;
        }

        public int BasketId { get; }

        public int ProductId { get; }
    }
}
