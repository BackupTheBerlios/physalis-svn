using System;

namespace Physalis.Specs
{
	/// <summary>
	/// 
	/// </summary>
	public interface IProperty
	{
        object this[string key]
        {
            get;
        }
    }
}
