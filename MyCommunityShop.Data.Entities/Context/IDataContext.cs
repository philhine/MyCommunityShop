namespace MyCommunityShop.Data.Entities.Context
{
    using Microsoft.EntityFrameworkCore;
    using MyCommunityShop.Data.Entities.Entities;

    public interface IDatacontext
    {
        DbSet<ProductEntity> Products { get; set; }

        DbSet<BasketEntity> Baskets { get; set; }
    }
}
