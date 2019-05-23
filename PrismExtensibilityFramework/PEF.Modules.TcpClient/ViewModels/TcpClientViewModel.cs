
namespace PEF.Modules.TcpClient.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    public partial class TcpClientViewModel : BindableBase
    {
        private string title = "tcp client";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });
    }
}
