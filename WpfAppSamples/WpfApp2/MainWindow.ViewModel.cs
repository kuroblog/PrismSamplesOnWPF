
namespace WpfApp2
{
    using Prism.Commands;
    using Prism.Events;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Mvvm;
    using WpfApp2.Assets;

    public partial class MainWindowViewModel : BindableBase
    {
        private string title = "prism demo";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public DelegateCommand<object> LoadedCommand => new DelegateCommand<object>(p =>
        {
            p.Dump();
        });

        private readonly IEventAggregator eventAggregator;

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<MainNotificationEvent>().Subscribe(arg =>
            {
                MainNotificationRequest.Raise(new Notification { Content = arg.Message, Title = arg.Title }, r => Title = "Notified");
            });

            // This is wrong
            //this.eventAggregator.GetEvent<PubSubEvent<InteractionRequest<INotification>>>().Publish(MainNotificationRequest);
        }

        public InteractionRequest<INotification> MainNotificationRequest { get; } = new InteractionRequest<INotification>();
    }
}
