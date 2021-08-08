using System.Configuration;

namespace DotNet.Tool
{
    public class Cfg
    {
		/// <summary>
		/// Attempts to find a value with the given key for the current application's default configuration.
		/// </summary>
		/// <param name="key">key</param>
		/// <returns></returns>
		public static string Get(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}
