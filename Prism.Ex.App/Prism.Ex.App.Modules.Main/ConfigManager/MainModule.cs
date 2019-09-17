
namespace Prism.Ex.App.Modules.Main
{
    using Prism.Ex.App.Common;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Regions;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();

            rm?.RegisterViewWithRegion(RegionNames.Main, typeof(MainView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<MainConfig>();

            ViewModelLocationProvider.Register<MainView, MainViewModel>();
        }

        public MainModule() { }
    }
}
