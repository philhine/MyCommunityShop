namespace MyCommunityShop.App.Screens
{
    using System;
    using System.Threading.Tasks;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Utility;

    public abstract class BaseScreen
    {
        protected const string Quit = "Q";
        protected const string DisplayBasketContents = "B";

        protected abstract string Title { get; }

        protected virtual bool InputRequired => true;

        protected DataService DataService { get; }

        public BaseScreen(DataService service)
        {
            this.DataService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public virtual async Task Display()
        {
            bool quit = false;
            do
            {
                ConsoleWriter.Reset();
                ConsoleWriter.WriteTitle(Title);

                await DisplayContent();

                DisplayMenu();

                var optionSelected = Console.ReadLine();
                quit = UserSelectedQuit(optionSelected) || !InputRequired;

                if (!quit)
                {
                    if (!IsValid(optionSelected))
                    {
                        ConsoleWriter.WriteLine("Incorrect entry, please enter a key to try again");
                        Console.ReadKey();
                        continue;
                    }

                    await OnOptionSelected(optionSelected);
                }
            } while (!quit);
        }

        protected virtual Task OnOptionSelected(string optionSelected)
        {
            return Task.CompletedTask;
        }

        protected virtual Task DisplayContent()
        {
            return Task.CompletedTask;
        }

        protected abstract void DisplayMenu();

        protected abstract bool IsValid(string option);

        protected bool UserSelectedQuit(string option)
        {
            return option.Equals(Quit, StringComparison.OrdinalIgnoreCase);
        }

        protected bool HasSelectedDisplayBasket(string optionSelected)
        {
            return optionSelected.Equals(DisplayBasketContents, StringComparison.OrdinalIgnoreCase);
        }

        protected async Task DisplayBasketScreen()
        {
            var basketScreen = new BasketScreen(DataService);
            await basketScreen.Display();
        }
    }
}
