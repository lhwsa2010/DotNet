using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// string Extends
    /// </summary>
    public static class ExtString
    {
        /// <summary>
        /// check the string value is null or empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns>bool</returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// convert string to int
        /// </summary>
        /// <param name="s">string</param>
        /// <returns></returns>
        public static int GetInt(this string s)
        {
            int.TryParse(s, out int i);
            return i;
        }

        /// <summary>
        /// convert string to long
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long GetLong(this string s)
        {
            long.TryParse(s, out long i);
            return i;
        }

        /// <summary>
        /// convert string to bool,if string is null or string empty or false,return false,else return true
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool GetBool(this string s)
        {
            return s switch
            {
                null => false,
                "" => false,
                "0" => false,
                string value when value.Equals("false", StringComparison.OrdinalIgnoreCase) => false,
                _ => true
            };
        }

        /// <summary>
        /// convert string to decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal GetDecimal(this string s)
        {
            decimal.TryParse(s, out decimal d);
            return d;
        }

        /// <summary>
        /// convert string to double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double GetDouble(this string s)
        {
            double.TryParse(s, out double d);
            return d;
        }

        /// <summary>
        /// convert string to float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float GetFloat(this string s)
        {
            float.TryParse(s, out float f);
            return f;
        }

        /// <summary>
        /// convert string to datetime,if string is not time format,return current time
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this string s)
        {
            if (s.IsNullOrEmpty())
                return DateTime.Now;
            DateTime.TryParse(s, out DateTime d);
            if (d.ToString("yyyy-MM-dd") == "0001-01-01")
                return DateTime.Now;
            return d;
        }

        
        /// <summary>
        /// substring.If string is null or empty return empty.
        /// If param length is bigger than string's length,return string,
        /// else substring of length string with suffix.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public static string Subs(this string s, int length, string suffix= "")
        {
            s=s.GetString();
            if (s.Length > length)
                s = s.Substring(0, length) + suffix;
            return s;
        }

        /// <summary>
		/// substring start at a specified character position and has a specified length.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="index"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string Subs(this string s, int startIndex, int length)
        {
            s=s.GetString();
            if (s.Length >= startIndex + length)
                return s.Substring(startIndex, length);
            return s;
        }



        /// <summary>
        /// convert string to base64
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToBase64(this string s)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(s));
        }

        /// <summary>
        /// convert to string from base64
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FromBase64(this string s)
        {
            return System.Text.Encoding.Default.GetString(Convert.FromBase64String(s));
        }


        /// <summary>
        /// Get count of chars start left.If param count is bigger than length of string ,return string direct.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Left(this string s, int count)
        {
            s = s.GetString();
            if (s.Length > count)
            {
                return s.Substring(0, count);
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Get count of chars start right.If param count is bigger than length of string ,return string direct.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Right(this string s, int count)
        {
            
            s = s.GetString();
            int startindex = 0;
            if (s.Length > count)
            {
                startindex = s.Length - count;
            }
            else
            {
                startindex = 0;
                count = s.Length;
            }
            return s.Substring(startindex, count);
        }

       

    }
}