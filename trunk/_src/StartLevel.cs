using System;
using Physalis.Service.StartLevel;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
	public class StartLevel : IStartLevel
	{
        #region --- Constants ---
        internal static readonly string NAMESPACE_NAME = "Physalis.Service.StartLevel";
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
        Int32 Physalis.Service.StartLevel.IStartLevel.StartLevel
        {
            get
            {
                // TODO:  Add StartLevel.Physalis.Service.StartLevel.IStartLevel.StartLevel getter implementation
                return new Int32 ();
            }
            set
            {
                // TODO:  Add StartLevel.Physalis.Service.StartLevel.IStartLevel.StartLevel setter implementation
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

        public Int32 GetBundleStartLevel(Physalis.Framework.IBundle bundle)
        {
            // TODO:  Add StartLevel.GetBundleStartLevel implementation
            return new Int32 ();
        }

        public void SetBundleStartLevel(Physalis.Framework.IBundle bundle, Int32 startlevel)
        {
            // TODO:  Add StartLevel.SetBundleStartLevel implementation
        }

        public bool IsBundlePersistentlyStarted(Physalis.Framework.IBundle bundle)
        {
            // TODO:  Add StartLevel.IsBundlePersistentlyStarted implementation
            return false;
        }
        #endregion
    }
}
