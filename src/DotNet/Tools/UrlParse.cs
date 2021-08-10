using System;
using System.Collections.Generic;

namespace DotNet.Tool
{
    /// <summary>
    /// UrlParse
    /// </summary>
    public static class UrlParse
    {
        /// <summary>
        /// Parse form url value.
        /// </summary>
        /// <param name="formUrlValue"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Parse(string formUrlValue)
        {

            if (formUrlValue == null)
                throw new ArgumentNullException("formUrlValue");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (formUrlValue.Contains("&") || formUrlValue.Contains("="))
            {
                var pairs = formUrlValue.Split('&');
                foreach (var pair in pairs)
                {
                    var nameValue = pair.Split('=');
                    if (nameValue.Length < 2)
                        continue;
                    dic.Add(nameValue[0], UrlEncoder.Decode(nameValue[1]));
                }
            }
            return dic;
        }
    }
}