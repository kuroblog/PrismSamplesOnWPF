
namespace WpfApplication1
{
    using Microsoft.Practices.Unity;
    using Prism.Regions;
    using System.Windows;
    using Views;

    public partial class ShellWindow : Window
    {
        public ShellWindow(IUnityContainer container, IRegionManager regionManager)
        {
            InitializeComponent();

            this.container = container;
            this.regionManager = regionManager;

            Loaded += (sender, e) =>
            {
                viewa = container.Resolve<ViewA>();
                viewb = container.Resolve<ViewB>();

                region = regionManager.Regions["ContentRegion"];

                region.Add(viewa);
                region.Add(viewb);
            };
        }

        IUnityContainer container;
        IRegionManager regionManager;

        ViewA viewa;
        ViewB viewb;

        IRegion region;

        private void LoadViewAHandler(object sender, RoutedEventArgs e)
        {
            region.Activate(viewa);
        }

        private void LoadViewBHandler(object sender, RoutedEventArgs e)
        {
            region.Activate(viewb);
        }

        private void UnloadViewAHandler(object sender, RoutedEventArgs e)
        {
            region.Deactivate(viewa);
        }

        private void UnloadViewBHandler(object sender, RoutedEventArgs e)
        {
            region.Deactivate(viewb);
        }
    }
}
