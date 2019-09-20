
namespace Prism.Ex.App.Logger
{
    public interface ILogger
    {
        void Trace<TData>(TData data);

        void Debug<TData>(TData data);

        void Info<TData>(TData data);

        void Error<TData>(TData data);

        void Fatal<TData>(TData data);
    }
}
