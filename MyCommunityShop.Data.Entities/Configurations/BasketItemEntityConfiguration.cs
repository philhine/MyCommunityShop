namespace MyCommunityShop.Data.Entities.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using MyCommunityShop.Data.Entities.Entities;

    public class BasketItemEntityConfiguration : IEntityTypeConfiguration<BasketItemEntity>
    {
        public void Configure(EntityTypeBuilder<BasketItemEntity> builder)
        {
            builder.HasKey(x => new { x.BasketId, x.ProductId });

            builder.Property(x => x.BasketId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
        }
    }
}
