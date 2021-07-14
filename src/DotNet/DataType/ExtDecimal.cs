using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// decimal
    /// </summary>
    public static class ExtDecimal
    {
        /// <summary>
        /// decimal? to decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal GetDecimal(this decimal? d)
        {
            decimal s = 0;
            if (d.HasValue)
            {
                decimal.TryParse(d.GetString(), out s);
            }
            return s;
        }
    }
}
