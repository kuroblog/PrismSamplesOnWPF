
namespace Prism.Ex.App.Asset
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    public class CleanLanguageForDesignTimeBehavior : Behavior<UserControl>
    {
        public string LanguageKey
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register(nameof(LanguageKey), typeof(string), typeof(CleanLanguageForDesignTimeBehavior), new PropertyMetadata("Languages"));

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += OnLoadedHandler;
        }

        private void OnLoadedHandler(object sender, RoutedEventArgs e)
        {
            var languageResources = AssociatedObject.Resources.MergedDictionaries?.ToList()?.Where(p => p.Source.OriginalString.ToLower().Contains(LanguageKey.ToLower()))?.ToList();
            languageResources?.ForEach(p => AssociatedObject.Resources.MergedDictionaries?.Remove(p));
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (AssociatedObject != null)
            {
                AssociatedObject.Loaded -= OnLoadedHandler;
            }
        }
    }
}
