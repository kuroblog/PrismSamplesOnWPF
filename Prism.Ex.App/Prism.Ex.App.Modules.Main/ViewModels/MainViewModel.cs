
namespace Prism.Ex.App.Modules.Main
{
    using Prism.Commands;
    using Prism.Events;
    using Prism.Ex.App.Common;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class MainViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly MainConfig config;
        private readonly IEventAggregator ea;

        public MainViewModel(MainConfig config, IEventAggregator ea)
        {
            this.config = config;
            this.ea = ea;

            this.ea?.BusyIndicatorStateEventSubscribe(BusyIndicatorStateEventHandler);
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private void BusyIndicatorStateEventHandler(bool state) => IsBusy = state;
    }
}
