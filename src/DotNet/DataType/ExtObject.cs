using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// Object Extends
    /// </summary>
    public static class ExtObject
    {
        /// <summary>
        /// object to string (if object is null return string empty)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetString(this object s)
        {
            if ((Object.Equals(s, null)) || (Object.Equals(s, System.DBNull.Value)))
                return "";
            return s.ToString();
        }


    }
}