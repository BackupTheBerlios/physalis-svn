using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class BundleException : Exception
    {
        public BundleException(string message, Exception inner) : base(message, inner)
        {
        }

        public BundleException(string message) : base(message, null)
        {
        }
    }
}
