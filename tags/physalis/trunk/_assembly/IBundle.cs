using System;

namespace Physalis.Specs.Framework
{
    /// <summary>
    /// Summary description for Class1
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

        void Start();

        void Stop();

        void Uninstall();
    }
}
