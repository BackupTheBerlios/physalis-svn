using System;

namespace Physalis.Framework
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
