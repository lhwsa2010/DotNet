﻿namespace System
{
    /// <summary>
    /// Float Extends
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
