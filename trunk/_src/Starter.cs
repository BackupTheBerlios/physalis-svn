using System;
using System.IO;
using System.Reflection;
using OpenNETCF.Configuration;
//using Physalis.Framework;

namespace Physalis
{
	/// <summary>
	/// Framework starter
	/// </summary>
	public class Starter
	{
        #region --- Constants ---
        private static readonly string DEF_CACHE_FOLDER = "cache";
        private static readonly string KEY_CACHE_FOLDER = "CacheFolder";
        private static readonly string KEY_RESET_CACHE = "ResetCache";
        #endregion

        #region --- Fields ---
        private static bool initialized = false;
        private static bool reset = false;
        #endregion

        #region --- Properties ---
        public static bool Reset
        {
            get
            {
                return reset;
            }
        }
        #endregion

        /// <summary>
        /// Start the Physalis
        /// </summary>
        public static void Main(string[] args)
        {
            if(!initialized)
            {
                Console.WriteLine("Physalis framework starts...");

//                initSystemProperties();
//                initBaseURL();

                DirectoryInfo cache = InitializeCache();
                ReadProperties();
                
                try
                {
                    Framework.TheFramework.Initialize(cache);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Unable to create the Physalis framework, the program can't be run");
                    Console.WriteLine(e.Message);
                }

                Tracer tracer = new Tracer();
                tracer.Start();

//                processCommandLine(args);
                
                tracer.Stop();
            }
        }

        private static void ReadProperties()
        {
        }

        /// <summary>
        /// Initialize the framework cache folder
        /// </summary>
        /// <returns>The cache folder</returns>
        private static DirectoryInfo InitializeCache()
        {
            string folder = (string) DllConfigurationSettings.DllSettings[KEY_CACHE_FOLDER];
            reset = Boolean.Parse((string) DllConfigurationSettings.DllSettings[KEY_RESET_CACHE]);

            if((folder == null) || folder.Equals(""))
            {
                // Get the current folder for the cache
                string fullname = Assembly.GetCallingAssembly().GetName().CodeBase;
                folder = Path.GetDirectoryName(fullname);
            }

            folder +=  Path.DirectorySeparatorChar + DEF_CACHE_FOLDER;

            DirectoryInfo cache = new DirectoryInfo(folder);
            if(!cache.Exists)
            {
                cache.Create();
            }
            else
            {
                if(reset)
                {
                    Console.WriteLine("Reset cache folder");
                    cache.Delete();
                    Console.WriteLine("Create new cache folder");
                    cache.Create();
                }
            }

            return cache;
        }
    }
}
