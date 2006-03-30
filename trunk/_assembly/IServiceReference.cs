using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Service reference
    /// </summary>
    public interface IServiceReference
    {
        /// <summary>
        /// Bundle which has registered the service.
        /// </summary>
        IBundle Bundle
        {
            get;
        }

        /// <summary>
        /// Service property associated with the given key in the dictionnary.
        /// </summary>
        /// <param name="key">Property key</param>
        /// <returns>The corresponding property object, null if there is no property with the given key.</returns>
        object this[string key]
        {
            get;
        }

        /// <summary>
        /// Returns all the property keys associated with the service.
        /// </summary>
        string[] Keys
        {
            get;
        }

        /// <summary>
        /// Returns the list of bundles which are using the service.
        /// </summary>
        IBundle[] Using
        {
            get;
        }
    }
}
