
namespace Prism.Ex.App.Common
{
    using Prism.Ioc;
    using Prism.Mvvm;
    using Prism.Unity;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    [ExcludeFromCodeCoverage]
    public sealed class MainDispatcher : BindableBase
    {
        private static readonly Lazy<MainDispatcher> instance = new Lazy<MainDispatcher>(() => new MainDispatcher());

        public static MainDispatcher Value => instance.Value;

        private MainDispatcher() { }

        private readonly PrismApplication app = Application.Current as PrismApplication;

        public IContainerProvider Container => app.Container;

        //private bool isBusy = false;

        //public bool IsBusy
        //{
        //    get => isBusy;
        //    set => SetProperty(ref isBusy, value);
        //}

        //public void Invoke(Action action, DispatcherPriority priority = DispatcherPriority.Normal) => app.Dispatcher.BeginInvoke(priority, action);

        //public void ShowMessage(string message, string title = "温馨提示", Action<INotification> action = null)
        //{
        //    Container?.Resolve<IEventAggregator>()?.GetEvent<MainNotificationPopupEvent>()?.Publish(new PopupEventArg<INotification>
        //    {
        //        Title = title,
        //        Content = message,
        //        Callback = action
        //    });
        //}
    }
}
