using System;
using System.ComponentModel;
using System.IO;
using Physalis.Specs.Framework;

namespace Physalis.Framework
{
    /// <summary>
    /// IBundleContext implementation
    /// </summary>
    internal class BundleContext : IBundleContext
    {
        #region --- Fields ---
        private IBundle bundle;
        private DirectoryInfo storage;
        #endregion

        #region --- Properties ---
        public IBundle Bundle
        {
            get
            {
                return bundle;
            }
        }
        public IBundle[] Bundles
        {
            get
            {
                IBundle[] bundles = new IBundle[Framework.Instance.Bundles.Count];
                Framework.Instance.Bundles.All.CopyTo(bundles, 0);
                return bundles;
            }
        }
        public event BundleEventHandler BundleEvent
        {
            add
            {
                EventManager.BundleEvent += value;
            }
            remove
            {
                EventManager.BundleEvent -= value;
            }
        }
        #endregion

        internal BundleContext(IBundle bundle, DirectoryInfo storage)
        {
            this.bundle = bundle;
            this.storage = storage;
        }

        public IBundle Install(string location)
        {
            return Framework.Instance.Install(location);
        }

        public IBundle GetBundle(Int32 id)
        {
            return Framework.Instance.Bundles[id];
        }

        public FileSystemInfo GetDataFile(string name)
        {
            if(bundle.State == BundleState.Installed)
            {
                throw new InvalidOperationException("The bundle has stopped");
            }
            
            if(name.Equals(" "))
            {
                return storage;
            }
            else
            {
                string path = storage.FullName;
                if(!name.StartsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    path += Path.DirectorySeparatorChar;
                }

                path += name;

                return new FileInfo(path);
            }
        }
    }
}