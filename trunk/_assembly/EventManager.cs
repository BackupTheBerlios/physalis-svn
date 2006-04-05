using System;
using System.ComponentModel;
using Physalis.Specs.Framework;

namespace Physalis.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    internal class EventManager
    {
        #region --- Fields ---
        private static EventHandlerList events;
        private static readonly object bundlekey = new object();
        private static readonly object servicekey = new object();
        #endregion

        #region --- Event management ---
        internal static event BundleEventHandler BundleEvent
        {
            add
            {
                events.AddHandler(bundlekey, value);
            }
            remove
            {
                events.RemoveHandler(bundlekey, value);
            }
        }

        internal static void OnBundleChanged(BundleEventArgs e)
        {
            if(events[bundlekey] != null)
            {
                BundleEventHandler handler = events[bundlekey] as BundleEventHandler;
                handler(null, e);
            }
        }

        internal static event ServiceEventHandler ServiceEvent
        {
            add
            {
                events.AddHandler(servicekey, value);
            }
            remove
            {
                events.RemoveHandler(servicekey, value);
            }
        }

        internal static void OnServiceChanged(ServiceEventArgs e)
        {
            if(events[servicekey] != null)
            {
                ServiceEventHandler handler = events[servicekey] as ServiceEventHandler;
                handler(null, e);
            }
        }
        #endregion

        static EventManager()
        {
            events = new EventHandlerList();
        }
    }
}
