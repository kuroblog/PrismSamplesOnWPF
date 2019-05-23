
namespace WpfApp1.UserControls
{
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public partial class PersonMainViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        public PersonMainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public DelegateCommand<string> NavigationReturnCommand => new DelegateCommand<string>(p =>
        {
            regionManager.RequestNavigate("MainRegion", nameof(CommandList));
        });

        private string testValue;

        public string TestValue
        {
            get { return testValue; }
            set { SetProperty(ref testValue, value); }
        }

        public DelegateCommand<object> TestSyncCommand => new DelegateCommand<object>(p =>
        {
            IsEnable = false;

            TestValue = "begin ...";
            Task.Delay(3000).Wait();
            TestValue = Guid.NewGuid().ToString("N");

            IsEnable = true;
        }).ObservesProperty(() => IsEnable);

        private bool isEnable = true;

        public bool IsEnable
        {
            get { return isEnable; }
            set { SetProperty(ref isEnable, value); }
        }

        private async void TestAsyncHandler(object args)
        {
            IsEnable = false;

            TestValue = "begin ...";
            await Task.Delay(3000);
            TestValue = Guid.NewGuid().ToString("N");

            IsEnable = true;
        }

        //private bool CanTestAsyncHandler(object args)
        //{
        //    return IsEnable;
        //}

        //public DelegateCommand<object> TestAsyncCommand => new DelegateCommand<object>(TestAsyncHandler, CanTestAsyncHandler).ObservesProperty(() => IsEnable);
        // or
        public DelegateCommand<object> TestAsyncCommand => new DelegateCommand<object>(TestAsyncHandler).ObservesCanExecute(() => IsEnable);

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Trace.WriteLine(nameof(OnNavigatedTo));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Trace.WriteLine(nameof(IsNavigationTarget));

            var person = navigationContext.Parameters[nameof(PersonMain)] as string;

            return !string.IsNullOrEmpty(person);
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            Trace.WriteLine(nameof(OnNavigatedFrom));
        }
    }
}
