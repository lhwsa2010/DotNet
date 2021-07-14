using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace System
{
    public class ProcessKeyword
    {
        /// <summary>
        /// 过滤sql注入,并在每个字符前加%(默认加单引号)
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static string addSplit(string keyword)
        {
            return addSplit(keyword, true);
        }

        /// <summary>
        /// 过滤sql注入,开头和结尾处加%（默认加单引号）
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static string addBeginEnd(string keyword)
        {
            if (keyword.Length > 0)
            {
                return "'%" + keyword.FilterSql().Subs(50) + "%'";
            }
            else
            {
                return "";
            }
        }

        public static string addSplit(string keyword, bool danyin)
        {
            if (keyword.Length > 0)
            {
                keyword = Regex.Replace(keyword.FilterSql().Replace(" ", "").Subs(50), "\\w", "%$0");
                if (danyin)
                {
                    return "'" + keyword + "%'";
                }
                else
                {
                    return "%" + keyword + "%";
                }
            }
            else
            {
                return "";
            }
        }
    }
}
