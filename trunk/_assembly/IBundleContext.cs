using System;
using System.IO;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Physalis framework proxy for a bundle.
    /// </summary>
    public interface IBundleContext
    {
        /// <summary>
        /// Bundle associated with this context. There is one IBundleContext object
        /// for each bundle started in the framework.
        /// </summary>
        /// <value></value>
        IBundle Bundle
        {
            get;
        }

        /// <summary>
        /// Get all bundles installed in the framework.
        /// </summary>
        /// <value>The bundle list.</value>
        IBundle[] Bundles
        {
            get;
        }

        /// <summary>
        /// Install a bundle given its location.
        /// </summary>
        /// <param name="location">Path of the bundle to be intalled.</param>
        /// <returns>The new created IBundle object.</returns>
        IBundle Install(string location);

        /// <summary>
        /// Get the IBundle which has the given ID.
        /// </summary>
        /// <param name="id">The ID of the IBundle to be retrieved.</param>
        /// <returns>The IBundle object associated with the given ID.</returns>
        IBundle GetBundle(Int32 id);

        /// <summary>
        /// Return a file object pointing to the given file name in the bundle dedicated persistent storage.
        /// If the given name is " ", the returned object is a DirectoryInfo pointing to the bundle storage root
        /// folder.
        /// </summary>
        /// <param name="name">The file name</param>
        /// <returns>The file object</returns>
        FileSystemInfo GetDataFile(string name);

        /// <summary>
        /// Event raised when a bundle transition occurs.
        /// </summary>
        event BundleEventHandler BundleEvent;
    }
}
