
namespace WpfApp1.UserControls
{
    using Prism.Interactivity.InteractionRequest;
    using System.Collections.Generic;
    using System.Windows.Controls;

    public partial class CustomRequest : UserControl
    {
        public CustomRequest()
        {
            InitializeComponent();
        }
    }

    public interface ICustomNotification : IConfirmation
    {
        string SelectedItem { get; set; }
    }

    public class CustomNotification : Confirmation, ICustomNotification
    {
        public IList<string> Items { get; private set; }

        public string SelectedItem { get; set; }

        public CustomNotification()
        {
            Items = new List<string>();
            SelectedItem = null;

            CreateItems();
        }

        private void CreateItems()
        {
            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
            Items.Add("Item5");
            Items.Add("Item6");
        }
    }
}
