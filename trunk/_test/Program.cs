#region Using directives

using System;
using System.IO;
using System.Text;
using Physalis.Framework;
using Physalis.Specs.Framework;
using Physalis.Utils;

#endregion

namespace Test
{
    class Program : IBundleActivator
    {
        static void Main(string[] args)
        {
//            TracesProvider.Initialize(new TraceOutput("169.254.25.129", 6666));
//            TracesProvider.Initialize(new TraceOutput("192.168.0.3", 6666));
            TracesProvider.Initialize(new TraceOutput("139.10.85.145", 6666));

            string appPath = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            string initial = new Uri(appPath).LocalPath;
            string path = System.IO.Path.GetDirectoryName(initial);

            Starter.Start(path, true, initial);

            Starter.Shutdown(0);

            TracesProvider.TracesOutput.OutputTrace("End");
        }

        public void Start(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("Application's starting\n");
            context.BundleEvent += new BundleEventHandler(OnBundleChanged);
            IBundle bundle = context.Install(@".\Bundle.dll");
            bundle.Start();
        }

        public void Stop(IBundleContext context)
        {
            context.BundleEvent -= new BundleEventHandler(OnBundleChanged);
            TracesProvider.TracesOutput.OutputTrace("Application's stopping\n");
            context = null;
        }

        void OnBundleChanged(object sender, BundleEventArgs e)
        {
            TracesProvider.TracesOutput.OutputTrace(String.Format("Bundle changed - Id: {0} - Transition: {1}\n", e.Bundle.Id, e.Transition));
        }
    }
}
