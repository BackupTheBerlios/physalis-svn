/*=======================================================================================

	OpenNETCF.Configuration.ConfigurationSettings
	Copyright © 2003, OpenNETCF.org

	This library is free software; you can redistribute it and/or modify it under 
	the terms of the OpenNETCF.org Shared Source License.

	This library is distributed in the hope that it will be useful, but 
	WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or 
	FITNESS FOR A PARTICULAR PURPOSE. See the OpenNETCF.org Shared Source License 
	for more details.

	You should have received a copy of the OpenNETCF.org Shared Source License 
	along with this library; if not, email licensing@opennetcf.org to request a copy.

	If you wish to contact the OpenNETCF Advisory Board to discuss licensing, please 
	email licensing@opennetcf.org.

	For general enquiries, email enquiries@opennetcf.org or visit our website at:
	http://www.opennetcf.org

=======================================================================================*/
using System.Collections;
using System.Diagnostics;
using System;
using System.Xml;
using System.IO;
using System.Reflection;

namespace OpenNETCF.Configuration
{
	/*
			Settings class
			--	
			Read and write settings to an XML .config file. Does not use 
			ConfigurationSettings.AppSettings since it's not supported on 
			.NET Compact Framework. 
			
			Uses same schema as app.config file. Example:

				<configuration>
					<appSettings>
						<add key="Name" value="Live Oak" />
						<add key="LogEvents" value="True" />
					</appSettings>
				</configuration>	
			
			Default settings file name is the same as app.config, 
			appends .config to the end of the assembly name. Example:
			
				<appname.exe>.config
		*/
	/// <summary>
	/// Read and write settings to an XML config file.
	/// </summary>
	public sealed class DllConfigurationSettings : IDisposable
	{
		#region  ------------- MEMBER VARIABLES -------------
		private Hashtable _list = new Hashtable();
		private string _filePath = "app.Config";
		private bool _autoWrite = false;
		private string[,] _defaultValues;
		private bool disposed = false;
		#endregion

		#region  ------------- PUBLIC PROPERTIES -------------
	
		/// <summary>
		/// If set to true the settings file will be written automatically.
		/// If set to false the Write method will have to be called or 
		/// else data will be lost if changed.
		/// </summary>
		public  bool AutoWrite
		{
			get { return _autoWrite; }
			set { _autoWrite = value; }
		}
	
		/// <summary>
		/// Full path for the settings file
		/// </summary>
		public string FilePath
		{
			get { return _filePath; }
			set { _filePath = value; }
		}

		/// <summary>
		/// Gets the _list hashtable.
		/// </summary>
		public Hashtable List
		{
			get { return this._list; }
		}

		/// <summary>
		/// Returns the app settings from the config file.
		/// </summary>
		public static Hashtable DllSettings
		{
			get { return (new DllConfigurationSettings(Assembly.GetExecutingAssembly().GetName().CodeBase + ".config"))._list; }
		}
		#endregion

		#region  ------------- CONSTRUCTORS/DESTRUCTORS -------------
		/// <summary>
		/// Default constructor. 
		/// </summary>
		public DllConfigurationSettings()
		{
			this._filePath = Assembly.GetExecutingAssembly().GetName().CodeBase + ".config";

			// populate list with settings from file
			Read();			
		}

		/// <summary>
		/// Overridden Constructor. Pass the path to the config file.<br/>
		///		<code>
		///		ConfigurationSettings configSettings = new Configuration(@"\Program Files\MyApp\MyApp.exe.config");		
		///		</code>
		/// </summary>
		/// <param name="configFilePath">The path to the XML configuration file.</param>
		public DllConfigurationSettings(string configFilePath)
		{
			this._filePath = configFilePath;

			// populate list with settings from file
			Read();	
		}

