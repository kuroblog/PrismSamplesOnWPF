
namespace PEF.Shell
{
    using Prism.Commands;
    using Prism.Mvvm;

    public partial class MainWindowViewModel : BindableBase
    {
        private string title = "prism extend sample";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });
    }
}
