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
        /// convert nullable float to float
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float GetFloat(this float? f)
        {
            return f ?? default;
        }
    }
}
