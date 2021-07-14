using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// object
    /// </summary>
    public static class ExtObject
    {
        /// <summary>
        /// object to string (如果为null值则返回"")
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetString(this object s)
        {
            if ((Object.Equals(s, null)) || (Object.Equals(s, System.DBNull.Value)))
            {
                return "";
            }
            else
            {
                return s.ToString();
            }
        }

        ///// <summary>
        ///// object to int (如果为null值则返回0)
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static int GetInt(this object s)
        //{
        //    return s.GetString().GetInt();
        //}
        ///// <summary>
        ///// object to float (如果为null值则返回0)
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static float GetFloat(this object s)
        //{
        //    return s.GetString().GetFloat();
        //}

        ///// <summary>
        ///// object to decimal (如果为null值则返回0)
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static decimal GetDecimal(this object s)
        //{
        //    return s.GetString().GetDecimal();
        //}

        ///// <summary>
        ///// object to double (如果为null值则返回0)
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static double GetDouble(this object s)
        //{
        //    return s.GetString().GetDouble();
        //}

        ///// <summary>
        ///// object to Datetime (如果为null值则返回当前时间)
        ///// </summary>
        ///// <param name="s"></param>
        ///// <returns></returns>
        //public static DateTime GetDateTime(this object s)
        //{
        //    return s.GetString().GetDateTime();
        //}
    }
}