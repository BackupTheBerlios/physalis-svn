using System;
using System.Collections;
using System.IO;

namespace Physalis.Framework
{
    public delegate void BundleEventHandler(object sender, BundleEventArgs e);
    public delegate void FrameworkEventHandler(object sender, FrameworkEventArgs e);
    public delegate void ServiceEventHandler(object sender, ServiceEventArgs e);
    
    /// <summary>
	/// A bundle's execution context within the Framework. 
	/// The context is used to grant access to other methods 
	/// so that this bundle can interact with the Framework.
	/// </summary>
	public interface IBundleContext
	{
        IProperty Property
        {
            get;
        }

        IBundle Bundle
        {
            get;
        }

        IFilter CreateFilter(string filter);
        IBundle GetBundle(Int32 id);
        IBundle[] GetBundles();
        File GetDataFile(string name);
        object GetService(IServiceReference reference);
        IServiceReference GetServiceReference(string theClass);
        IServiceReference[] GetServiceReferences(string theClass, string filter);
        IBundle InstallBundle(string location, Stream source);
        IServiceRegistration RegisterService(string theClass, object service, IDictionary properties);
        IServiceRegistration RegisterService(string[] classes, object service, IDictionary properties);
        bool UngetService(IServiceReference reference);

        event BundleEventHandler BundleEvent;
        event FrameworkEventHandler FrameworkEvent;
        event ServiceEventHandler ServiceEvent;
    }
}
