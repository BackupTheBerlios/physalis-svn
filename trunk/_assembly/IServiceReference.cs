using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public interface IServiceReference
    {
        IBundle Bundle
        {
            get;
        }

        object this[string key]
        {
            get;
        }

        string[] Keys
        {
            get;
        }

        IBundle[] Using
        {
            get;
        }
    }
}
