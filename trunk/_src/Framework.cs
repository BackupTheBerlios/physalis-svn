using System;
using System.IO;
using Physalis.Framework.Storage;

namespace Physalis.Framework
{
	/// <summary>
	/// Summary description for Framework.
	/// </summary>
	public class Framework
	{
        #region --- Constants ---
        private const string DATA_STORAGE = "data";
        #endregion

        #region --- Fields ---
        private IBundleStorage storage;
        private DirectoryInfo data;
        #endregion
        
        public Framework()
		{
            storage  = new BundleStorage();
            data = new DirectoryInfo(DATA_STORAGE);
        }
	}
}
