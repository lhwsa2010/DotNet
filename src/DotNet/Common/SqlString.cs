using System.Text.RegularExpressions;

namespace System
{
    public static class SqlString
    {
        /// <summary>
        /// Filter sql injection.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FilterSql(this string s)
        {
            if (s == null)
                return "";
            s = Regex.Replace(s, "--", "——", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "'", "‘", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, @"\s+", " ");
            s = Regex.Replace(s, "delete ", "delete", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "update ", "update", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "select ", "select", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "union ", "union", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "create ", "create", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "drop ", "drop", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "alter ", "alter", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, ";", "", RegexOptions.IgnoreCase);
            return s;
        }

        /// <summary>
        /// Check the sql string whether is safe.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>return bool result</returns>
        public static bool IsSafeSqlString(this string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }



        /// <summary>
        /// Filter sql injection, add % and ' at start and end of string.
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static string addBeginEnd(this string keyword)
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

        /// <summary>
        /// Filter sql injection,add % at every single char of string.
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="singleQuotes"></param>
        /// <returns></returns>
        public static string addSplit(this string keyword, bool single=default)
        {
            if (keyword.Length > 0)
            {
                keyword = Regex.Replace(keyword.FilterSql().Replace(" ", "").Subs(50), "\\w", "%$0");
                if (single)
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
