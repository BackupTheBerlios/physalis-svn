using System;

namespace Physalis.Utils
{
	/// <summary>
	/// Used to access the ITraceOutput object.
	/// </summary>
    public class TracesOutputProvider
    {
        private static ITracesOutput output;

        private TracesOutputProvider()
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
