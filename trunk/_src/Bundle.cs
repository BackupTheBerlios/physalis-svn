using System;
using Physalis.Specs.Framework;

namespace Physalis.Framework
{
	/// <summary>
	/// 
	/// </summary>
	public class Bundle : IBundle
	{
		public Bundle()
		{
			// 
			// TODO: Add constructor logic here
			//
        }
        #region IBundle Members

        public Physalis.Specs.Framework.BundleState State
        {
            get
            {
                // TODO:  Add Bundle.State getter implementation
                return BundleState.Uninstalled;
            }
        }

        public Int32 Id
        {
            get
            {
                // TODO:  Add Bundle.Id getter implementation
                return new Int32 ();
            }
        }

        public string Location
        {
            get
            {
                // TODO:  Add Bundle.Location getter implementation
                return null;
            }
        }

        public System.Collections.IDictionary Headers
        {
            get
            {
                // TODO:  Add Bundle.Headers getter implementation
                return null;
            }
        }

        public IServiceReference[] RegisteredServices
        {
            get
            {
                // TODO:  Add Bundle.RegisteredServices getter implementation
                return null;
            }
        }

        public IServiceReference[] ServicesInUse
        {
            get
            {
                // TODO:  Add Bundle.ServicesInUse getter implementation
                return null;
            }
        }

        public void Start()
        {
            // TODO:  Add Bundle.Start implementation
        }

        public void Stop()
        {
            // TODO:  Add Bundle.Stop implementation
        }

        public void Update()
        {
            // TODO:  Add Bundle.Update implementation
        }

        void Physalis.Specs.Framework.IBundle.Update(System.IO.Stream inputStream)
        {
            // TODO:  Add Bundle.Physalis.Specs.Framework.IBundle.Update implementation
        }

        public void Uninstall()
        {
            // TODO:  Add Bundle.Uninstall implementation
        }

        public string GetResource(string name)
        {
            // TODO:  Add Bundle.GetResource implementation
            return null;
        }

        public bool hasPermission(Object permission)
        {
            // TODO:  Add Bundle.hasPermission implementation
            return false;
        }

        #endregion
    }
}
