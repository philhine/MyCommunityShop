namespace MyCommunityShop.App.Screens
{
    using System.Threading.Tasks;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Utility;

    public class MainMenuScreen : BaseScreen
    {
        private const string DisplayProducts = "P";
        private const string RemoveProducts = "X";
        private const string DisplayOffers = "O";

        protected override string Title => "Main Menu";

        public MainMenuScreen(DataService service) : base(service) { }

        protected override void DisplayMenu()
        {
            ConsoleWriter.WriteLine("Please pick from the following options");
            ConsoleWriter.WriteLine($"{DisplayProducts} - Browse products", false);
            ConsoleWriter.WriteLine($"{RemoveProducts} - Remove products from your basket", false);
            ConsoleWriter.WriteLine($"{DisplayOffers} - View offers", false);
            ConsoleWriter.WriteLine($"{DisplayBasketContents} - View basket", false);
            ConsoleWriter.WriteLine($"{Quit} - Quit", false);
        }

        protected override bool IsValid(string optionSelected)
        {
            switch (optionSelected.ToUpper())
            {
                case DisplayProducts:
                case RemoveProducts:
                case DisplayOffers:
                case DisplayBasketContents:
                    return true;
                default:
                    return false;
            }
        }

        protected override async Task OnOptionSelected(string optionSelected)
        {
            switch (optionSelected.ToUpper())
            {
                case DisplayProducts:
                    await this.DisplayProductScreen();
                    break;
                case RemoveProducts:
                    await DisplayRemoveFromBasketScreen();
                    break;
                case DisplayOffers:
                    await DisplayOffersScreen();
                    break;
                case DisplayBasketContents:
                    await DisplayBasketScreen();
                    break;
                default:
                    break;
            }
        }

        private async Task DisplayProductScreen()
        {
            var productScreen = new ProductsScreen(DataService);
            await productScreen.Display();
        }

        private async Task DisplayOffersScreen()
        {
            var offersScreen = new OffersScreen(DataService);
            await offersScreen.Display();
        }

        private async Task DisplayRemoveFromBasketScreen()
        {
            var removeFromBasketScreen = new RemoveFromBasketScreen(DataService);
            await removeFromBasketScreen.Display();
        }
    }
}
