using System;
using System.Collections;
using Physalis.Framework;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
    // TODO: To be implemented
    public sealed class Manifest : Hashtable
	{
        #region --- Properties ---
        /// <summary>
        /// Manifest indexer to quickly access values.
        /// </summary>
        string this[string key]
        {
            get
            {
                return (string) this[key];
            }
        }
        #endregion

        /// <summary>
		/// Default constructor. Set the hashtable as a case insensitive one.
		/// </summary>
        public Manifest() : base(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer())
		{
        }


        /**
        * Initializes the OSGi specific members of this class, that are used by
        * its convenient methods, from the current manifest headers.
        *
        * @throws BundleException if this manifest is not properly formatted.
        */
        internal void Initialize()
        {
//            try
//            {
//                bundleActivator = (String) getInternal(BUNDLE_ACTIVATOR);
//                bundleUpdateLocation = (String) getInternal(BUNDLE_UPDATE_LOCATION);
//                importPackage = parsePackageInfo((String) getInternal(IMPORT_PACKAGE));
//                exportPackage = parsePackageInfo((String) getInternal(EXPORT_PACKAGE));
//                nativeCodeClauses = parseNativeCodeInfo((String) getInternal(BUNDLE_NATIVE_CODE));
//                bundleClassPath = Util.parseCommaSeparatedString((String) getInternal(BUNDLE_CLASSPATH));
//                dynamicImportPackage = Util.parseCommaSeparatedString((String) getInternal(DYNAMIC_IMPORT_PACKAGE));
//                executionEnvironments = Util.parseCommaSeparatedString((String) getInternal(BUNDLE_REQUIRED_EXECUTION_ENVIRONMENT));
//            }
//            catch (IllegalArgumentException iae)
//            {
//                throw new BundleException("Illegal manifest format", iae);
//            }
//
//            importExportedPackages();
        }

    }
}
