using System;
using System.Collections;

namespace Physalis.Framework
{
	/// <summary>
	/// 
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
