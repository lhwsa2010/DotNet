namespace System
{
    /// <summary>
    /// DateTime Extends
    /// </summary>
    public static class ExtDatetime
    {
        /// <summary>
        /// convert nullable DateTime to DateTime.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTime(this DateTime? d)
        {
            return d ?? DateTime.Now;
        }

        /// <summary>
        /// convert nullable DateTime to string(format：i.e：yyyy-MM-dd hh:mm:ss)
        /// </summary>
        /// <param name="format">yyyy-MM-dd etc.</param>
        /// <returns></returns>
        public static string GetString(this DateTime? d, string format)
        {
            return (d ?? DateTime.Now).ToString(format);
        }

        /// <summary>
        /// 将日期转换成`日期+汉字`格式
        /// </summary>
        /// <param name="dt">传入的时间</param>
        /// <param name="br">默认为false不换行，true换行</param>
        /// <returns>br=false格式：2009-09-09 br 12:30 星期三</returns>
        public static string FormatCN(this DateTime dt, bool br=default)
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

        /// <summary>
        /// Get first day of month.
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).Date;
        }

        /// <summary>
        /// Get last day of month.
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.DaysInMonth());
        }

        /// <summary>
        /// Get days in month.
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static int DaysInMonth(this DateTime datetime)
        {
            return DateTime.DaysInMonth(datetime.Year, datetime.Month);
        }

        /// <summary>
        /// 返回日期几
        /// </summary>
        /// <returns></returns>
        public static string DayOfWeekToCN(this DateTime datetime)
        {
            var res = "";
            switch (datetime.DayOfWeek.ToString("D"))
            {
                case "0":
                    res = "日 ";
                    break;
                case "1":
                    res = "一 ";
                    break;
                case "2":
                    res = "二 ";
                    break;
                case "3":
                    res = "三 ";
                    break;
                case "4":
                    res = "四 ";
                    break;
                case "5":
                    res = "五 ";
                    break;
                case "6":
                    res = "六 ";
                    break;
            }
            return res;
        }
    }
}