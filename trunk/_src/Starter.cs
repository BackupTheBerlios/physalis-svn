using System;
using System.Collections;
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
        #region --- Fields ---
        private IDictionary properties;
        private ITracesOutput output;
        #endregion

        #region --- Singleton ---
        public static readonly Starter Instance = new Starter();
        #endregion

        #region --- Properties ---
        /// <summary>
        /// Physalis framework properties. The values are stored in a XML file.
        /// </summary>
        public IDictionary Properties
        {
            get
            {
                return properties;
            }
        }
        /// <summary>
        /// Return the Physalis assembly version.
        /// </summary>
        /// <returns>The Physalis version as string</returns>
        private string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        
        /// <summary>
        /// <see cref="ITracesOutput"/> set to the framework to output Physalis traces.
        /// </summary>
        public ITracesOutput Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }
        #endregion

        private Starter()
		{
		}

        /// <summary>
        /// Start Physalis here.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Physalis is starting...\r\n");
            Console.WriteLine("Physalis framework, version {0}\nCopyright 2004 Physalis. All Rights Reserved.\n\nSee http://physalis.berlios.de for more information.\r\n", Version);

            Console.WriteLine("Process configuration file...\r\n", Version);
            
            //TODO: read properties

            try
            {
                InitCache("fwdir");
                new Framework();
            }
            catch(Exception e)
            {
                output.OutputTrace("Error while initializing the Physalis framework.");
                output.OutputTrace(e.Message);
            }
        }

        /// <summary>
        /// Initialize the cache folder, if this folder already exists,
        /// it is deleted and re-created.
        /// </summary>
        /// <param name="cache">The cache folder name.</param>
        private void InitCache(string cache)
        {
            DirectoryInfo folder = new DirectoryInfo(cache);
            if(folder.Exists)
            {
                folder.Delete(true);
            }

            folder.Create();
        }
    }
}
