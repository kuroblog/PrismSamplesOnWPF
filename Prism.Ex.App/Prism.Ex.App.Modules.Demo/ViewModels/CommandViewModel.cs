
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Mvvm;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class CommandViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;

        public CommandViewModel(DemoConfig config)
        {
            this.config = config;

            ExecuteDelegateCommand = new DelegateCommand(Execute, CanExecute);
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                SetProperty(ref isEnabled, value);
                // ExecuteDelegateCommand 不能自动响应 IsEnabled 的状态
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }

        private void Execute()
        {
            Task.Delay(3000).Wait();
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }

        private void ExecuteGeneric(string arg)
        {
            Task.Delay(3000).Wait();
        }

        //public DelegateCommand ExecuteDelegateCommand => new DelegateCommand(Execute, CanExecute);
        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public DelegateCommand DelegateCommandObservesProperty => new DelegateCommand(Execute, CanExecute).ObservesProperty(() => IsEnabled);

        public DelegateCommand DelegateCommandObservesCanExecute => new DelegateCommand(Execute).ObservesCanExecute(() => IsEnabled);

        public DelegateCommand<string> ExecuteGenericDelegateCommand => new DelegateCommand<string>(ExecuteGeneric).ObservesCanExecute(() => IsEnabled);
    }
}
