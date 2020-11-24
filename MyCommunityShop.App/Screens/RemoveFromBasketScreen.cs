namespace MyCommunityShop.App.Screens
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using ConsoleTables;
    using MyCommunityShop.App.Models;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Store;
    using MyCommunityShop.App.Utility;

    #pragma warning disable CS1998
    public class RemoveFromBasketScreen : BaseScreen
    {
        protected override string Title => "Shopping Basket (Remove Items)";

        public RemoveFromBasketScreen(DataService service) : base(service) { }


        protected override void DisplayMenu()
        {
            ConsoleWriter.WriteLine("Please select from the following options");
            ConsoleWriter.WriteLine("Select a product id from above to remove from your basket", false);
            ConsoleWriter.WriteLine($"{DisplayBasketContents} - view your basket", false);
            ConsoleWriter.WriteLine($"{Quit} - quit to main menu", false);
        }

        protected override async Task DisplayContent()
        {
            var myBasket = Store.Instance.Basket;

            var table = new ConsoleTable("Product Id", "Name", "Unit Price", "Quantity");
            foreach (BasketItemDto item in myBasket.BasketItems)
            {
                table.AddRow(item.ProductId, item.Product.Name, $"{item.Product.UnitPrice:C}", item.Quantity);
            }
            table.Options.EnableCount = false;
            table.Write();

            ConsoleWriter.WriteSeperationLine();

            if (myBasket.Saving > 0)
            {
                ConsoleWriter.WriteLine($"Sub Total: {myBasket.SubTotal:C}", false);
                ConsoleWriter.WriteLine($"Saving:    {myBasket.Saving:C}", false);
            }
            ConsoleWriter.WriteLine($"Total:     {myBasket.Total:C}", false);

            ConsoleWriter.WriteSeperationLine();
        }

        protected override bool IsValid(string optionSelected)
        {
            return int.TryParse(optionSelected, out _);
        }

        protected override async Task OnOptionSelected(string optionSelected)
        {
            var basketItems = Store.Instance.Basket.BasketItems;

            if (int.TryParse(optionSelected, out int result))
            {
                var basketItem = basketItems.FirstOrDefault(x => x.ProductId == result);
                if (basketItem == null)
                {
                    ConsoleWriter.WriteLine("Product Id not found, please enter a key to try again");
                    Console.ReadKey();
                    return;
                }

                await DeleteFromBasket(basketItem.Product);
            }
        }

        private async Task DeleteFromBasket(ProductDto product)
        {
            var basketId = Store.Instance.Basket.Id;

            var basket = await DataService.Delete<BasketDto>($"api/baskets/{basketId}/product/{product.Id}");
            if (basket == null)
            {
                ConsoleWriter.WriteError("Unable to remove product, please try again");
                return;
            }

            Store.Instance.Basket = basket;

            await DisplayBasketScreen();
        }
    }
}
