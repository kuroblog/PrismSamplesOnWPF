
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class HomeViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;

        public HomeViewModel(DemoConfig config)
        {
            this.config = config;
        }
    }
}
