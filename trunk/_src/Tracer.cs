using System;

namespace Physalis
{
	/// <summary>
	/// Summary description for Tracer.
	/// </summary>
	public class Tracer
	{
		public Tracer()
		{
		}

        public void Start()
        {
            // TODO: Register framework listener
            
            if(Starter.Reset)
            {
                // TODO: Register bundle listener
            }
        }

        public void Stop()
        {
            // TODO: Remove framework listener
            
            if(Starter.Reset)
            {
                // TODO: Remove bundle listener
            }
        }
	}
}
