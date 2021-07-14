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
        /// 可空double类型转换为double.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double GetDouble(this double? d)
        {
            double s = 0;
            if (d.HasValue)
            {
                double.TryParse(d.GetString(), out s);
            }
            return s;
        }
    }
}
