using System.Collections.Generic;

namespace MyCommunityShop.App.Models
{
    public class BasketDto : ModelBase
    {
        public BasketDto()
        {
        }

        public int Id { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Saving { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<BasketItemDto> BasketItems { get; set; }
    }
}
