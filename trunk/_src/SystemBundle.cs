using System;
using System.Text;
using Physalis.Framework;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class SystemBundle : ABundle
	{
        
        #region --- Fields ---
        /// <summary>
        /// The default system name spaces.
        /// </summary>
        private static readonly string[][] SYSTEM_NAMESPACES =
        {
            new string[] { Framework.NAMESPACE_NAME, Framework.NAMESPACE_VERSION },
//            new string[] { StartLevel.NAMESPACE_NAME, StartLevel.NAMESPACE_VERSION} 
            /*,
            new string[] { PackageAdminImpl.PACKAGE_NAME, PackageAdminImpl.PACKAGE_VERSION },
            new string[] { PermissionAdminImpl.PACKAGE_NAME, PermissionAdminImpl.PACKAGE_VERSION },
            new string[] { BundleTransactionAdminImpl.PACKAGE_NAME, BundleTransactionAdminImpl.PACKAGE_VERSION },
            new string[] { HandlerFactory.SERVICE_TRACKER_PACKAGE_NAME, HandlerFactory.SERVICE_TRACKER_PACKAGE_VERSION},
            new string[] { HandlerFactory.HANDLER_SERVICE_PACKAGE_NAME, HandlerFactory.HANDLER_SERVICE_PACKAGE_VERSION}*/
            // TODO: To see if it is necessary to add the others.
        };

        private Manifest manifest = null;
        private StartLevel startLevel = null;
        #endregion

        #region --- Properties ---
        public override Manifest Manifest
        {
            get
            {
                return manifest;
            }
        }

        public StartLevel StartLevelAdmin
        {
            get
            {
                return startLevel;
            }
        }
        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SystemBundle() : base(   Constants.SYSTEM_BUNDLE_LOCATION,
                                        BundleAdmin.SYSTEM_BUNDLE_ID,
                                        StartLevel.SYSTEM_BUNDLE_START_LEVEL,
                                        false)
		{
            manifest = new Manifest();
            manifest.Add(Constants.BUNDLE_NAME, Constants.SYSTEM_BUNDLE_LOCATION);
            manifest.Add(Constants.EXPORT_NAMESPACE, MakeExportPackage());
            manifest.Initialize();
        }

        /// <summary>
        /// Starts this system bundle (and implicitly the framework) on the given start level.
        /// </summary>
        /// <param name="level">the start level</param>
        /// <returns>true if the bundle has really been started by this call; false otherwise</returns>
        internal bool StartSynchronously(Int32 level)
        {
    //        Framework.TheFramework.CheckAdminPermission();

            bool started = false;

            // we start the framework if and only if it is installed  or resolved.
            if ((State == BundleState.Installed) || (State == BundleState.Resolved))
            {
                State = BundleState.Starting;

                // TODO: Check if necessary
//                startLevelAdmin.setStartLevelInternally(level);

                // Active transactions must be cancelled before the system
                // bundle becomes active and after all the bundle have been started.
//                bundleTransactionAdmin.cancelTransactions();

                Framework.TheFramework.BundleAdmin.SaveUnconditionally();

                State = BundleState.Active;
                started = true;
            }

            return started;
        }

        /// <summary>
        /// Makes the Constants.EXPORT_PACKAGE manifest header for the system bundle. The exported packages are
        /// got from the internal list and the potential ones defined with the system property Main.SYSTEM_PACKAGES_KEY.
        /// </summary>
        /// <returns>All system packages exported by the framework as a String with the same format as a value of a
        /// Constants.EXPORT_PACKAGE manifest header.</returns>
        private string MakeExportPackage()
        {
            StringBuilder buffer = new StringBuilder();
    
//            string sysPkgProp = Framework.TheFramework.getProperty(Main.SYSTEM_PACKAGES_KEY);
//            if (sysPkgProp != null)
//            {
//                buffer.append(sysPkgProp.trim());
//            }
    
            for (int i = SYSTEM_NAMESPACES.Length - 1; i >= 0; i--)
            {
                if (buffer.Length > 0)
                {
                    buffer.Append(',').Append(' ');
                }
                buffer.Append(SYSTEM_NAMESPACES[i][0]).Append(';');
                buffer.Append(Constants.PACKAGE_SPECIFICATION_VERSION).Append('=').Append(SYSTEM_NAMESPACES[i][1]);
            }
    
            return buffer.ToString();
        }
    

//    /**
//     * The headers of this system bundle.
//     */
//    private final BundleManifest manifest;
//
//    /**
//     * StartLevel service.
//     */
//    private StartLevelImpl startLevelAdmin;
//
//    /**
//     * PackageAdmin service.
//     */
//    private PackageAdminImpl packageAdmin;
//
//    /**
//     * PermissionAdmin service.
//     */
//    private PermissionAdminImpl permissionAdmin;
//
//    /**
//     * BundleTransactionAdmin service.
//     */
//    private BundleTransactionAdminImpl bundleTransactionAdmin;
//
//    /**
//     * The Classloader of this system bundle.
//     */
//    private final SystemBundleClassLoader classLoader;
//
//    /**
//     * The BundleContext of this Bundle.
//     */
//    private final SystemBundleContext bundleContext;
//
//    /**
//     * The protection domain of this bundle (set of permissions).
//     */
//    private final ProtectionDomain protectionDomain;
//
//    /**
//     * The name of the cache sub-directory where are stored the bundle
//     * transaction related information.
//     */
//    private static final String TRS_DIR_NAME = "trs";
//
//    /**
//     * The name of the cache sub-directory where are stored the security
//     * related information.
//     */
//    private static final String SECURITY_DIR_NAME = "security";
//
//    /**
//     * The name of the thread restarting the framework asynchronously.
//     */
//    private static final String FRAMEWORK_RESTART_THREAD_NAME = "riofwk00: Framework restart";
//
//    /**
//     * The name of the thread shutting down the framework asynchronously.
//     */
//    private static final String FRAMEWORK_SHUTDOWN_THREAD_NAME = "riofwk01: Framework shutdown";
//
//    /**
//     * The default system packages.
//     */
//    private static final String[][] SYSTEM_PACKAGES =
//    {
//        { Framework.PACKAGE_NAME, Framework.PACKAGE_VERSION },
//        { Framework.EXT_PACKAGE_NAME, Framework.EXT_PACKAGE_VERSION },
//        { StartLevelImpl.PACKAGE_NAME, StartLevelImpl.PACKAGE_VERSION },
//        { PackageAdminImpl.PACKAGE_NAME, PackageAdminImpl.PACKAGE_VERSION },
//        { PermissionAdminImpl.PACKAGE_NAME, PermissionAdminImpl.PACKAGE_VERSION },
//        { BundleTransactionAdminImpl.PACKAGE_NAME, BundleTransactionAdminImpl.PACKAGE_VERSION },
//        { HandlerFactory.SERVICE_TRACKER_PACKAGE_NAME, HandlerFactory.SERVICE_TRACKER_PACKAGE_VERSION},
//        { HandlerFactory.HANDLER_SERVICE_PACKAGE_NAME, HandlerFactory.HANDLER_SERVICE_PACKAGE_VERSION}
//    };
//
//    /**
//     * Registers the services provided by the system bundle.
//     */
//    void registerServices()
//    {
//        String classes[];
//        Framework fwk = getFramework();
//
//        if (fwk.isSecurityEnabled())
//        {
//            permissionAdmin = new PermissionAdminImpl(fwk, new FileTree(fwk.getCacheDir(), SECURITY_DIR_NAME));
//            Policy.setPolicy(permissionAdmin);
//
//            // PermissionAdmin: service registration
//            classes = new String[] { PermissionAdmin.class.getName() };
//            fwk.getServiceAdmin().register(this, classes, permissionAdmin, null);
//        }
//        else
//        {
//            permissionAdmin = null;
//        }
//
//        // StartLevel: service registration
//        classes = new String[] { StartLevel.class.getName() };
//        startLevelAdmin = new StartLevelImpl(fwk);
//        fwk.getServiceAdmin().register(this, classes, startLevelAdmin, null);
//
//        // PackageAdmin: service registration
//        classes = new String[] { PackageAdmin.class.getName() };
//        packageAdmin = new PackageAdminImpl(fwk);
//        fwk.getServiceAdmin().register(this, classes, packageAdmin, null);
//
//        // BundleTransactionAdmin: service registration
//        classes = new String[] { BundleTransactionAdmin.class.getName() };
//        bundleTransactionAdmin = new BundleTransactionAdminImpl(fwk, new FileTree(fwk.getCacheDir(), TRS_DIR_NAME));
//        fwk.getServiceAdmin().register(this, classes, bundleTransactionAdmin, null);
//    }
//
//    /**
//     * Implements the <code>org.osgi.framework.Bundle</code> interface.
//     *
//     * @see org.osgi.framework.Bundle#start()
//     */
//    public synchronized void start()
//    {
//        startSynchronously(startLevelAdmin.getStartLevel());
//    }
//
//    /**
//     * Implements the <code>org.osgi.framework.Bundle</code> interface.
//     *
//     * @see org.osgi.framework.Bundle#stop()
//     */
//    public synchronized void stop()
//    {
//        stopAsynchronously();
//    }
//
//    /**
//     * Implements the <code>org.osgi.framework.Bundle</code> interface.
//     *
//     * @param in unused parameter.
//     * @see org.osgi.framework.Bundle#update()
//     */
//    public synchronized void update(InputStream in)
//    {
//        restartAsynchronously();
//    }
//
//    /**
//     * Implements the <code>org.osgi.framework.Bundle</code> interface.
//     *
//     * @throws java.lang.SecurityException If the caller does not have the
//     *         appropriate <tt>AdminPermission</tt>, and the Java Runtime
//     *         Environment supports permissions.
//     * @throws BundleException if a privileged user (ie with AdminPermission)
//     *         calls this method.
//     * @see org.osgi.framework.Bundle#uninstall()
//     */
//    public synchronized void uninstall() throws BundleException
//    {
//        getFramework().checkAdminPermission();
//        throw new BundleException("Uninstall of System bundle is not allowed");
//    }
//
//    /**
//     * Gets the manifest of this system bundle.
//     *
//     * @return the manifest of this system bundle.
//     */
//    BundleManifest getManifest()
//    {
//        return manifest;
//    }
//
//    /**
//     * Gets the classloader of this bundle without perform any permission check.
//     * Creates the classloader if we have not done this previously. This
//     * implies to resolve this bundle.
//     *
//     * @return the classloader of this bundle.
//     */
//    BundleClassLoader getClassLoaderUnchecked()
//    {
//        return classLoader;
//    }
//
//    /**
//     * Gets the StartLevel service provided by this bundle.
//     *
//     * @return the StartLevel service provided by this bundle.
//     */
//    StartLevelImpl getStartLevelAdmin()
//    {
//        return startLevelAdmin;
//    }
//
//    /**
//     * Gets the PackageAdmin service provided by this bundle.
//     *
//     * @return the PackageAdmin service provided by this bundle.
//     */
//    PackageAdminImpl getPackageAdmin()
//    {
//        return packageAdmin;
//    }
//
//    /**
//     * Gets the PermissionAdmin service provided by this bundle.
//     *
//     * @return the PermissionAdmin service provided by this bundle.
//     */
//    PermissionAdminImpl getPermissionAdmin()
//    {
//        return permissionAdmin;
//    }
//
//    /**
//     * Gets the BundleTransactionAdmin service provided by this bundle.
//     *
//     * @return the BundleTransactionAdmin service provided by this bundle.
//     */
//    BundleTransactionAdminImpl getBundleTransactionAdmin()
//    {
//        return bundleTransactionAdmin;
//    }
//
//    /**
//     * Gets the protection domain of this bundle.
//     *
//     * @return the protection domain of this bundle.
//     */
//    ProtectionDomain getProtectionDomain()
//    {
//        return protectionDomain;
//    }
//
//    /**
//     * Gets this bundle context.
//     *
//     * @return this bundle context.
//     */
//    SystemBundleContext getBundleContext()
//    {
//        return bundleContext;
//    }
//
//
//    /**
//     * Restarts this system bundle (and implicitly the framework) in a
//     * separate thread.
//     */
//    private synchronized void restartAsynchronously()
//    {
//        final Framework fwk = getFramework();
//        fwk.checkAdminPermission();
//
//        AccessController.doPrivileged(
//            new PrivilegedAction()
//            {
//                public Object run()
//                {
//                    Thread th = new Thread(FRAMEWORK_RESTART_THREAD_NAME)
//                        {
//                            public void run()
//                            {
//                                int level = getStartLevelAdmin().getStartLevel();
//                                stopSynchronously();
//                                try
//                                {
//                                    packageAdmin.reset();
//                                    fwk.launch(level);
//                                }
//                                catch (Exception e)
//                                {
//                                    System.err.println("Error - Framework restart failed: " + e);
//                                    System.exit(1);
//                                }
//                            }
//                        };
//
//                    th.setDaemon(false);
//                    th.start();
//                    return null;
//                }
//            });
//    }
//
//    /**
//     * Stops this system bundle (and implicitly the framework).
//     * This method suspends all started contexts so that they can be
//     * automatically restarted when the framework is next launched.
//     *
//     * <p>If the framework is not started, this method does nothing.
//     * If the framework is started, this method will:
//     * <ol>
//     * <li>Set the state of the framework to <i>inactive</i>.</li>
//     * <li>Suspended all started bundles as described in the
//     * {@link Bundle#stop()} method except that the persistent state of the
//     * bundle will continue to be started. Reports any exceptions that occur
//     * during stopping using <code>FrameworkErrorEvents</code>.</li>
//     * <li>Disable event handling.</li>
//     * </ol></p>
//     */
//    synchronized void stopSynchronously()
//    {
//        Framework fwk = getFramework();
//        fwk.checkAdminPermission();
//
//        if (getState() == ACTIVE)
//        {
//            setState(STOPPING);
//
//            startLevelAdmin.setStartLevelInternally(StartLevelImpl.SYSTEM_BUNDLE_START_LEVEL);
//
//            Iterator iterator = fwk.getBundleAdmin().getStandardBundles().iterator();
//            while (iterator.hasNext())
//            {
//                StandardBundle bundle = (StandardBundle) iterator.next();
//                bundle.unresolve();
//            }
//
//            fwk.getBundleAdmin().saveUnconditionally();
//
//            setState(INSTALLED);
//        }
//    }
//
//    /**
//     * Stops this system bundle (and implicitly the framework) in a separate
//     * thread.
//     */
//    private synchronized void stopAsynchronously()
//    {
//        final Framework fwk = getFramework();
//        fwk.checkAdminPermission();
//
//        AccessController.doPrivileged(
//            new PrivilegedAction()
//            {
//                public Object run()
//                {
//                    Thread th = new Thread(FRAMEWORK_SHUTDOWN_THREAD_NAME)
//                        {
//                            public void run()
//                            {
//                                stopSynchronously();
//                                System.exit(0);
//                            }
//                        };
//
//                    th.setDaemon(false);
//                    th.start();
//                    return null;
//                }
//            });
//    }
    }
}
