
namespace WpfApp1.UserControls
{
    using Prism.Commands;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Mvvm;
    using System;

    public partial class CustomRequestViewModel : BindableBase, IInteractionRequestAware
    {
        public string SelectedItem { get; set; }

        private ICustomNotification customNotification;

        public INotification Notification
        {
            get { return customNotification; }
            set { SetProperty(ref customNotification, (ICustomNotification)value); }
        }

        public Action FinishInteraction { get; set; }

        public DelegateCommand SelectItemCommand => new DelegateCommand(() =>
        {
            customNotification.SelectedItem = SelectedItem;
            customNotification.Confirmed = true;
            FinishInteraction?.Invoke();
        });

        public DelegateCommand CancelCommand => new DelegateCommand(() =>
        {
            customNotification.SelectedItem = null;
            customNotification.Confirmed = false;
            FinishInteraction?.Invoke();
        });
    }
}
