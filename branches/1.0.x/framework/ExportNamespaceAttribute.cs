using System;

namespace Physalis.Specs
{
	/// <summary>
	/// 
	/// </summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public class ExportNamespaceAttribute : System.Attribute
	{
		private string exports;

        public string[] Exports
        {
            get
            {
                return null;
            }
        }

        public ExportNamespaceAttribute(string exports)
		{
            this.exports = exports;
		}
	}
}
