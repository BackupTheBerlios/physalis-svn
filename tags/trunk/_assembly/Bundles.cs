using System;
using System.Collections;
using Physalis.Specs.Framework;

namespace Physalis.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    internal class Bundles
    {
        #region --- Fields ---
        /// <summary>
        /// Stores the list of the bundles. The key is the bundle id. Only assemblies recognized 
        /// as bundles with a IBundleActivator class are stored here.
        /// </summary>
        private IDictionary bundles;
        #endregion

        #region --- Properties ---
        internal Int32 Count
        {
            get
            {
                return (bundles == null) ? 0 : bundles.Count;
            }
        }
        internal IBundle this[Int32 id]
        {
            get
            {
                return (IBundle) bundles[id];
            }
        }
        #endregion

        public Bundles()
        {
        }

        /// <summary>
        /// Create and add the new bundle to the list.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The new created bundle object</returns>
        public IBundle Add(string path)
        {
            if((path == null) || path.Equals(""))
            {
                throw new ArgumentNullException();
            }

            if(bundles == null)
            {
                bundles = new Hashtable(10);
            }

            // Create the bundle object
            IBundle newBundle = new Bundle(bundles.Count, path);

            // Verify there is no already bundle with the same location
            ICollection all = bundles.Values;
            IEnumerator enumerator = all.GetEnumerator();
            while(enumerator.MoveNext())
            {
                IBundle bundle = (IBundle)enumerator.Current;
                if (bundle.Location.Equals(newBundle.Location))
                {
                    throw new BundleException("A bundle has already been installed with the location: " + newBundle.Location);
                }
            }

            bundles.Add(newBundle.Id, newBundle);
            return newBundle;
        }
    }
}
