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
		#region --- Singleton ---
		public static readonly Framework Instance = new Framework();
		#endregion

		private Framework()
		{
		}

        public void Start(string[] initials)
		{
            Assembly assembly;

            foreach(string path in initials)
            {
                TracesProvider.TracesOutput.OutputTrace("Loading: " + path);

                // Build the assembly full path
                string full = Path.GetFullPath(path);

                // Load the assembly
                AssemblyName uname = AssemblyName.GetAssemblyName(full);
                assembly = AppDomain.CurrentDomain.Load(uname);

                // Look for the activator attribute
                BundleActivatorAttribute attr = (BundleActivatorAttribute)Attribute.GetCustomAttribute(assembly, typeof(BundleActivatorAttribute));
                if (attr == null)
                {
                    TracesProvider.TracesOutput.OutputTrace("No activator found");
                }
                else
                {
                    TracesProvider.TracesOutput.OutputTrace("Activator found: " + attr.Activator);
                }

                // Create the activator instance
                IBundleActivator activator = (IBundleActivator)assembly.CreateInstance(attr.Activator);
                // Start the bundle
                activator.Start();
            }
        }
	}
}
