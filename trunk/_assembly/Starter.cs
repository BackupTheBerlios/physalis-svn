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
        /// <paramref name="initials">List of the initials assemblies to be started now. These bundles
        /// are started in the exact order of this list, starting from the 0 index to the end of the list.
        /// Each bundle is installed then started.</paramref>
        /// </summary>
        public static void Start(string[] initials)
        {
            TracesProvider.TracesOutput.OutputTrace("Physalis is starting...\n");
            TracesProvider.TracesOutput.OutputTrace(String.Format("Physalis framework, version {0}\nCopyright 2004 Physalis. All Rights Reserved.\nSee http://physalis.berlios.de for more information.\n", Version));

            Framework.Instance.Start(initials);
        }

        static public void Shutdown(int exitcode)
        {
        }
    }
}
