
namespace Prism.Ex.App.Logger
{
    using System;
    using System.Threading.Tasks;

    public class NLogWrapper
    {
        private NLogWrapper() { }

        private static readonly Lazy<NLogWrapper> instance = new Lazy<NLogWrapper>(() => new NLogWrapper());

        public static NLogWrapper Instance => instance.Value;

        protected virtual NLog.Logger Logger => NLog.LogManager.GetCurrentClassLogger();

        public virtual async void Trace<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Trace(data));

        public virtual async void Debug<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Debug(data));

        public virtual async void Info<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Info(data));

        public virtual async void Error<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Error(data));

        public virtual async void Fatal<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Fatal(data));
    }
}
