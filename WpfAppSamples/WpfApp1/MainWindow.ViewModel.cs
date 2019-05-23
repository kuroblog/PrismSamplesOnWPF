
namespace WpfApp1
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using WpfApp1.UserControls;

    public partial class MainWindowViewModel : BindableBase
    {
        private string title = "prism demo";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        // The second method of register view does not require this type
        //private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public MainWindowViewModel(
            // No need
            //IUnityContainer container,
            IRegionManager regionManager)
        {
            // No need
            //this.container = container;
            this.regionManager = regionManager;
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(p =>
        {
            //// register view
            //// resolve view's instance
            //var vCmdLsit = container.Resolve<CommandList>();
            //var vPersonMain = container.Resolve<PersonMain>();
            //var vTeamMain = container.Resolve<TeamMain>();
            //// add to regionManager
            //var region = regionManager.Regions["MainRegion"];
            //region.Add(vCmdLsit);
            //region.Add(vPersonMain);
            //region.Add(vTeamMain);
            //// activate view
            //region.Activate(vCmdLsit);

            // or
            // another method
            // register view by RegisterTypes(IContainerRegistry containerRegistry) on App.xaml.cs
            // navigate to target view
            regionManager.RequestNavigate("MainRegion", nameof(CommandList));
        });
    }
}
