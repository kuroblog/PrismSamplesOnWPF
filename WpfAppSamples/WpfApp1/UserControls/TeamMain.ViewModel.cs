
namespace WpfApp1.UserControls
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public partial class TeamMainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public TeamMainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public DelegateCommand<string> NavigationReturnCommand => new DelegateCommand<string>(p =>
        {
            regionManager.RequestNavigate("MainRegion", nameof(CommandList));
        });
    }
}
