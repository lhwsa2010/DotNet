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
        
        /// <summary>
        /// Save a keyvalue configuration element object to the appsetings.If newkey is existed in the collection,modifie it,otherwise add new keyvalue to the collection.
        /// </summary>
        /// <param name="newKey">key</param>
        /// <param name="newValue">value</param>
        public static void Save(string newKey, string newValue)
        {
            bool isModified = !string.IsNullOrEmpty(ConfigurationManager.AppSettings[newKey]);
            // Open App.Config of executable
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // You need to remove the old settings object before you can replace it
            if (isModified)
                config.AppSettings.Settings.Remove(newKey);
            // Add an Application Setting.
            config.AppSettings.Settings.Add(newKey, newValue);
            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);
            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}
