using System;
using System.IO;
using System.Reflection;
using Physalis.Specs.Framework;
using Physalis.Utils;

namespace Physalis.Framework
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    internal class Bundle : IBundle
    {
        #region --- Fields ---
        private BundleState state;
        private Int32 id;
        private Assembly assembly;
        private IBundleContext context;
        private DirectoryInfo storage;
        #endregion

        #region --- Properties ---
        public BundleState State
        {
            get
            {
                return state;
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
                return assembly.GetName().CodeBase;
            }
        }

        private IBundleContext Context
        {
            get
            {
                if(context == null)
                {
                    context = new BundleContext(this, this.storage);
                }

                return context;
            }
        }

        private IBundleActivator Activator
        {
            get
            {
                // Look for the activator attribute
                BundleActivatorAttribute attr = (BundleActivatorAttribute)Attribute.GetCustomAttribute(assembly, typeof(BundleActivatorAttribute));
                if (attr == null)
                {
                    TracesProvider.TracesOutput.OutputTrace("No activator found");
                    return null;
                }
                else
                {
                    TracesProvider.TracesOutput.OutputTrace("Activator found: " + attr.Activator);
                    // Create the activator instance
                    return (IBundleActivator)assembly.CreateInstance(attr.Activator);
                }
            }
        }
        internal Assembly Assembly
        {
            get
            {
                return assembly;
            }
            set
            {
                this.assembly = value;
            }
        }
        #endregion

        internal Bundle(Int32 id, string location, DirectoryInfo storage)
        {
            try
            {
                // Build the assembly full path
                string full = Path.GetFullPath(location);
                assembly = Assembly.LoadFrom(full);
            }
            catch (Exception e)
            {
                TracesProvider.TracesOutput.OutputTrace(e.Message);
                throw new BundleException(e.Message, e);
            }

            this.storage = storage;
            this.id = id;
            this.state = BundleState.Installed;
        }

        public void Start()
        {
            try
            {
                this.state = BundleState.Starting;

                IBundleActivator activator = this.Activator;
                if (activator == null)
                {
                    throw new Exception("No activator for: " + this.Location);
                }

                activator.Start(this.Context);
                this.state = BundleState.Active;
                EventManager.OnBundleChanged(new BundleEventArgs(BundleTransition.Started, this));
            }
            catch(Exception e)
            {
                this.state = BundleState.Installed;
                TracesProvider.TracesOutput.OutputTrace(e.Message);
                throw new BundleException(e.Message, e);
            }
        }

        public void Stop()
        {
            try
            {
                this.state = BundleState.Stopping;
                IBundleActivator activator = this.Activator;
                if (activator == null)
                {
                    throw new Exception("No activator for: " + this.Location);
                }

                activator.Stop(this.Context);
            }
            catch (Exception e)
            {
                TracesProvider.TracesOutput.OutputTrace(e.Message);
                throw new BundleException(e.Message, e);
            }

            this.state = BundleState.Installed;
            EventManager.OnBundleChanged(new BundleEventArgs(BundleTransition.Stopped, this));
        }

        public void Uninstall()
        {
            TracesProvider.TracesOutput.OutputTrace("Not implemented, can't unload an assembly");
            this.state = BundleState.Uninstalled;
            EventManager.OnBundleChanged(new BundleEventArgs(BundleTransition.Uninstalled, this));
        }
    }
}
