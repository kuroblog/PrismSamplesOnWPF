
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Events;
    using Prism.Ex.App.Common;
    using Prism.Mvvm;
    using Prism.Regions;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class HomeViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;
        private readonly IRegionManager region;
        private readonly IEventAggregator ea;

        public HomeViewModel(DemoConfig config, IRegionManager region, IEventAggregator ea)
        {
            this.config = config;
            this.region = region;
            this.ea = ea;
        }

        public string Version => config.ModuleVersion;

        public string Title => config.ModuleName;

        public DelegateCommand<string> ViewNavigationCommand => new DelegateCommand<string>(arg =>
        {
            //ea?.BusyIndicatorStateEventPublish(true);

            Task.Factory.StartNew(() =>
            {
                ea?.BusyIndicatorStateEventPublish(true);

                Task.Delay(3000).Wait();

                ea?.BusyIndicatorStateEventPublish(false);
            });

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
