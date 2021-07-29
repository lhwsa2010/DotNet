using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// double
    /// </summary>
    public static class ExtDouble
    {
        /// <summary>
        /// convert nullable double to double
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double GetDouble(this double? d)
        {
            return d ?? default;
        }
    }
}
