# README

|Ver|Date|Author|Remark
|:-|:-:|:-|:-
|1.0|2019-09-16|kuro|created

## *References:*

---

Null

### Table of Contents

* [Issues](#Issues)
* [Chapter 2](#Chapter-2)

---

### Issues

---

1. WPF 异常处理

    ```csharp
    // 当应用程序引发但未处理异常时出现
    Application.DispatcherUnhandledException

    // 当某个异常未被捕获时出现
    AppDomain.CurrentDomain.UnhandledException

    // 要触发异常升级策略，它在默认情况下，会终止此进程出错的任务未观察到的异常时出现
    TaskScheduler.UnobservedTaskException
    ```

1. 使用异常

    * [ExceptionDispatchInfo](https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.exceptionservices.exceptiondispatchinfo?view=netframework-4.8)
    * [捕获并重新抛出异常](https://blog.walterlv.com/post/exceptiondispatchinfo-capture-throw.html)

1. 启用托管代码以处理用于指示损坏的进程状态的异常

    [HandleProcessCorruptedStateExceptionsAttribute](https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.exceptionservices.handleprocesscorruptedstateexceptionsattribute?view=netframework-4.8)

1. 指定公共语言运行时是否允许托管代码捕获访问冲突和其他损坏状态异常

    [legacyCorruptedStateExceptionsPolicy](https://docs.microsoft.com/zh-cn/dotnet/framework/configure-apps/file-schema/runtime/legacycorruptedstateexceptionspolicy-element?view=netframework-4.8)

1. 从 nuget 引用的 package 包导致 dll 版本冲突

    <span style="color:red">引用的包如果同时支持 .NETFramework 和 .NETStandard 就会出现这个问题</span>

1. ```LimitedModuleCatalog``` 的模块路径需要修改成外部传入

1. 改善 BusyIndicator 控件的显示和调用方式

### Chapter 2

---
