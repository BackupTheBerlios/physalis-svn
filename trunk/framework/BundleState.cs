using System;

namespace Physalis.Specs
{
	/// <summary>
	/// Summary description for State.
	/// </summary>
	public enum BundleState : int
	{
        Uninstalled = 1,
        Installed = 2,
        Resolved = 4,
        Starting = 8,
        Stopping = 16,
        Active = 32
	}
}
