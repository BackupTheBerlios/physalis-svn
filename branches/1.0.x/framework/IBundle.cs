using System;
using System.Collections;

namespace Physalis.Framework
{
	/// <summary>
	/// Summary description for IBundle.
	/// </summary>
	public interface IBundle
	{
		BundleState State
		{
			get;
		}

		Int32 Id
		{
			get;
		}

		string Location
		{
			get;
		}

        IDictionary Headers
        {
            get;
        }

        IServiceReference[] RegisteredServices
        {
            get;
        }

        IServiceReference[] ServicesInUse
        {
            get;
        }

        void Start();
		void Stop();
		void Update();
		void Uninstall();
        string GetResource(string name);

        // TODO - hasPermission
        // TODO - update(Input Stream)
	}
}
