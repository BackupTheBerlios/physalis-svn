using System;
using System.Reflection;
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
                TracesProvider.TracesOutput.OutputTrace(path);

                // Load the assembly
                assembly = Assembly.Load(path);

                // Look for the activator attribute
            }
		}
	}
}
