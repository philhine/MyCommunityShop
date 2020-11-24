namespace MyCommunityShop.App
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;
    using MyCommunityShop.App.Models;
    using MyCommunityShop.App.Screens;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Utility;
    using MyStore = MyCommunityShop.App.Store;

    public class Program
    {
        private const string Title = "My Community Shop";

        private static DataService dataService;

        /// <summary>
        /// Main
        /// </summary>
        ///<remarks>
        ///Ideally this would be using dot net core so we could mark the method as async
        ///</remarks>
        public static void Main(string[] args)
        {
            Initialise().GetAwaiter().GetResult();

            var mainMenu = new MainMenuScreen(dataService);
            mainMenu.Display().GetAwaiter().GetResult();

            Exit();
        }

        public static async Task Initialise()
        {
            string apiBasePath = ConfigurationManager.AppSettings["baseApiAddress"];
            dataService = new DataService(apiBasePath);

            Console.Title = Title;

            var basket = await dataService.Post<BasketDto>("api/baskets");
            if (basket == null)
            {
                ConsoleWriter.WriteError("Unable to create basket, please try again");
                return;
            }

            MyStore.Store.Instance.Basket = basket;
        }

        public static void Exit()
        {
            ConsoleWriter.Reset();
            ConsoleWriter.WriteLine("Thanks for shopping with us, we hope to see you soon!");
            Console.ReadKey();
        }
    }
}
