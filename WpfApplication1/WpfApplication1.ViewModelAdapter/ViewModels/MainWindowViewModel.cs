
namespace WpfApplication1.ViewModelAdapter.ViewModels
{
    using Prism.Mvvm;

    public class MainWindowViewModel : BindableBase
    {
        private string _title = nameof(MainWindowViewModel);
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
