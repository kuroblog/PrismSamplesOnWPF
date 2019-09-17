
namespace Prism.Ex.App.Common
{
    using Prism.Events;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class EventAggregatorExtensions
    {
        public static void BusyIndicatorStateEventPublish(this IEventAggregator ea, bool state)
        {
            ea.GetEvent<BusyIndicatorStateEvent>().Publish(state);
        }

        public static void BusyIndicatorStateEventSubscribe(this IEventAggregator ea, Action<bool> method)
        {
            ea.GetEvent<BusyIndicatorStateEvent>().Subscribe(method);
        }
    }
}
