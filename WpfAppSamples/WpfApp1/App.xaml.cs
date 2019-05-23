
namespace WpfApp1
{
    using Prism.Ioc;
    using Prism.Mvvm;
    using Prism.Unity;
    using System;
    using System.Reflection;
    using System.Windows;
    using Unity;

    // Inherit PrismApplication needs to refactor App.xaml
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // MainWindow does not  need to register
            //containerRegistry.RegisterForNavigation<MainWindow>(nameof(MainWindow));
            // Registration view
            containerRegistry.RegisterForNavigation<UserControls.CommandList>(nameof(UserControls.CommandList));
            containerRegistry.RegisterForNavigation<UserControls.PersonMain>(nameof(UserControls.PersonMain));
            containerRegistry.RegisterForNavigation<UserControls.TeamMain>(nameof(UserControls.TeamMain));

            // TODO: Test register method
            //containerRegistry.Register<ITest, Test>();
            //containerRegistry.RegisterSingleton<ITest, Test>();
            //containerRegistry.RegisterSingleton

            var di = containerRegistry.GetContainer();

            //containerRegistry.Register<IMsg, Msg>();
            containerRegistry.RegisterInstance<IMsg>(new Msg());

            //containerRegistry.Register<ITest, Test>();
            containerRegistry.RegisterInstance<ITest>(new Test(di.Resolve<IMsg>()));
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // Map view and view-model
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });
            // Another implementation
            //ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }
    }

    #region Test register method
    public interface ITest
    {
        string Id { get; }
    }

    public class Test : ITest
    {
        private IMsg msg;

        public Test(IMsg msg)
        {
            this.msg = msg;

            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; }

        public override string ToString()
        {
            return $"tid: {Id}; mid:{msg.Id}.";
        }
    }

    public interface IMsg
    {
        string Id { get; }
    }

    public class Msg : IMsg
    {
        public Msg()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; }
    }
    #endregion
}
