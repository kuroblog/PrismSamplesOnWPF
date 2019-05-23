
namespace WpfApp2.MainModule
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Regions;
    using WpfApp2.MainModule.UserControls;

    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion("MainRegion", typeof(CommandList));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}
