using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


namespace DotNet.Tool
{
    public class Cfg
    {
		/// <summary>
		/// 获取配置文件AppSettings的值
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string Get(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}
