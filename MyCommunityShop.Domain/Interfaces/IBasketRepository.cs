namespace MyCommunityShop.Domain.Interfaces
{
    using System.Threading.Tasks;
    using Models;

    public interface IBasketRepository
    {
        Task<Basket> Create();
        Task<Basket> GetById(int id);
        Task<Basket> AddProductToBasket(int basketId, int productId);
        Task<Basket> RemoveProductFromBasket(int basketId, int productId);
    }
}
