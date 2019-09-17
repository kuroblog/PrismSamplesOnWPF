
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Ex.App.Common;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Regions;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class DemoModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();

            rm?.RegisterViewWithRegion(RegionNames.Home, typeof(HomeView));
            rm?.RegisterViewWithRegion(RegionNames.Content, typeof(DefaultView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<DemoConfig>();

            ViewModelLocationProvider.Register<HomeView, HomeViewModel>();
            ViewModelLocationProvider.Register<DefaultView, DefaultViewModel>();
            ViewModelLocationProvider.Register<TestView, TestViewModel>();
            ViewModelLocationProvider.Register<LogView, LogViewModel>();

            containerRegistry.RegisterForNavigation<TestView>(typeof(TestView).FullName);
            containerRegistry.RegisterForNavigation<LogView>(typeof(LogView).FullName);
        }

        public DemoModule() { }
    }
}
