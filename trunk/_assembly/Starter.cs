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

        #region --- Singleton ---
        public static readonly Starter Instance = new Starter();
        #endregion
        
        private Starter()
		{
		}

        /// <summary>
        /// Start Physalis here.
        /// </summary>
        public static void Start()
        {
            TracesOutputProvider.TracesOutput.OutputTrace("Physalis is starting...\n");
            TracesOutputProvider.TracesOutput.OutputTrace(String.Format("Physalis framework, version {0}\nCopyright 2004 Physalis. All Rights Reserved.\nSee http://physalis.berlios.de for more information.\n", Version));
        }

        static public void Shutdown(int exitcode)
        {
        }
    }
}
