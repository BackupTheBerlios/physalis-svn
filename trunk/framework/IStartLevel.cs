using System;

namespace Physalis.Specs.Service.StartLevel
{
	/// <summary>
	/// 
	/// </summary>
	public interface IStartLevel
	{
        Int32 StartLevel
        {
            get;
            set;
        }

        Int32 InitialStartLevel
        {
            get;
            set;
        }

        Int32 GetBundleStartLevel(IBundle bundle);
        void SetBundleStartLevel(IBundle bundle, Int32 startlevel);

        bool IsBundlePersistentlyStarted(IBundle bundle);
    }
}
