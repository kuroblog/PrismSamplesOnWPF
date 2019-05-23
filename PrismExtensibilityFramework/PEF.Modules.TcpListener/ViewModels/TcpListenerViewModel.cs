
namespace PEF.Modules.TcpListener.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    class TcpListenerViewModel : BindableBase
    {
        private string title = "tcp listener";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });
    }
}
