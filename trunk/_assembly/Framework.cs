using System;
using System.IO;
using System.Reflection;
using Physalis.Specs.Framework;
using Physalis.Utils;

namespace Physalis.Framework
{
	/// <summary>
	/// Main class of the Physalis framework. This class is internal, not accessible from outside the
	/// Physalis assembly.
	/// </summary>
	class Framework
    {
        #region --- Fields ---
        private Bundles bundles;
        #endregion

        #region --- Singleton ---
		public static readonly Framework Instance = new Framework();
		#endregion

        #region --- Properties ---
        internal Bundles Bundles
        {
            get
            {
                return bundles;
            }
        }
        #endregion

        private Framework()
		{
        }

        public void Start(string[] initials)
		{
            if (bundles == null)
            {
                bundles = new Bundles();
            }
            else
            {
                throw new InvalidOperationException("The framework is already started");
            }

            foreach(string path in initials)
            {
                TracesProvider.TracesOutput.OutputTrace("Loading: " + path);
                IBundle bundle = bundles.Add(path);
                bundle.Start();
            }
        }

        public void Stop()
        {
            for (Int32 i = bundles.Count - 1; i > -1; i--)
            {
                TracesProvider.TracesOutput.OutputTrace("Stopping: " + bundles[i].Location);
                bundles[i].Stop();
            }
        }
    }
}
