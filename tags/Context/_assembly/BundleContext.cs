using System;
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
        #endregion

        public BundleContext(IBundle bundle)
        {
            this.bundle = bundle;
        }

        public IBundle Install(string location)
        {
            return Framework.Instance.Bundles.Add(location);
        }

        public IBundle GetBundle(Int32 id)
        {
            return Framework.Instance.Bundles[id];
        }
    }
}