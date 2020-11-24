namespace MyCommunityShop.App.Screens
{
    using System.Linq;
    using System.Threading.Tasks;
    using ConsoleTables;
    using MyCommunityShop.App.Models;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Store;
    using MyCommunityShop.App.Utility;

    #pragma warning disable CS1998
    public class BasketScreen : ScreenWithNoMenu
    {
        protected override string Title => "Shopping Basket";

        public BasketScreen(DataService service) : base(service) { }

        protected override async Task DisplayContent()
        {
            BasketDto myBasket = Store.Instance.Basket;

            if (myBasket.BasketItems.Any())
            {
                var table = new ConsoleTable("Product Id", "Name", "Unit Price", "Quantity");
                foreach (BasketItemDto item in myBasket.BasketItems)
                {
                    table.AddRow(item.ProductId, item.Product.Name, $"{item.Product.UnitPrice:C}", item.Quantity);
                }
                table.Options.EnableCount = false;
                table.Write();
            }

            ConsoleWriter.WriteSeperationLine();

            if (myBasket.Saving > 0)
            {
                ConsoleWriter.WriteCurrencyField("Sub Total", myBasket.SubTotal, 10);
                ConsoleWriter.WriteCurrencyField("Saving", myBasket.Saving, 10);
            }
            ConsoleWriter.WriteCurrencyField("Total", myBasket.Total, 10);

            ConsoleWriter.WriteSeperationLine();
        }

    }
}
