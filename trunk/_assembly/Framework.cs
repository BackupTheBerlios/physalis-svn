using System;
using System.IO;
using System.Reflection;
using Physalis.Specs.Framework;
using Physalis.Utils;

namespace Physalis.Framework
{
	/// <summary>
	/// Main class of the Physalis framework. This class is internal, not accessible from outside the
	/// Physalis assembly.
	/// </summary>
	class Framework
    {
        #region --- Constant ---
        private static readonly string BUNDLE_ROOT = "Bundle";    
        #endregion

        #region --- Fields ---
        private Bundles bundles;
        private DirectoryInfo cache;
        #endregion

        #region --- Singleton ---
		public static readonly Framework Instance = new Framework();
		#endregion

        #region --- Properties ---
        internal Bundles Bundles
        {
            get
            {
                return bundles;
            }
        }
        internal DirectoryInfo Cache
        {
            get
            {
                return cache;
            }
            set
            {
                cache = value;
            }
        }
        #endregion

        private Framework()
		{
        }

        public void Start(string initial)
		{
            TracesProvider.TracesOutput.OutputTrace("Physalis framework cache: " + cache.FullName);

            if (bundles == null)
            {
                bundles = new Bundles();
            }
            else
            {
                throw new InvalidOperationException("The framework is already started");
            }

            TracesProvider.TracesOutput.OutputTrace("Loading initial bundle: " + initial);
            IBundle bundle = bundles.Add(initial, null);
            bundle.Start();
        }

        public void Stop()
        {
            for (Int32 i = bundles.Count - 1; i > -1; i--)
            {
                TracesProvider.TracesOutput.OutputTrace("Stopping: " + bundles[i].Location);
                bundles[i].Stop();
            }
        }

        public IBundle Install(string location)
        {
            // Create the private storage folder for the bundle
            DirectoryInfo folder = new DirectoryInfo(cache.FullName + Path.DirectorySeparatorChar + BUNDLE_ROOT + bundles.Count);

            IBundle bundle = bundles.Add(location, folder);
            return bundle;
        }
    }
}
