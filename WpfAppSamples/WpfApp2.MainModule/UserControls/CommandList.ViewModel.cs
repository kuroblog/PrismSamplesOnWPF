
namespace WpfApp2.MainModule.UserControls
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public partial class CommandListViewModel : BindableBase
    {
        public string Test { get; } = "This is command page.";

        private readonly IRegionManager regionManager;

        public CommandListViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public DelegateCommand<string> NavigationCommand => new DelegateCommand<string>(viewName =>
        {
            var nParam = new NavigationParameters();
            nParam.Add(viewName, "go to person page.");

            regionManager.RequestNavigate("MainRegion", viewName, nParam);
        });
    }
}
