
namespace PEF.Shell
{
    using PEF.Common;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Unity;
    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows;

    public partial class App : PrismApplication
    {
        #region PrismApplication
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILogger, Logger>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var vName = viewType.FullName;
                var aName = viewType.GetTypeInfo().Assembly.FullName;
                var vmName = $"{vName}ViewModel, {aName}";
                return Type.GetType(vmName);
            });
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //return base.CreateModuleCatalog();

            return new DirectoryModuleCatalog { ModulePath = @".\Modules" };
        }
        #endregion

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += (obj, err) =>
            {
                Console.WriteLine(err);
            };

            AppDomain.CurrentDomain.UnhandledException += (obj, err) =>
            {
                Console.WriteLine(err);
            };

            TaskScheduler.UnobservedTaskException += (obj, err) =>
            {
                Console.WriteLine(err);
            };
        }
    }
}
