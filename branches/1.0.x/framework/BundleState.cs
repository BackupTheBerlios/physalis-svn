using System;

namespace Physalis.Framework
{
	/// <summary>
	/// Defines bundle's states.
	/// </summary>
	public enum BundleState : int
	{
		/// <summary>
		/// This bundle is uninstalled and may not be used.
		/// </summary>

		Uninstalled = 1,
        
		/// <summary>
		/// This bundle is installed but not yet resolved.
		/// </summary>
		
		Installed = 2,

		/// <summary>
		/// This bundle is resolved and is able to be started.
		/// </summary>

		Resolved = 4,
        
		/// <summary>
		/// This bundle is in the process of starting.
		/// </summary>

		Starting = 8,
        
		/// <summary>
		/// This bundle is in the process of stopping.
		/// </summary>

		Stopping = 16,
        
		/// <summary>
		/// This bundle is now running.
		/// </summary>

		Active = 32
	}
}
