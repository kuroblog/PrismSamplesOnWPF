
namespace Prism.Ex.App.Shell
{
    using Prism.Ex.App.Common;
    using Prism.Ioc;
    using Prism.Modularity;
    using Prism.Unity;
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;

    // default App.xaml.cs
    //public partial class App : Application { }

    // prism App.xaml.cs
    // 继承 PrismApplication 来替代默认的 Application
    // 必须重写 RegisterTypes 和 CreateShell 这2个方法
    [ExcludeFromCodeCoverage]
    public partial class App : PrismApplication
    {
        // 必须重写
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellView>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //return base.CreateModuleCatalog();

            //return new DirectoryModuleCatalog { ModulePath = config.ModuleDirectory };

            return new LimitedModuleCatalog { ModulePath = config.ModuleDirectory };
        }

        // 必须重写
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ShellConfig>();
        }

        private Action<object> WriteLog = (obj) => Console.WriteLine(obj);

        private readonly ShellConfig config = new ShellConfig();

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose;

                // 处理 UI 线程抛出且没有处理的异常
                DispatcherUnhandledException += DispatcherUnhandledExceptionHandler;

                // 处理非 UI 线程抛出且没有处理的异常
                AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledExceptionHandler;

                // 处理 Task 线程中抛出且没有处理的异常
                TaskScheduler.UnobservedTaskException += TaskSchedulerUnobservedTaskExceptionHandler;

                config.SetDisplayLanguage();

                base.OnStartup(e);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        // UI 线程异常处理
        private void DispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            WriteLog(e.Exception);

            // 处理并设置 Handler 防止异常继续抛出
            e.Handled = true;
        }

        // 非 UI 线程异常处理
        private void AppDomainUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            WriteLog(e.ExceptionObject);

            // 参数 e 没有提供 Handler 属性来阻止异常的继续抛出，这将导致程序最终会自动退出
            // 可以通过以下方法来防止该情况的发生
            // 方法一：
            // 修改配置文件 App.config 的 runtime 节点，添加 legacyUnhandledExceptionPolicy 节点，并设置 enabled 的值为 true
            // https://docs.microsoft.com/zh-cn/dotnet/framework/configure-apps/file-schema/runtime/legacycorruptedstateexceptionspolicy-element?view=netframework-4.8
            // or
            // 方法二：
            // 使用 HandledProcessCorruptedStateExceptions 特性
            // https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.exceptionservices.handleprocesscorruptedstateexceptionsattribute?view=netframework-4.8
        }

        // Task 线程异常处理
        private void TaskSchedulerUnobservedTaskExceptionHandler(object sender, UnobservedTaskExceptionEventArgs e)
        {
            WriteLog(e.Exception);

            // 处理并设置 Observed 防止异常继续抛出
            e.SetObserved();
        }

        //// 必须在 View 中使用 prism:ViewModelLocator.AutoWireViewModel="True" 来启用 View 和 ViewModel 的自动绑定
        //// 重写这个方法可以覆盖原来的绑定规则（XxxView => XxxViewModel）
        //// 除此之外也可以在 IModule 的实现类里的 OnInitialized 方法中直接注册 View 和 ViewModel 
        //protected override void ConfigureViewModelLocator()
        //{
        //    base.ConfigureViewModelLocator();

        //    // 默认: XxxView => XxxViewModel
        //    Mvvm.ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
        //    {
        //        var vName = viewType.Name;
        //        var assembly = viewType.GetTypeInfo().Assembly;

        //        var vmName = $"{assembly.GetName().Name}.ViewModels.{vName}Model, {assembly.FullName}";
        //        return Type.GetType(vmName);
        //    });
        //}
    }
}
