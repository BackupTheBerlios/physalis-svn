using System;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class Bundle : ABundle
	{
        #region --- Properties ---
        public override Manifest Manifest
        {
            get
            {
                // TODO: To be done.
                return null;
            }
        }
        #endregion
        
        public Bundle(string location, Int32 id, Int32 level, bool isPersistentlyStarted, Storage storage)
            : base(location, id, level, isPersistentlyStarted)
		{
			// 
			// TODO: Add constructor logic here
			//
		}
	}
}
