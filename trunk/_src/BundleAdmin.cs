using System;
using System.Collections;
using System.IO;
using Physalis.Framework;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class BundleAdmin
	{
        #region --- Constants ---
        internal static readonly Int32 SYSTEM_BUNDLE_ID = 0;

        private static readonly string BUNDLE_INFO_FILENAME = "bundles.properties";
        private static readonly string BUNDLES_DIR_NAME = "bundles";
        private static readonly string TEMP_FILE_EXT = ".tmp";
        private static readonly string BUNDLE_PREFIX_KEY = "bundle.";
        private static readonly string BUNDLE_LOCATION_SUFFIX_KEY = ".location";
        private static readonly string BUNDLE_STATE_SEPARATOR = "=";
        private static readonly string BUNDLE_START_LEVEL_SUFFIX_KEY = ".start.level";
        private static readonly string BUNDLE_IS_PERSISTENTLY_STARTED_SUFFIX_KEY = ".isPersistentlyStarted";
        private static readonly string FORMAT_VERSION_KEY = "format.version";
        private static readonly string NEXT_FREE_BUNDLE_ID_KEY = "next.free.bundle.id";
        private static readonly string INITIAL_BUNDLE_START_LEVEL_KEY = "initial.bundle.start.level";
        private static readonly Int32 FORMAT_VERSION = 2;
        // TODO: Check the best value
        private static readonly Int32 DEFAULT_MAP_SIZE = 53;
        #endregion

        #region --- Fields ---
        private DirectoryInfo bundlesFolder = null;
        private Int32 nextFreeBundleId = SYSTEM_BUNDLE_ID;
        private SystemBundle systemBundle = null;
        private Hashtable bundles = null;
        #endregion

        #region --- Properties ---
        public SystemBundle SystemBundle
        {
            get
            {
                return systemBundle;
            }
        }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BundleAdmin()
		{
            bundlesFolder = new DirectoryInfo(Framework.TheFramework.Cache.FullName + Path.DirectorySeparatorChar + BUNDLES_DIR_NAME);
            if(!bundlesFolder.Exists)
            {
                bundlesFolder.Create();
            }

            ++nextFreeBundleId;

            systemBundle = new SystemBundle();
            bundles = new Hashtable(DEFAULT_MAP_SIZE);
        }

        /// <summary>
        /// Saves the state of all bundles if the framework is active.
        /// </summary>
        internal void save()
        {
            if (systemBundle.State == BundleState.Active)
            {
                SaveUnconditionally();
            }
        }

        /// <summary>
        /// Saves unconditionally the state of all bundles, meaning that it is independent of the state of the framework.
        /// </summary>
        internal void SaveUnconditionally()
        {
            // TODO: Method to be synchronized

            string filename = bundlesFolder.FullName + Path.DirectorySeparatorChar + BUNDLE_INFO_FILENAME + TEMP_FILE_EXT;

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filename);
                Save(sw);
                sw.Flush();
            }
            finally
            {
                if(sw != null)
                {
                    try
                    {
                        sw.Close();
                    }
                    catch(Exception e)
                    {
                    }

                    // If we have successfully created the new bundle info file, we can delete the backup version
                    // and rename the new file to its standard name.
                    FileInfo topFile = new FileInfo(bundlesFolder.FullName + Path.DirectorySeparatorChar + BUNDLE_INFO_FILENAME);
                    topFile.Delete();
                    FileInfo tempTopFile = new FileInfo(filename);
                    tempTopFile.MoveTo(topFile.FullName);
                }
            }
        }

        /// <summary>
        /// Saves the state of all bundles using properties to an outputstream.
        /// </summary>
        /// <param name="props"></param>
        private void Save(StreamWriter sw)
        {
//            Properties bundleInfoProps = new Properties();

            IDictionaryEnumerator iterator = bundles.GetEnumerator();

            while (iterator.MoveNext())
            {
                Bundle bundle = (Bundle) iterator.Current;

                if (bundle.State != BundleState.Uninstalled)
                {
                    String baseKey = BUNDLE_PREFIX_KEY + bundle.Id;

                    sw.WriteLine(baseKey + BUNDLE_LOCATION_SUFFIX_KEY + BUNDLE_STATE_SEPARATOR + bundle.Location);
                    sw.WriteLine(baseKey + BUNDLE_START_LEVEL_SUFFIX_KEY + BUNDLE_STATE_SEPARATOR + bundle.StartLevel);
                    sw.WriteLine(baseKey + BUNDLE_IS_PERSISTENTLY_STARTED_SUFFIX_KEY + BUNDLE_STATE_SEPARATOR + bundle.IsPersistentlyStarted);
//                    bundleInfoProps.put(baseKey + BUNDLE_LOCATION_SUFFIX_KEY, bundle.getLocationUnchecked());
//                    bundleInfoProps.put(baseKey + BUNDLE_START_LEVEL_SUFFIX_KEY, String.valueOf(bundle.getStartLevel()));
//                    bundleInfoProps.put(baseKey + BUNDLE_IS_PERSISTENTLY_STARTED_SUFFIX_KEY, String.valueOf(bundle.isPersistentlyStarted()));
                }
            }


            sw.WriteLine(FORMAT_VERSION_KEY + BUNDLE_STATE_SEPARATOR + FORMAT_VERSION.ToString());
            sw.WriteLine(NEXT_FREE_BUNDLE_ID_KEY + BUNDLE_STATE_SEPARATOR + nextFreeBundleId.ToString());
            sw.WriteLine(INITIAL_BUNDLE_START_LEVEL_KEY + BUNDLE_STATE_SEPARATOR + systemBundle.StartLevelAdmin.InitialStartLevel.ToString());
//            bundleInfoProps.put(FORMAT_VERSION_KEY, FORMAT_VERSION.ToString());
//            bundleInfoProps.put(NEXT_FREE_BUNDLE_ID_KEY, String.valueOf(nextFreeBundleId));
//            bundleInfoProps.put(INITIAL_BUNDLE_START_LEVEL_KEY, String.valueOf(getInitialBundleStartLevel()));

//            bundleInfoProps.save(props, null);
        }
    }
}
