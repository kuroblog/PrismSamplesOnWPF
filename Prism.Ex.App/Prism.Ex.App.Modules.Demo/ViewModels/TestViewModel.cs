
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class TestViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;

        public TestViewModel(DemoConfig config)
        {
            this.config = config;
        }
    }
}
