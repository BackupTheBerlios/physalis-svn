using System;
using Physalis.Framework;

namespace Physalis
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ABundle : IBundle, IComparable
	{
        #region --- Fields ---
        private string location = null;
        private Int32 id;
        private BundleState state;
        private Int32 startLevel;
        private bool isPersistentlyStarted;
        #endregion
        
        public ABundle(string location, Int32 bundleId, Int32 level, bool isPersistentlyStarted)
		{
            this.location = location;
            this.id = bundleId;
            this.state = BundleState.Installed;
            this.startLevel = level;
            this.isPersistentlyStarted = isPersistentlyStarted;
        }

        #region --- Properties ---
        public abstract Manifest Manifest
        {
             get;
        }
        
        public bool IsPersistentlyStarted
        {
            get
            {
                return isPersistentlyStarted;
            }
        }
        
        public Int32 StartLevel
        {
            get
            {
                return startLevel;
            }
        }
        
        public BundleState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public Int32 Id
        {
            get
            {
                return id;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }
        }

        public System.Collections.IDictionary Headers
        {
            get
            {
                // TODO:  Add BundleStub.Headers getter implementation
                return null;
            }
        }

        public IServiceReference[] RegisteredServices
        {
            get
            {
                // TODO:  Add BundleStub.RegisteredServices getter implementation
                return null;
            }
        }

        public IServiceReference[] ServicesInUse
        {
            get
            {
                // TODO:  Add BundleStub.ServicesInUse getter implementation
                return null;
            }
        }
        #endregion

        public void Start()
        {
            Start();
        }

        public void Stop()
        {
            Stop();
        }

        public void Update()
        {
            Update();
        }

        public void Uninstall()
        {
            Uninstall();
        }

        public string GetResource(string name)
        {
            // TODO:  Add BundleStub.GetResource implementation
            return null;
        }

        #region --- IComparable Members ---

        public Int32 CompareTo(object obj)
        {
            ABundle other = (ABundle) obj;
            Int32 result = this.startLevel - other.startLevel;

            if(result == 0)
            {
                result = this.id - other.id;
            }

            return result;
        }

        #endregion
    }
}
