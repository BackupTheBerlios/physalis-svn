using System;

namespace Physalis.Specs
{
	/// <summary>
	/// See <see cref="org.osgi.framework.BundleActivator"/>
	/// </summary>
	public interface IBundleActivator
	{
		void Start(IBundleContext context);
		void Stop(IBundleContext context);
	}
}
