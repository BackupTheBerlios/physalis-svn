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
            Starter.Instance.Output = new TraceOutput("localhost", 6666);
        }
	}
}
