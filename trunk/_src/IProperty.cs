using System;

namespace Physalis.Specs.Framework
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
