using System;
using System.Collections;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public interface IServiceRegistration
    {
        IServiceReference Reference
        {
            get;
        }

        IDictionary Properties
        {
            set;
        }

        void Unregister();
    }
}
