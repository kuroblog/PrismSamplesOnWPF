
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Ex.App.Common;
    using Prism.Mvvm;
    using Prism.Regions;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class HomeViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;
        private readonly IRegionManager region;

        public HomeViewModel(DemoConfig config, IRegionManager region)
        {
            this.config = config;
            this.region = region;
        }

        public string Version => config.ModuleVersion;

        public string Title => config.ModuleName;

        public DelegateCommand<string> ViewNavigationCommand => new DelegateCommand<string>(arg =>
        {
            switch (arg)
            {
                case "Default":
                    region?.RequestNavigate(RegionNames.Content, typeof(DefaultView).FullName);
                    break;
                case "Test":
                    region?.RequestNavigate(RegionNames.Content, typeof(TestView).FullName);
                    break;
                case "Log":
                    region?.RequestNavigate(RegionNames.Content, typeof(LogView).FullName);
                    break;
                default:
                    break;
            }
        });
    }
}
