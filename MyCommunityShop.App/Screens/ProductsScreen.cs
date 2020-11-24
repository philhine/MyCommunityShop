namespace MyCommunityShop.App.Screens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ConsoleTables;
    using MyCommunityShop.App.Models;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Store;
    using MyCommunityShop.App.Utility;

    public class ProductsScreen : BaseScreen
    {
        protected override string Title => "Product Catalog";

        public ProductsScreen(DataService service) : base(service) { }

        private IEnumerable<ProductDto> products;

        protected override void DisplayMenu()
        {
            ConsoleWriter.WriteLine("Please select from the following options");
            ConsoleWriter.WriteLine("Select a product id from above to add to your basket", false);
            ConsoleWriter.WriteLine($"{DisplayBasketContents} - view your basket", false);
            ConsoleWriter.WriteLine($"{Quit} - quit to main menu", false);
        }

        protected override async Task DisplayContent()
        {
            products = await DataService.Get<IEnumerable<ProductDto>>("api/products");
            if (products == null)
            {
                ConsoleWriter.WriteError("Unable to retrieve products, please try again");
                return;
            }

            var table = new ConsoleTable("Id", "Name", "Unit Price");
            foreach (ProductDto product in products)
            {
                table.AddRow(product.Id, product.Name, $"{product.UnitPrice:C}");
            }
            table.Write();
        }

        protected override bool IsValid(string optionSelected)
        {
            if (HasSelectedDisplayBasket(optionSelected))
            {
                return true;
            }

            return int.TryParse(optionSelected, out _);
        }

        protected override async Task OnOptionSelected(string optionSelected)
        {
            if (HasSelectedDisplayBasket(optionSelected))
            {
                var basketScreen = new BasketScreen(DataService);
                await DisplayBasketScreen();
                return;
            }

            if (int.TryParse(optionSelected, out int result))
            {
                var product = products.FirstOrDefault(x => x.Id == result);
                if (product == null)
                {
                    ConsoleWriter.WriteLine("Product Id not found, please press enter to try again");
                    Console.ReadKey();
                    return;
                }

                await AddToBasket(product);
            }
        }

        private async Task AddToBasket(ProductDto product)
        {
            var basketId = Store.Instance.Basket.Id;

            var basket = await DataService.Post<BasketDto>($"api/baskets/{basketId}/product/{product.Id}");
            if (basket == null)
            {
                ConsoleWriter.WriteLine($"Failed to add {product.Name} to basket");
                Console.ReadKey();
                return;
            }

            Store.Instance.Basket = basket;

            await DisplayBasketScreen();
        }
    }
}
