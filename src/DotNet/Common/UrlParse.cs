using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public static class UrlParse
    {
        public static Dictionary<string, string> Parse(this string formUrlEncodedValue)
        {

            if (formUrlEncodedValue == null)
                throw new ArgumentNullException("formUrlEncodedValue");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (formUrlEncodedValue.Contains("&") || formUrlEncodedValue.Contains("="))
            {
                var pairs = formUrlEncodedValue.Split('&');
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