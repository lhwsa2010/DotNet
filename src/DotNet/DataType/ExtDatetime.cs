using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// DateTime
    /// </summary>
    public static class ExtDatetime
    {
        /// <summary>
        /// datetime? to datetime(格式：例：yyyy-MM-dd hh:mm:ss)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this DateTime? s)
        {
            if (s.HasValue)
            {
                DateTime d = DateTime.Now;
                DateTime.TryParse(s.GetString(), out d);
                return d;
            }
            else
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// datetime? to String
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format">yyyy-MM-dd etc.</param>
        /// <returns></returns>
        public static string GetString(this DateTime? s, string format)
        {
            if (s.HasValue)
            {
                DateTime d = DateTime.Now;
                DateTime.TryParse(s.GetString(), out d);
                return d.ToString(format);
            }
            else
            {
                return DateTime.Now.ToString(format);
            }
        }

        /// <summary>
        /// 2009-09-09 12:30 星期三
        /// </summary>
        /// <param name="dt">传入的时间</param>
        /// <returns>格式：2009-09-09 12:30 星期三</returns>
        public static string Formate(this DateTime dt)
        {
            return Formate(dt, false);
        }

        /// <summary>
        /// 2009-09-09
        /// 12:30 星期三
        /// </summary>
        /// <param name="dt">传入的时间</param>
        /// <param name="br">默认为false不换行，true换行</param>
        /// <returns>br=false格式：2009-09-09 br 12:30 星期三</returns>
        public static string Formate(this DateTime dt, bool br)
        {
            DateTime now = DateTime.Now;
            DateTime date = dt.Date;
            string res = dt.ToString("yyyy-MM-dd");
            if (br)
            {
                res += "<br>" + dt.ToString("HH:mm");
            }
            else
            {
                res += dt.ToString(" HH:mm");
            }
            if (date.CompareTo(now.Date) < 0)
            {
                if (date.AddDays(1).CompareTo(now.Date) == 0)
                {
                    res += " 昨天";
                }
                else if (date.AddDays(2).CompareTo(now.Date) == 0)
                {
                    res += " 前天";
                }
                else
                {
                    res += dt.ToString(" dddd");
                }
            }
            else if (date.CompareTo(now.Date) == 0)
            {
                res += " <span style='color:red;'>今天</span>";
            }
            else
            {
                if (now.Date.AddDays(1).CompareTo(date) == 0)
                {
                    res += " 明天";
                }
                else if (now.Date.AddDays(2).CompareTo(date) == 0)
                {
                    res += " 后天";
                }
                else
                {
                    res += dt.ToString(" dddd");
                }
            }

            return res;
        }
    }
}