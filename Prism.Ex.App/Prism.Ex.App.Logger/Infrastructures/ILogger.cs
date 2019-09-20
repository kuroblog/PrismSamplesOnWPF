
namespace Prism.Ex.App.Logger
{
    using System.Threading.Tasks;

    public interface ILogger
    {
        Task Trace<TData>(TData data);

        Task Debug<TData>(TData data);

        Task Info<TData>(TData data);

        Task Error<TData>(TData data);

        Task Fatal<TData>(TData data);
    }
}
