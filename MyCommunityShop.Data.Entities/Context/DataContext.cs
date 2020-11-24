namespace MyCommunityShop.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using MyCommunityShop.Data.Entities.Entities;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<BasketEntity> Baskets { get; set; }

        public DbSet<OfferEntity> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
