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
            TracesOutputProvider.Initialize(new TraceOutput("139.10.85.145", 6666));

            Starter.Start();

            TracesOutputProvider.TracesOutput.OutputTrace("End");
        }
    }
}
