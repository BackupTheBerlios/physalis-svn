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
        IBundleContext context;

        static void Main(string[] args)
        {
//            TracesProvider.Initialize(new TraceOutput("169.254.25.129", 6666));
            TracesProvider.Initialize(new TraceOutput("192.168.0.3", 6666));

//            string[] initials = new string[] {@".\Bundle.dll"};
            Uri uri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string[] initials = new string[] { uri.AbsolutePath };
            Starter.Start(initials);

            Starter.Shutdown(0);

            TracesProvider.TracesOutput.OutputTrace("End");
        }

        public void Start(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("Application's starting");
            this.context = context;
            IBundle bundle = this.context.Install(@".\Bundle.dll");
            bundle.Start();
        }

        public void Stop(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("Application's stopping");
            this.context = null;
        }
    }
}
