using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class ExtRegex
    {

        /// <summary>
        /// Searches the string for the first occurrence of the specified regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns></returns>
        public static string Match(this string s, string pattern)
        {
            if (s == null)
                return "";
            return Regex.Match(s, pattern, RegexOptions.IgnoreCase).Value;
        }

        /// <summary>
        /// Searches the string for the all occurrences of the specified regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns></returns>
        public static MatchCollection Matches(this string s, string pattern)
        {
            return Regex.Matches(s, pattern, RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// Searches the string for the first occurrence of the specified regular expression.
        /// </summary>
        /// <param name="left">left string</param>
        /// <param name="right">right string</param>
        /// <returns></returns>
        public static string Match(this string s, string left, string right)
        {
            MatchCollection matchs = s.Matches(left, right);
            if (matchs.Count > 0)
                return matchs[0].Value;
            return "";
        }

        /// <summary>
        /// Searches the string for the all occurrences of the specified regular expression.
        /// </summary>
        /// <param name="left">left string</param>
        /// <param name="right">right string</param>
        /// <returns></returns>
        public static MatchCollection Matches(this string s, string left, string right)
        {
            return Regex.Matches(s, $"(?<={left})[\\d\\D]*?(?={right})", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Indicates whether the specified regular expression finds a match in the string, using the specified matching options.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <returns></returns>
        public static bool IsMatch(this string s, string pattern)
        {
            return s != null && Regex.IsMatch(s, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// In a string, replaces all strings that match a specified regular expression with a specified replacement string. Specified options modify the matching operation.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns></returns>
        public static string RegReplace(this string s, string pattern, string replacement)
        {
            return Regex.Replace(s, pattern, replacement, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// In a string, replaces all strings that match a specified regular expression with a string returned by a System.Text.RegularExpressions.MatchEvaluator delegate. Specified options modify the matching operation.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="evaluator">A custom method that examines each match and returns either the original matched string or a replacement string.</param>
        /// <returns></returns>
        public static string RegReplace(this string s, string pattern, MatchEvaluator evaluator)
        {
            return Regex.Replace(s, pattern, evaluator, RegexOptions.IgnoreCase);
        }
    }
}
