using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Physalis.Specs;

namespace Physalis
{
    /// <summary>
    /// Framework class, implemeted as a singleton.
    /// </summary>
    public sealed class Framework
    {
        #region --- Constants ---
        internal static readonly string NAMESPACE_NAME = "Physalis.Specs";
        internal static readonly string NAMESPACE_VERSION = "0.1";
        #endregion

        #region --- Singleton ---
        /// <summary>
        /// The single instance of the framework.
        /// </summary>
        public static readonly Framework TheFramework = new Framework();
        #endregion
        
        #region --- Fields ---
        private Hashtable properties = null;
        private DirectoryInfo cache = null;
        private BundleAdmin bundleAdmin = null;
        #endregion

        #region --- Properties ---
        /// <summary>
        /// The framework cache folder
        /// </summary>
        public DirectoryInfo Cache
        {
            get
            {
                return cache;
            }
        }

        /// <summary>
        /// The system bundle of the framework
        /// </summary>
        public SystemBundle SystemBundle
        {
            get
            {
                // TODO: to be implemented
                return null;
            }
        }

        /// <summary>
        /// Bundle administrator for the framework.
        /// </summary>
        public BundleAdmin BundleAdmin
        {
            get
            {
                return bundleAdmin;
            }
        }
        #endregion

        private Framework()
        {
        }
            
        /// <summary>
        /// Called by the Starter
        /// </summary>
        /// <param name="cache">folder of the cache</param>
        public void Initialize(DirectoryInfo cache)
        {
            this.cache = cache;
            InitializeProperties();

            bundleAdmin = new BundleAdmin();
        }

        //        public Framework(DirectoryInfo cache)
        //		{
        //            this.cache = cache;

        //            setHandlerFactory();
        //
        //            checkPermissions = System.getSecurityManager() != null;
        //
        //            bundleAdmin = new BundleAdmin(this);
        //            serviceAdmin = new ServiceAdmin(this);
        //            listenerAdmin = new ListenerAdmin();
        //            nativeCodeAdmin = new NativeCodeAdmin(this);

        //            nativeCodeAdmin.init();
        //            getSystemBundle().registerServices();
        //            bundleAdmin.load(); // throws Exception
        //        }


        
        /// <summary>
        /// Initialize the framework properties.
        /// </summary>
        private void InitializeProperties()
        {
            properties = new Hashtable(5);
            
            // The CLR version
            
            // The version of the framework.
            //            properties.Add(Constants.FRAMEWORK_VERSION, PACKAGE_VERSION);
            //
            //            // The vendor of this framework implementation.
            //            properties.Add(Constants.FRAMEWORK_VENDOR, FRAMEWORK_VENDOR);
            //
            //            // The language being used. See ISO 639 for possible values.
            //            string val = findSystemProperty(Constants.FRAMEWORK_LANGUAGE, HOST_LANGUAGE_KEY);
            //            properties.Add(Constants.FRAMEWORK_LANGUAGE, val != null ? val : Locale.getDefault().getLanguage());
            //
            //            // The name of the operating system of the hosting computer.
            //            val = findSystemProperty(Constants.FRAMEWORK_OS_NAME, OS_NAME_KEY);
            //            properties.Add(Constants.FRAMEWORK_OS_NAME, Alias.unifyOsName(val));
            //
            //            // The version number of the operating system of the hosting computer.
            //            val = findSystemProperty(Constants.FRAMEWORK_OS_VERSION, OS_VERSION_KEY);
            //            properties.Add(Constants.FRAMEWORK_OS_VERSION, Version.createVersion(val).toString());
            //
            //            // The name of the processor of the hosting computer.
            //            val = findSystemProperty(Constants.FRAMEWORK_PROCESSOR, HOST_ARCH_KEY);
            //            properties.Add(Constants.FRAMEWORK_PROCESSOR, Alias.unifyProcessor(val));

            /*
        The following lines of code are temporarily put bewteen comment marks
        It will be removed as soon as Execution Environment specifications are
        clarified and the related OSGi Test suite is corrected.

            // The execution environments the framework supports.
            value = System.getProperty(Constants.FRAMEWORK_EXECUTIONENVIRONMENT, "");
            properties.put(Constants.FRAMEWORK_EXECUTIONENVIRONMENT, value);
    */

            // We make a copy of all other framework properties set as system properties.
            //            String[] otherProps = new String[] {
            //                                                   Main.FRAMEWORK_BASE_URL_KEY,
            //                                                   Main.FRAMEWORK_CACHE_DIR_PATH_KEY,
            //                                                   Main.FRAMEWORK_CACHE_RESET_FLAG_KEY,
            //                                                   Main.NATIVE_CODE_LIBRARIES_DIR_PATH_KEY,
            //                                                   Main.SYSTEM_PACKAGES_KEY
            //                                               };
            //
            //            for (Int32 i = otherProps.length - 1; i >= 0; i--)
            //            {
            //                value = System.getProperty(otherProps[i]);
            //                if (value != null)
            //                {
            //                    properties.put(otherProps[i], value);
            //                }
            //            }
        }

        public void Launch(Int32 level)
        {
            bool started = bundleAdmin.SystemBundle.StartSynchronously(level);

            if (started)
            {
                // TODO: A faire
//                listenerAdmin.frameworkEvent(new FrameworkEvent(FrameworkEvent.Started, getSystemBundle(), null));
            }
        }
    }
}

