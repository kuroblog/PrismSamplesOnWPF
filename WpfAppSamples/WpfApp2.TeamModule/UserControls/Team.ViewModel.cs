
namespace WpfApp2.TeamModule.UserControls
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public partial class TeamViewModel : BindableBase
    {
        public string Test { get; } = "This is team page.";

        private readonly IRegionManager regionManager;

        public TeamViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public DelegateCommand<string> NavigationCommand => new DelegateCommand<string>(viewName =>
        {
            regionManager.RequestNavigate("MainRegion", viewName);
        });
    }
}
