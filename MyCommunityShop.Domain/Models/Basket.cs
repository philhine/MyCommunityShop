namespace MyCommunityShop.Domain.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class Basket
    {
        public int Id { get; set; }

        public decimal SubTotal => BasketItems.Sum(x => x.Product.UnitPrice * x.Quantity);

        public decimal Saving { get; set; }

        public decimal Total => SubTotal - Saving;

        public IEnumerable<BasketItem> BasketItems { get; set; }
    }
}
