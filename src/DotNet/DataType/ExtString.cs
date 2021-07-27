using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
        /// substring.If string is null or empty return empty.
        /// If param length is big than string's length,return string,
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
        /// 删除html代码，保留文本值
        /// </summary>
        /// <param name="htmlstring"></param>
        /// <returns></returns>
        public static string DeleteHMTL(this string htmlstring)
        {
            htmlstring = Regex.Replace(htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "</P>", "\n", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "<br>", "\n", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(iexcl|#161);", "\x00a1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(cent|#162);", "\x00a2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(pound|#163);", "\x00a3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, "&(copy|#169);", "\x00a9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            htmlstring.Replace("<", "");
            htmlstring.Replace(">", "");
            return htmlstring;
        }


        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="strHtml">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string StripHTML(this string strHtml)
        {
            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<script>内容</script>为空格
            string regex_str = "(?is)<script[^>]*>.*?</script>";//替换<script>内容</script>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str="<script type=\\s*[^>]*>[^<]*?</script>";//替换<style>内容</style>为空格
            regex_str = "(?is)<style[^>]*>.*?</style>";//替换<style>内容</style>为空格
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "(&nbsp;)+";//替换&nbsp;为空格
            regex_str = "(?i)&nbsp;";//替换&nbsp;为空格
            strHtml = Regex.Replace(strHtml, regex_str, " ");

            //regex_str = "(\r\n)*";//替换\r\n为空
            regex_str = @"[\r\n]*";//替换\r\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //regex_str = "<[^<]*>";//替换Html标签为空
            regex_str = "<[^<>]*>";//替换Html标签为空
            strHtml = Regex.Replace(strHtml, regex_str, "");

            //regex_str = "\n*";//替换\n为空
            regex_str = @"\n*";//替换\n为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);

            //可以这样
            regex_str = "\t*";//替换\t为空
            strHtml = Regex.Replace(strHtml, regex_str, "", RegexOptions.IgnoreCase);
            //可以
            regex_str = "'";//替换'为’
            strHtml = Regex.Replace(strHtml, regex_str, "’", RegexOptions.IgnoreCase);

            //可以
            regex_str = " +";//替换若干个空格为一个空格
            strHtml = Regex.Replace(strHtml, regex_str, "  ", RegexOptions.IgnoreCase);

            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);

            string strOutput = regex.Replace(strHtml, "");//替换掉"<"和">"之间的内容
            strOutput = strOutput.Replace("<", ""); strOutput = strOutput.Replace(">", "");
            strOutput = strOutput.Replace("&nbsp;", "");


            return strOutput;
        }





        /// <summary>
        /// 取字符串左侧多少个字符，如果超出字符串长度，则直接返回字符串
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
        /// 取字符串右侧多少个字符，如果超出字符串长度，则直接返回字符串
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

        //--------------2012-11-21 XYC添加 --------------------------------

        /// <summary>
        /// 去掉最尾部一个字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CutTail(this string s)
        {
            if (s.Length > 0)
                return s.Substring(0, s.Length - 1);
            else
                return "";
        }

        /// <summary>
        /// 去掉首部尾部各一个字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string CutHeadAndTail(this string s)
        {
            if (s.Length >= 2)
            {
                return s.Substring(1, s.Length - 2).CutTail();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <param name="tail"></param>
        /// <returns></returns>
        public static string CutStr(this string str, int len, string tail)
        {
            str = str.Replace("?", "^");
            byte[] aArr = System.Text.Encoding.Default.GetBytes(str);
            len = len * 2;
            if (aArr.Length > len)
            {
                str = System.Text.Encoding.Default.GetString(aArr, 0, len).Replace("?", "").Replace("^", "?");
                return str + tail;

            }
            else
            {
                return str;
            }
        }

    }
}