using System;
using System.IO;
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
                return (bundles == null) ? null : (IBundle) bundles[id];
            }
        }
        internal IBundle this[string location]
        {
            get
            {
                IBundle bundle = null;

                if(bundles != null)
                {
                    ICollection all = bundles.Values;
                    IEnumerator enumerator = all.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if(((IBundle) enumerator.Current).Location.Equals(location))
                        {
                            bundle = (IBundle) enumerator.Current;
                            break;
                        }
                    }
                }

                return bundle;
            }
        }
        internal ICollection All
        {
            get
            {
                return (bundles == null) ? null : bundles.Values;
            }
        }
        #endregion

        public Bundles()
        {
        }

        /// <summary>
        /// Create, install and add the new bundle to the list.
        /// </summary>
        /// <param name="location">The location of the bundle object</param>
        /// <param name="filepath">The path for the bundle private file storage</param>
        /// <returns>The new created bundle object</returns>
        public IBundle Add(string location, DirectoryInfo storage)
        {
            if((location == null) || (location.Equals("")))
            {
                throw new ArgumentNullException();
            }

            if(bundles == null)
            {
                bundles = new Hashtable(10);
            }

            // Null storage path is allowed only for the initial bundle
            if((storage == null) && (bundles.Count > 0))
            {
                throw new BundleException("Storage can't be null for non initial bundle");
            }

            // Verify there is no already bundle with the same location
            if(this[location] != null)
            {
                throw new BundleException("A bundle has already been installed with the location: " + location);
            }

            // Create the bundle object
            IBundle newBundle = new Bundle(bundles.Count, location, storage);
            bundles.Add(newBundle.Id, newBundle);
            return newBundle;
        }
    }
}
