
namespace WpfApplication1
{
    using Microsoft.Practices.Unity;
    using Prism.Mvvm;
    using Prism.Unity;
    using System;
    using System.Reflection;
    using System.Windows;

    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// 使用 prism:ViewModelLocator.AutoWireViewModel="True" 的方法，必须遵循以下规则
        /// ViewModel 的名称必须是 View + ViewModel/View和ViewModel 最好安放到对应的目录 Views 和 ViewModels
        /// 比如：
        /// View：       ExampleView
        /// ViewModel：  ExampleViewViewModel
        /// 这里重写基类的该方法以达到改变自动匹配的规则
        /// </summary>
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });
        }
    }
}
