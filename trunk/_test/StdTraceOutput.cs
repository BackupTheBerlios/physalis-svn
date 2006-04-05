using System;
using System.Diagnostics;
using Physalis.Utils;

namespace Test
{
    /// <summary>
    /// Standard output to the console.
    /// </summary>
    public class StdTraceOutput : ITracesOutput
    {
        public void OutputTrace(string trace)
        {
            Debug.WriteLine("---" + trace);
        }
    }
}

