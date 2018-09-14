
namespace WpfApplication2.ModuleA
{
    using Prism.Modularity;
    using Prism.Regions;
    using Views;

    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;

        public ModuleAModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }
    }
}