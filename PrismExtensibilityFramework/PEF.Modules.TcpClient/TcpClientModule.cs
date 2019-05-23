
namespace PEF.Modules.TcpClient
{
    using PEF.Common;
    using PEF.Modules.TcpClient.ViewModels;
    using PEF.Modules.TcpClient.Views;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;

    public class TcpClientModule : IModule
    {
        #region IModule
        public void OnInitialized(IContainerProvider containerProvider) { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<TcpClientView, TcpClientViewModel>();

            containerRegistry.RegisterForNavigation<TcpClientView>(ViewNames.TcpClient);
        }
        #endregion
    }
}
