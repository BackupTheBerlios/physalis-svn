using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using Physalis.Utils;

namespace Physalis.Framework
{
	/// <summary>
	/// Physalis entry point. Is a singleton.
	/// </summary>
	public class Starter
	{
        #region --- Constants ---
        private static readonly string CACHE_NAME = "cache";
        #endregion

        #region --- Fields ---
        #endregion

        #region --- Properties ---
        /// <summary>
        /// Return the Physalis assembly version.
        /// </summary>
        /// <returns>The Physalis version as string</returns>
        private static string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        #endregion

        private Starter()
		{
		}

        /// <summary>
        /// Start Physalis here and loads the bundles provided in the given list. If an exception occurs
        /// when loading a bundle from this list, the startup procedure is immediately stopped.
        /// </summary>
        /// <param name="path">The root path where Physalis is going to store its cache and private storage space.</param>
        /// <param name="reset">true to reset the cache, false otherwise</param>
        /// <param name="initial">Full path of the initial bundle to be started. This bundle won't be copied into the Physalis cache.</param>
        public static void Start(string path, bool reset, string initial)
        {
            TracesProvider.TracesOutput.OutputTrace("Physalis is starting...");
            TracesProvider.TracesOutput.OutputTrace(String.Format("Physalis framework, version {0}\nCopyright 2004 Physalis. All Rights Reserved.\nSee http://physalis.berlios.de for more information.\n", Version));

            TracesProvider.TracesOutput.OutputTrace("Given parameters are:\n");
            TracesProvider.TracesOutput.OutputTrace("Path: " + path + "\n");
            TracesProvider.TracesOutput.OutputTrace("Reset cache: " + reset + "\n");

            Framework.Instance.Cache = InitializeCache(path, reset);
            Framework.Instance.Start(initial);
        }

        /// <summary>
        /// Initializes the Physalis cache folder.
        /// </summary>
        /// <param name="path">The root path where the cache will be stored</param>
        /// <param name="reset">true if the cache has to be resetted, false otherwise</param>
        /// <returns>The cache folder</returns>
        private static DirectoryInfo InitializeCache(string path, bool reset)
        {
            string cache = path + Path.DirectorySeparatorChar + CACHE_NAME;
            DirectoryInfo folder = new DirectoryInfo(cache);
            if(reset && folder.Exists)
            {
                folder.Delete(true);
            }

            folder.Create();
            return folder;
        }

        public static void Shutdown(int exitcode)
        {
            TracesProvider.TracesOutput.OutputTrace("Physalis is stopping...\n");
            Framework.Instance.Stop();
        }
    }
}
