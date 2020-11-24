namespace MyCommunityShop.App.Screens
{
    using MyCommunityShop.App.Services;
    using MyCommunityShop.App.Utility;

    public abstract class ScreenWithNoMenu : BaseScreen
    {
        public ScreenWithNoMenu(DataService service) : base(service) { }

        protected override bool InputRequired => false;

        protected override bool IsValid(string option)
        {
            return true;
        }

        protected override void DisplayMenu()
        {
            ConsoleWriter.WriteLine("Press enter to return");
        }
    }
}
