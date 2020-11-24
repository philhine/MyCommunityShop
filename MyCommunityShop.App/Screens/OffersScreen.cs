namespace MyCommunityShop.App.Screens
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ConsoleTables;
    using MyCommunityShop.App.Models;
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Utility;

    public class OffersScreen : ScreenWithNoMenu
    {
        protected override string Title => "Current Offers";

        public OffersScreen(DataService service) : base(service) { }

        protected override async Task DisplayContent()
        {
            var offers = await DataService.Get<IEnumerable<OfferDto>>("api/offers");
            if (offers == null)
            {
                ConsoleWriter.WriteError("Unable to retrieve offers, please try again");
                return;
            }

            var table = new ConsoleTable("Description");
            foreach (OfferDto offer in offers)
            {
                table.AddRow(offer.Description);
            }
            table.Write();
        }
    }
}
