
namespace WpfApp1.UserControls
{
    using Prism.Interactivity.InteractionRequest;
    using System;
    using System.Windows.Controls;

    public partial class CustomPopup : UserControl, IInteractionRequestAware
    {
        public CustomPopup()
        {
            InitializeComponent();
        }

        public INotification Notification { get; set; }

        public Action FinishInteraction { get; set; }

        private void AcceptClick(object sender, System.Windows.RoutedEventArgs e)
        {
            FinishInteraction?.Invoke();
        }
    }
}
