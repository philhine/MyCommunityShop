using System.Collections.Generic;

namespace MyCommunityShop.Api.Models
{
    public class BasketViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Saving { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<BasketItemDto> BasketItems { get; set; }
    }
}
