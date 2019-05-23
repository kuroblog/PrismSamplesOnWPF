
namespace WpfApp2.Assets
{
    using Prism.Events;

    public class MainNotificationBody
    {
        public string Title { get; set; } = "Main Notification";

        public string Message { get; set; }
    }

    public class MainNotificationEvent : PubSubEvent<MainNotificationBody> { }
}
