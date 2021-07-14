using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// float
    /// </summary>
    public static class ExtFloat
    {
        /// <summary>
        /// float? to float
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static float GetFloat(this float? d)
        {
            float s = 0;
            if (d.HasValue)
            {
                float.TryParse(d.GetString(), out s);
            }
            return s;
        }
    }
}
