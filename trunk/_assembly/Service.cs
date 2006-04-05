using System;
using System.Collections;
using System.Reflection;
using Physalis.Specs.Framework;

namespace Physalis.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    internal class Service
    {
        #region --- Fields ---
        private IBundle bundle;
        private IList interfaces;
        #endregion

        #region --- Properties ---
        internal IBundle Bundle
        {
            get
            {
                return bundle;
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
