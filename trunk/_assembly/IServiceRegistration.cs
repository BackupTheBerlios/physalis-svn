using System;
using System.Collections;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Service registration is returned when a service is registered. For private use only.
    /// </summary>
    public interface IServiceRegistration
    {
        /// <summary>
        /// <seealso cref="IServiceReference"/> associated with the service and this registration.
        /// </summary>
        IServiceReference Reference
        {
            get;
        }

        /// <summary>
        /// Set the properties of the service being registered.
        /// </summary>
        IDictionary Properties
        {
            set;
        }

        /// <summary>
        /// Unregister the service associated with this registration.
        /// </summary>
        void Unregister();
    }
}
