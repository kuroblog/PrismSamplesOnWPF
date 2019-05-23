
namespace WpfApp2.PersonModule.UserControls
{
    using Prism.Commands;
    using Prism.Events;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Mvvm;
    using Prism.Regions;
    using WpfApp2.Assets;

    public partial class PersonViewModel : BindableBase, INavigationAware
    {
        public string Test { get; } = "This is person page.";

        public string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        private InteractionRequest<INotification> mainNotificationRequest;

        public PersonViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<PubSubEvent<InteractionRequest<INotification>>>().Subscribe(arg =>
            {
                mainNotificationRequest = arg;
            });
        }

        public DelegateCommand<string> NavigationCommand => new DelegateCommand<string>(viewName =>
        {
            //var parameters = new NavigationParameters();
            //parameters.Add(nameof(PersonMain), "hello, person.");

            //regionManager.RequestNavigate("MainRegion", nameof(PersonMain), parameters);

            regionManager.RequestNavigate("MainRegion", viewName);
        });

        public DelegateCommand PopupMainNotificationCommand => new DelegateCommand(() =>
        {
            eventAggregator.GetEvent<MainNotificationEvent>().Publish(new MainNotificationBody { Message = "This is a message from person page." });
            
            // This is wrong
            //mainNotificationRequest.Raise(new Notification { Content = "This is a message from person page.", Title = "person notification" }, r => Message = "Notified");
        });

        #region INavigationAware 
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            navigationContext.Dump();

            var personParam = navigationContext.Parameters[nameof(Person)] as string;

            personParam.Dump();
        }

        // Reference example: The 19-NavigationParticipation of Prism Samples on WPF
        // When the region-name of inject view is on the TabControl control, the view can be created multile times
        // So we can use this method to manage whether the view can be created multiple times
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
        #endregion
    }
}
