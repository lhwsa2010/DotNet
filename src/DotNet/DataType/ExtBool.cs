using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// bool
    /// </summary>
    public static class ExtBool
    {
        /// <summary>
        /// 传入true返回1，反之为0
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetInt(this bool b)
        {
            if (b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
