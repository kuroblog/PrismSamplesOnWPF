
namespace WpfApp2.Assets
{
    using System.Diagnostics;
    using System.Threading;

    public static class DumpExtensions
    {
        public static void Dump<TObject>(this TObject obj)
        {
            Debug.WriteLine(new { id = Thread.CurrentThread.ManagedThreadId, obj });
        }
    }
}
