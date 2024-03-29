﻿using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// HtmlString Extends
    /// </summary>
    public static class HtmlString
    {
        /// <summary>
        /// HtmlEncode
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToEncode(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            return System.Web.HttpUtility.HtmlEncode(s.Trim());
        }

        /// <summary>
        /// HtmlDecode
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToDecode(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";
            return System.Web.HttpUtility.HtmlDecode(s.Trim());
        }


        /// <summary>
		/// delete html code,reserve content
		/// </summary>
		/// <param name="htmlstring"></param>
		/// <returns></returns>
		public static string DeleteHMTL(this string htmlstring)
        {
            htmlstring = Regex.Replace(htmlstring, "<.*?>", "", RegexOptions.IgnoreCase);
            return htmlstring;
        }


    }
}
