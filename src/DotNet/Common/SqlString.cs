using System;
using System.Text.RegularExpressions;

namespace System
{
    public static class SqlString
    {
        /// <summary>
        /// 过滤sql注入的相关字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FilterSql(this string s)
        {
            return s.Replace("--", "").Replace("'", "").Replace("delete ", "delete").Replace("update ", "update").Replace("select ", "select");
        }

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
    }
}
