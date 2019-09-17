
namespace Prism.Ex.App.Modules.Main
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class MainViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly MainConfig config;

        public MainViewModel(MainConfig config)
        {
            this.config = config;
        }
    }
}
