
namespace PEF.Shell
{
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Mvvm;
    using Prism.Unity;
    using System;
    using System.Reflection;
    using System.Windows;

    public partial class App : PrismApplication
    {
        #region PrismApplication
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) { }

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
    }
}
