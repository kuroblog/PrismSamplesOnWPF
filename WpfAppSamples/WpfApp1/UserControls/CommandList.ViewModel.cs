
namespace WpfApp1.UserControls
{
    using Prism.Commands;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Ioc;
    using Prism.Mvvm;
    using Prism.Regions;
    using Prism.Unity;
    using System.Diagnostics;
    using System.Windows;
    using Unity;

    public partial class CommandListViewModel : BindableBase
    {
        private string title = "Hello, Prism";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private readonly IRegionManager regionManager;

        public InteractionRequest<INotification> NotificationRequest { get; } = new InteractionRequest<INotification>();

        public DelegateCommand NotificationCommand => new DelegateCommand(() =>
        {
            NotificationRequest.Raise(new Notification { Content = "Notification Message", Title = "Notification" }, r => Title = "Notified");
        });

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; } = new InteractionRequest<IConfirmation>();

        public DelegateCommand ConfirmationCommand => new DelegateCommand(() =>
        {
            ConfirmationRequest.Raise(new Confirmation
            {
                Title = "Confirmation",
                Content = "Confirmation Message"
            },
            r => Title = r.Confirmed ? "Confirmed" : "Not Confirmed");
        });

        public InteractionRequest<INotification> CustomPopupRequest { get; } = new InteractionRequest<INotification>();

        public DelegateCommand CustomPopupCommand => new DelegateCommand(() =>
        {
            CustomPopupRequest.Raise(new Notification { Title = "Custom Popup", Content = "Custom Popup Message " }, r => Title = "Good to go");
        });

        public InteractionRequest<ICustomNotification> CustomNotificationRequest { get; } = new InteractionRequest<ICustomNotification>();

        public DelegateCommand CustomNotificationCommand => new DelegateCommand(() =>
        {
            CustomNotificationRequest.Raise(new CustomNotification { Title = "Custom Notification" }, r =>
            {
                if (r.Confirmed && r.SelectedItem != null)
                    Title = $"User selected: { r.SelectedItem}";
                else
                    Title = "User cancelled or didn't select an item";
            });
        });

        public CommandListViewModel(IRegionManager regionManager, IUnityContainer containerRegistry)
        {
            this.regionManager = regionManager;

            var c1 = (Application.Current as PrismApplication).Container;
            var t1 = c1.Resolve<ITest>();

            var t2 = containerRegistry.Resolve<ITest>();

            var f1 = t1.Equals(t2);

            Trace.WriteLine($"t1 => {t1.ToString()}");
            Trace.WriteLine($"t2 => {t2.ToString()}");
            Trace.WriteLine(f1);
        }

        public DelegateCommand<string> NavigationPersonMainCommand => new DelegateCommand<string>(p =>
        {
            var parameters = new NavigationParameters();
            parameters.Add(nameof(PersonMain), "hello, person.");

            regionManager.RequestNavigate("MainRegion", nameof(PersonMain), parameters);
        });

        public DelegateCommand<string> NavigationTeamMainCommand => new DelegateCommand<string>(p =>
        {
            regionManager.RequestNavigate("MainRegion", nameof(TeamMain));
        });
    }
}
