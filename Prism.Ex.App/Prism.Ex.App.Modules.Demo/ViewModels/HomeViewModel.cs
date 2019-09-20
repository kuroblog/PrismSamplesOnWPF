
namespace Prism.Ex.App.Modules.Demo
{
    using Prism.Commands;
    using Prism.Events;
    using Prism.Ex.App.Common;
    using Prism.Ex.App.Logger;
    using Prism.Mvvm;
    using Prism.Regions;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    public class HomeViewModel : BindableBase
    {
        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(arg => { });

        private readonly DemoConfig config;
        private readonly IRegionManager region;
        private readonly IEventAggregator ea;
        private readonly ILogger logger;

        public HomeViewModel(DemoConfig config, IRegionManager region, IEventAggregator ea, ILogger logger)
        {
            this.config = config;
            this.region = region;
            this.ea = ea;
            this.logger = logger;
        }

        public string Version => config.ModuleVersion;

        public string Title => config.ModuleName;

        public DelegateCommand<string> ViewNavigationCommand => new DelegateCommand<string>(arg =>
        {
            //ea?.BusyIndicatorStateEventPublish(true);

            //Task.Factory.StartNew(() =>
            //{
            //    ea?.BusyIndicatorStateEventPublish(true);

            //    Task.Delay(3000).Wait();

            //    ea?.BusyIndicatorStateEventPublish(false);
            //});

            switch (arg)
            {
                case "Default":
                    region?.RequestNavigate(RegionNames.Content, typeof(DefaultView).FullName);
                    break;
                case "Command":
                    region?.RequestNavigate(RegionNames.Content, typeof(CommandView).FullName);
                    break;
                case "Test":
                    region?.RequestNavigate(RegionNames.Content, typeof(TestView).FullName);
                    break;
                case "Log":
                    region?.RequestNavigate(RegionNames.Content, typeof(LogView).FullName);
                    break;
                case "ShowBusy":
                    Task.Factory.StartNew(() =>
                    {
                        ea?.BusyIndicatorStateEventPublish(true);

                        Task.Delay(3000).Wait();

                        ea?.BusyIndicatorStateEventPublish(false);
                    });
                    break;
                case "TestLog":
                    TestLog();
                    break;
                case "ErrorLog":
                    ErrorLog();
                    break;
                case "Sync":
                    SyncCommandHandler();
                    break;
                case "Async":
                    AsyncCommandHandler();
                    break;
                default:
                    break;
            }
        });

        private void TestLog()
        {
            logger.Trace(new { key = Guid.NewGuid().ToString("N"), message = "this is a test message." });
        }

        private void ErrorLog()
        {
            try
            {
                throw new ArgumentException("test error.");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private bool isEnable = true;

        public bool IsEnable
        {
            get => isEnable;
            set => SetProperty(ref isEnable, value);
        }

        public DelegateCommand<object> SyncCommand => new DelegateCommand<object>(p =>
        {
            IsEnable = false;

            Task.Delay(3000).Wait();

            IsEnable = true;
        }).ObservesProperty(() => IsEnable);

        private async void AsyncHnadler(object arg)
        {
            IsEnable = false;

            await Task.Delay(3000);

            IsEnable = true;
        }

        public DelegateCommand<object> AsyncCommand => new DelegateCommand<object>(AsyncHnadler).ObservesCanExecute(() => IsEnable);

        private void SyncCommandHandler()
        {

        }

        private void AsyncCommandHandler()
        {

        }
    }
}
