
namespace WpfApplication1.ViewModelAdapter.ViewModels
{
    using Prism.Mvvm;

    public class CustomViewModel : BindableBase
    {
        private string _title = nameof(CustomViewModel);
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
