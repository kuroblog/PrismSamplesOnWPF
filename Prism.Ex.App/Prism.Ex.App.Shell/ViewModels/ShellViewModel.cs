
namespace Prism.Ex.App.Shell.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ShellViewModel : BindableBase
    {
        public string Title { get; } = "Prism App Demo";

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });
    }
}
