using System;
using System.IO;
using Physalis.Framework.Storage;
using Physalis.Specs.Framework;

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
        private Namespaces namespaces;
        private IBundle system;
        #endregion
        
        public Framework()
		{
            storage  = new BundleStorage();
            data = new DirectoryInfo(DATA_STORAGE);
            namespaces = new Namespaces();
//            system = new SystemBundle();
        }
	}
}
