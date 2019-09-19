
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows;

    [ExcludeFromCodeCoverage]
    public class TestViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;

        public TestViewModel(DemoConfig config)
        {
            this.config = config;
        }

        public DelegateCommand<string> LanaguageSettingCommand => new DelegateCommand<string>(arg =>
        {
            config.SetDisplayLanguage(arg);
        });
    }
}
