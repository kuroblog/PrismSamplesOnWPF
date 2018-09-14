
namespace WpfApplication3.ViewModels
{
    using Prism.Mvvm;
    //using UsingCompositeCommands.Core;

    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

        //private IApplicationCommands _applicationCommands;
        //public IApplicationCommands ApplicationCommands
        //{
        //    get { return _applicationCommands; }
        //    set { SetProperty(ref _applicationCommands, value); }
        //}

        //public MainWindowViewModel(IApplicationCommands applicationCommands)
        //{
        //    ApplicationCommands = applicationCommands;
        //}
    }
}
