namespace MyCommunityShop.App.Models
{
    public class ProductDto : ModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
