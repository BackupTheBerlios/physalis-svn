using System;
using Physalis.Framework;


namespace Start
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Start
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
            Starter.Instance.Output = new TraceOutput("192.168.5.2", 6666);

            Starter.Instance.Start();

            Starter.Instance.Output.OutputTrace("End");
        }
	}
}
