
namespace PEF.Modules.TcpListener
{
    using PEF.Common;
    using PEF.Modules.TcpListener.ViewModels;
    using PEF.Modules.TcpListener.Views;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;

    public class TcpListenerModule : IModule
    {
        #region IModule
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TcpListenerView, TcpListenerViewModel>();

            containerRegistry.RegisterForNavigation<TcpListenerView>(ViewNames.TcpListener);
        }
        #endregion
    }
}
