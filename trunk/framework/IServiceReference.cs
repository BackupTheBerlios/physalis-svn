using System;

namespace Physalis.Specs
{
	/// <summary>
	/// 
	/// </summary>
	public interface IServiceReference
	{
        string[] Keys
        {
            get;
        }

        IBundle Bundle
        {
            get;
        }

        IProperty Property
        {
            get;
        }

        IBundle[] GetUsingBundles();
    }
}
