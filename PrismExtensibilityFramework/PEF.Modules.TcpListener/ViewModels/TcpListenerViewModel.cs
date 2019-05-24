
namespace PEF.Modules.TcpListener.ViewModels
{
    using PEF.Modules.TcpListener.Models;
    using Prism.Commands;
    using Prism.Mvvm;

    public partial class TcpListenerViewModel : BindableBase
    {
        private string title = "tcp listener";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ListenerAddress listenerAddress = new ListenerAddress();

        public ListenerAddress ListenerAddress
        {
            get { return listenerAddress; }
            set { SetProperty(ref listenerAddress, value); }
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        public DelegateCommand TcpListenerExecuteCommand => new DelegateCommand(() => { });
    }
}
