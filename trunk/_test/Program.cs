#region Using directives

using System;
using System.Text;
using Physalis.Framework;
using Physalis.Utils;

#endregion

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TracesProvider.Initialize(new TraceOutput("169.254.25.129", 6666));
//            TracesProvider.Initialize(new TraceOutput("192.168.0.2", 6666));

            string[] initials = new string[] {@".\Bundle.dll"};
            Starter.Start(initials);

            Starter.Shutdown(0);

            TracesProvider.TracesOutput.OutputTrace("End");
        }
    }
}
