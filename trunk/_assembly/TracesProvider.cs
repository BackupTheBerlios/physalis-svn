using System;

namespace Physalis.Utils
{
	/// <summary>
	/// Used to access the ITraceOutput object.
	/// </summary>
    public class TracesProvider
    {
        private static ITracesOutput output;

        private TracesProvider()
        {
        }
        
        public static ITracesOutput TracesOutput
        {
            get
            {
                return output;
            }
        }

        public static void Initialize(ITracesOutput trace)
        {
            output = trace;
            if(output == null)
            {
                throw new ArgumentNullException("Forbidden");
            }
        }
    }
}
