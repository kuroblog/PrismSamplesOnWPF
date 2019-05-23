
namespace PEF.Modules.Main.ViewModels
{
    using PEF.Common;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;

    public partial class TcpSampleMainViewModel : BindableBase
    {
        private string title = "prism tcp listener & client sample";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });


        private readonly IRegionManager regionManager;

        public TcpSampleMainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public DelegateCommand<string> NavigationCommand => new DelegateCommand<string>(viewName =>
        {
            var nParam = new NavigationParameters();
            nParam.Add(viewName, $"go to {viewName} view.");

            regionManager.RequestNavigate(RegionNames.Content, viewName, nParam);
        });
    }
}
