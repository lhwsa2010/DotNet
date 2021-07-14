using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 对string类型的扩展
    /// </summary>
    public static class ExtString
    {
        /// <summary>
        /// 判断是否是null或者空字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 转换成int类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int GetInt(this string s)
        {
            int i = 0;
            int.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// 转换成long类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long GetLong(this string s)
        {
            long i = 0;
            long.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// 转换成bool型，(null,"",0,false 为 false,其他是true)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool GetBool(this string s)
        {
            if (s == null)
            {
                return false;
            }
            if (s == "" || s == "0" || s.ToLower() == "false")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 字符串转换为decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal GetDecimal(this string s)
        {
            decimal d = 0;
            decimal.TryParse(s, out d);
            return d;
        }

        /// <summary>
        /// 字符串转为double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double GetDouble(this string s)
        {
            double d = 0;
            double.TryParse(s, out d);
            return d;
        }

        /// <summary>
        /// 字符串转为float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float GetFloat(this string s)
        {
            float f = 0;
            float.TryParse(s, out f);
            return f;
        }

        /// <summary>
        /// 字符串转时间类型，如果string不是时间格式的，直接返回当天时间
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this string s)
        {
            DateTime d = DateTime.Now;
            if (!string.IsNullOrEmpty(s))
            {
                DateTime.TryParse(s, out d);
            }
            if (d.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                return DateTime.Now;
            }
            else
            {
                return d;
            }
        }

        /// <summary>
        /// HtmlEncode
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToEncode(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            else
            {
                return System.Web.HttpUtility.HtmlEncode(s.Trim());
            }
        }

        /// <summary>
        /// HtmlEncode
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToDecode(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            else
            {
                return System.Web.HttpUtility.HtmlDecode(s.Trim());
            }
        }

        /// <summary>
        /// 截取字符串，大于length，返回length-2+"..",否则直接返回s
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Subs(this string s, int length)
        {
            return Subs(s, length, "..");
        }

        /// <summary>
        /// 截取字符串，大于length，返回length+后缀,否则直接返回s
        /// </summary>
        /// <param name="s"></param>
        /// <param name="length"></param>
        /// <param name="houzhui"></param>
        /// <returns></returns>
        public static string Subs(this string s, int length, string houzhui)
        {
            if (s.Length > length)
            {
                s = s.Substring(0, length) + houzhui;
            }
            return s;
        }

        /// <summary>
        /// 加密成base64
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToBase64(this string s)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(s));
        }

        /// <summary>
        /// 解密base64
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




        ///// <summary>
        ///// 正则表达式判断是否匹配
        ///// </summary>
        ///// <param name="s"></param>
        ///// <param name="pattern"></param>
        ///// <returns></returns>
        //public static bool IsMatch(this string s, string pattern)
        //{
        //    if (s == null)
        //        return false;
        //    else
        //        return Regex.IsMatch(s, pattern);
        //}

        ///// <summary>
        ///// 正则表达式匹配字符串
        ///// </summary>
        ///// <param name="s"></param>
        ///// <param name="pattern"></param>
        ///// <returns></returns>
        //public static string Match(this string s, string pattern)
        //{
        //    if (s == null)
        //        return "";
        //    return
        //        Regex.Match(s, pattern).Value;
        //}

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