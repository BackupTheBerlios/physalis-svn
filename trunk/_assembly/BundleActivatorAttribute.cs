using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Attribute to be specified for each Physalis bundle to specify
    /// which class is the bundle activator.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class BundleActivatorAttribute : Attribute
    {
        private string activator;

        public string Activator
        {
            get
            {
                return activator;
            }
        }

        public BundleActivatorAttribute(string activator)
        {
            this.activator = activator;
        }
    }
}
