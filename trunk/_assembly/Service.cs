using System;
using System.Collections;
using System.Reflection;

namespace Physalis.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    internal class Service
    {
        #region --- Fields ---
        private Assembly assembly;
        private IList interfaces;
        #endregion

        #region --- Properties ---
        internal Assembly Assembly
        {
            get
            {
                return assembly;
            }
        }
        #endregion

        internal Service()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        internal bool IsDefined(string service)
        {
            return interfaces.Contains(service);
        }

    }
}
