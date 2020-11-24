namespace MyCommunityShop.Data.Entities.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BasketItemEntity
    {
        [Key]
        public int BasketId { get; set; }

        [Key]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("BasketId")]
        public BasketEntity Basket { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
    }
}
