using System;
using System.Collections;

namespace Physalis.Framework
{
	/// <summary>
	/// 
	/// </summary>
	public interface IFilter
	{
        bool Match(IServiceReference reference);

        bool Match(IDictionary dictionary);

        string ToString();

        bool Equals(object obj);

        Int32 GetHashCode();
    }
}