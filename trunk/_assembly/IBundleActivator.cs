using System;

namespace Physalis.Specs.Framework
{
/// <summary>
/// Class to be implemented by bundles. The implementation of this interface is called
/// by the framework just after the bundle is loaded into the framework.
/// </summary>
	public interface IBundleActivator
	{
		void Start(IBundleContext context);
        void Stop(IBundleContext context);
    }
}
