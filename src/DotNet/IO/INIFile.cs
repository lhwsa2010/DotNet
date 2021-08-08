using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace DotNet.Tool
{
    /// <summary>
    /// Only used on windows.
    /// </summary>
    public class INIFile
    {
        private string _path;

        /// <summary>
        /// Initializes a new instance of INIFile.
        /// </summary>
        /// <param name="INIPath">ini file path</param>
        public INIFile(string INIPath)
        {
            _path = INIPath;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        /// <summary>
        /// Sets a value for a given key.
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, _path);
        }

        /// <summary>
        /// Attempts to find a value with the given key.
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, _path);
            return temp.ToString();
        }

        /// <summary>
        /// Attempts to find a value with the given key.
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        public byte[] IniReadValueByte(string section, string key)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, "", temp, 255,_path);
            return temp;
        }

        /// <summary>
        /// Attempts to remove all values.(Not Work)
        /// </summary>
        public void ClearAllSection()
        {
            IniWriteValue(null, null, null);
        }

        /// <summary>
        /// Attempts to remove all values with the given section.
        /// </summary>
        /// <param name="section">section</param>
        public void ClearSection(string section)
        {
            IniWriteValue(section, null, null);
        }

        
    }
}