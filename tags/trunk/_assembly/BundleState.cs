using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
        public enum BundleState : int
        {
            Uninstalled,
            Installed,
            // Not used
            Resolved,
            Starting,
            Stopping,
            Active
        }
}
