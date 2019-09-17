
namespace Prism.Ex.App.Shell
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ShellViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly ShellConfig config;

        public ShellViewModel(ShellConfig config)
        {
            this.config = config;
        }

        public string Title => config.ProductName;

        public double Width => config.ShellWidth;

        public double Height => config.ShellHeight;
    }
}