		/// <summary>
		/// Overridden Constructor. Pass in an array of default values.<br/>
		///		<code>
		///		BaseCfgReader Settings = new ConfigurationSettings(new string[,] 
		///		{{"postURL","http://192.168.111.100"},
		///		{"username","Mark"},
		///		});	
		///		</code>
		/// </summary>
		public DllConfigurationSettings(string[,] defaultValues)
		{
			// store default values, use later when populate list
			_defaultValues = defaultValues;

			this._filePath = Assembly.GetCallingAssembly().GetName().CodeBase + ".config";

			// populate list with settings from file
			Read();
			
			//Set to autowrite
			this._autoWrite=true;
		}
	
		/// <summary>
		/// Destructor
		/// </summary>
		~DllConfigurationSettings()
		{
			Dispose(false);
		}
		#endregion

		#region  ------------- PUBLIC METHODS -------------
	
		/// <summary>
		/// Set the value of a key
		/// <code>
		/// Settings.SetValue("locationCode","123");
		/// </code>
		/// </summary>
		public void SetValue(string key, object value)
		{
			// update internal list
			_list[key] = value;
		
			// update settings file
			if (_autoWrite)
				Write();
		}

		/// <summary>
		/// Return specified settings as string. Returns null if the value is not found
		/// </summary>
		public string GetString(string key)
		{
			object result = _list[key];
			return (result == null) ? null : result.ToString();
		}
	
		/// <summary>
		/// Return specified settings as integer. Returns null if the value is not found
		/// </summary>
		public Int32 GetInt(string key)
		{
			string result = GetString(key);
			return (result == "") ? 0 : Convert.ToInt32(result);
		}

		/// <summary>
		/// Return specified settings as boolean. Returns false if the value is not found
		/// </summary>
		public bool GetBool(string key)
		{
			string result = GetString(key);
			return (result == "") ? false : Convert.ToBoolean(result);
		}
			
		/// <summary>
		/// Read settings file.
		/// </summary>
		public void Read()
		{
			//remove all items from list
			_list.Clear();
		
			//populate list with items from file	
			//open settings file
			if (File.Exists(_filePath))
			{
				XmlTextReader reader = new XmlTextReader(_filePath);

				// populate internal list with 'add' elements
				while (reader.Read())
				{
					if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "add"))
						_list[reader.GetAttribute("key")] = reader.GetAttribute("value");
				}
				reader.Close();
			}

			// next, populate list with default values
			if(this._defaultValues != null) 
			{
				for (Int32 i=0; i < _defaultValues.GetLength(0); i++)
					_list[_defaultValues[i,0]] = _defaultValues[i,1];
			}
		}
	
		/// <summary>
		/// Write settings to the .config file.
		/// </summary>
		public void Write()
		{
			// header elements
			using (StreamWriter writer = File.CreateText(_filePath))
			{
				writer.WriteLine("<configuration>");
				writer.WriteLine("\t<dllSettings>");

				// go through internal list and create 'add' element for each item
				IDictionaryEnumerator enumerator = _list.GetEnumerator();
				while (enumerator.MoveNext())
				{
					writer.WriteLine("\t\t<add key=\"{0}\" value=\"{1}\" />",
						enumerator.Key.ToString(),
						enumerator.Value);
				}

				// footer elements
				writer.WriteLine("\t</dllSettings>");
				writer.WriteLine("</configuration>");

				writer.Close();
			}
		}

		/// <summary>
		/// Overwrite settings with default values.
		/// </summary>
		public void RestoreDefaults()
		{
			try
			{
				// easiest way is to delete the file and
				// repopulate internal list with defaults
				File.Delete(FilePath);
				Read();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
		#endregion

		#region ------------- IDisposable Members -------------

		/// <summary>
		/// 
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposeManagedResources"></param>
		private void Dispose(bool disposeManagedResources)
		{
			if(!this.disposed)
			{				
				if(this._autoWrite)
					Write();

				this.disposed = true;
			}
			else 
			{
				throw new ObjectDisposedException("ConfigurationSettings");
			}
		}

		#endregion
	}
}
