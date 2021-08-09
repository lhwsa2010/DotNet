using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Tool
{
    /// <summary>
    /// UrlEncoder
    /// </summary>
    public static class UrlEncoder
    {
        private const string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~.-_";

        /// <summary>
        /// Encode url.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Encode(string value,string charset = "UTF-8")
        {
            if (value == null)
                return String.Empty;

            var bytes = Encoding.GetEncoding(charset).GetBytes(value);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (byte b in bytes)
            {
                char c = (char)b;
                if (unreservedChars.IndexOf(c) >= 0)
                    sb.Append(c);
                else
                    sb.Append(String.Format("%{0:X2}", b));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decode url.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>

        public static string Decode(string value, string charset = "UTF-8")
        {
            if (value == null)
                return String.Empty;

            char[] chars = value.ToCharArray();

            List<byte> buffer = new List<byte>(chars.Length);
            for (int i = 0; i < chars.Length; i++)
            {
                if (value[i] == '%')
                {
                    byte decodedChar = (byte)Convert.ToInt32(new string(chars, i + 1, 2), 16);
                    buffer.Add(decodedChar);

                    i += 2;
                }
                else
                {
                    buffer.Add((byte)value[i]);
                }
            }

            return Encoding.GetEncoding(charset).GetString(buffer.ToArray(), 0, buffer.Count);
        }
    }
}