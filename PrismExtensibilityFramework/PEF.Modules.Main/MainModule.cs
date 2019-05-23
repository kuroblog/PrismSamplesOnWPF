
namespace PEF.Modules.Main
{
    using PEF.Common;
    using PEF.Modules.Main.ViewModels;
    using PEF.Modules.Main.Views;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Regions;

    public class MainModule : IModule
    {
        #region IModule
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var rm = containerProvider.Resolve<IRegionManager>();
            rm.RegisterViewWithRegion(RegionNames.Main, typeof(TcpSampleMainView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TcpSampleMainView, TcpSampleMainViewModel>();
        }
        #endregion
    }
}
