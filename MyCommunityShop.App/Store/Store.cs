namespace MyCommunityShop.App.Store
{
    using System.Collections.Generic;
    using MyCommunityShop.App.Models;

    public sealed class Store
    {
        private static readonly Store instance = new Store();

        static Store()
        {
        }

        private Store()
        {

        }

        public static Store Instance
        {
            get { return instance; }
        }

        public BasketDto Basket { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
