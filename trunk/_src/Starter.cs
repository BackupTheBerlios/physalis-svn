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
        public const string PHYSALIS_DIR_PROP = "Physalis.dir";
        public const string PHYSALIS_DIR_DEF = "fwdir";
        #endregion

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
            output.OutputTrace("Physalis is starting...\n");
            output.OutputTrace(String.Format("Physalis framework, version {0}\nCopyright 2004 Physalis. All Rights Reserved.\nSee http://physalis.berlios.de for more information.\n", Version));

            output.OutputTrace("Process configuration file...\n");
            
            InitializeProperties();

            try
            {
                InitCache((string) this.Properties[PHYSALIS_DIR_PROP]);
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
            // Get the application path
            string path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetCallingAssembly().GetName().CodeBase )
                + Path.DirectorySeparatorChar + cache;

#if DEBUG
            Starter.Instance.Output.OutputTrace("Cache initialization: " + path);
#endif 
            
            DirectoryInfo folder = new DirectoryInfo(path);
            if(folder.Exists)
            {
                folder.Delete(true);
            }

            folder.Create();
        }

        /// <summary>
        /// Initialize the Physalis properties.
        /// </summary>
        private void InitializeProperties()
        {
            properties = new ListDictionary();
            properties.Add(PHYSALIS_DIR_PROP, PHYSALIS_DIR_DEF);
        }
    }
}
