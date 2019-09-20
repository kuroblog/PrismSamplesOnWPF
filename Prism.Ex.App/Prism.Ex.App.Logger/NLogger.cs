
namespace Prism.Ex.App.Logger
{
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    public class NLogger : ILogger
    {
        public async Task Trace<TData>(TData data) => await NLogWrapper.Instance.Trace(data);

        public async Task Debug<TData>(TData data) => await NLogWrapper.Instance.Debug(data);

        public async Task Info<TData>(TData data) => await NLogWrapper.Instance.Info(data);

        public async Task Error<TData>(TData data) => await NLogWrapper.Instance.Error(data);

        public async Task Fatal<TData>(TData data) => await NLogWrapper.Instance.Fatal(data);
    }

    public class NLogWrapper
    {
        private NLogWrapper() { }

        private static readonly Lazy<NLogWrapper> instance = new Lazy<NLogWrapper>(() => new NLogWrapper());

        public static NLogWrapper Instance => instance.Value;

        protected virtual NLog.Logger Logger => NLog.LogManager.GetCurrentClassLogger();

        protected virtual string GetJsonString<TData>(TData data) => JsonConvert.SerializeObject(data);

        public virtual async Task Trace<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Trace(GetJsonString(data)));

        public virtual async Task Debug<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Debug(GetJsonString(data)));

        public virtual async Task Info<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Info(GetJsonString(data)));

        public virtual async Task Error<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Error(GetJsonString(data)));

        public virtual async Task Fatal<TData>(TData data) => await Task.Factory.StartNew(() => Logger.Fatal(GetJsonString(data)));
    }
}
