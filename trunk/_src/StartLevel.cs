using System;
using Physalis.Specs.Service.StartLevel;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
	public class StartLevel : IStartLevel
	{
        #region --- Constants ---
        internal static readonly string NAMESPACE_NAME = "Physalis.Specs.Service.StartLevel";
        internal static readonly string NAMESPACE_VERSION = "0.1";
        internal static readonly Int32 SYSTEM_BUNDLE_START_LEVEL = 0;
        #endregion

        public StartLevel()
		{
			// 
			// TODO: Add constructor logic here
			//
        }

        #region ---IStartLevel Members
        Int32 Physalis.Specs.Service.StartLevel.IStartLevel.StartLevel
        {
            get
            {
                // TODO:  Add StartLevel.Physalis.Specs.Service.StartLevel.IStartLevel.StartLevel getter implementation
                return new Int32 ();
            }
            set
            {
                // TODO:  Add StartLevel.Physalis.Specs.Service.StartLevel.IStartLevel.StartLevel setter implementation
            }
        }

        public Int32 InitialStartLevel
        {
            get
            {
                // TODO:  Add StartLevel.InitialStartLevel getter implementation
                return new Int32 ();
            }
            set
            {
                // TODO:  Add StartLevel.InitialStartLevel setter implementation
            }
        }

        public Int32 GetBundleStartLevel(Physalis.Specs.IBundle bundle)
        {
            // TODO:  Add StartLevel.GetBundleStartLevel implementation
            return new Int32 ();
        }

        public void SetBundleStartLevel(Physalis.Specs.IBundle bundle, Int32 startlevel)
        {
            // TODO:  Add StartLevel.SetBundleStartLevel implementation
        }

        public bool IsBundlePersistentlyStarted(Physalis.Specs.IBundle bundle)
        {
            // TODO:  Add StartLevel.IsBundlePersistentlyStarted implementation
            return false;
        }
        #endregion
    }
}
