
namespace PEF.Common
{
    using Newtonsoft.Json;
    using System;
    using System.Threading;

    public interface ILogger
    {
        void Dump<TObj>(TObj obj, bool isFormat = false);
    }

    public class Logger : ILogger
    {
        public void Dump<TObj>(TObj obj, bool isFormat = false)
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            var time = DateTime.Now;
            var message = JsonConvert.SerializeObject(new
            {
                id,
                time,
                data = obj
            }, isFormat ? Formatting.Indented : Formatting.None);

            Console.WriteLine(message);
        }
    }
}
