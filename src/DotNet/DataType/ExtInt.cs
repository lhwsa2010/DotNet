using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// int
    /// </summary>
    public static class ExtInt
    {
        /// <summary>
        /// 传入0为false ，反之为true
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool GetBool(this int i)
        {
            bool b = true;

            if (i == 0)
            {
                b = false;
            }
            return b;
        }


        /// <summary>
        /// 传入0或者null值为false ，反之为true
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool GetBool(this int? i)
        {
            bool b = true;
            if (i.HasValue)
            {
                if (i == 0)
                {
                    b = false;
                }
            }
            else
            {
                b = false;
            }
            return b;
        }

        /// <summary>
        ///  传入可空int，返回int，（默认为0）
        /// </summary>
        /// <param name="i">可空int型参数</param>
        /// <returns>true|false</returns>
        public static int GetInt(this int? i)
        {
            return i.GetInt(0);
        }

        /// <summary>
        /// 传入可空int，返回int
        /// </summary>
        /// <param name="i">可空int型参数</param>
        /// <param name="defaultvalue">默认值</param>
        /// <returns></returns>
        public static int GetInt(this int? i, int defaultvalue)
        {
            int b = defaultvalue;
            if (i.HasValue)
            {
                b = i.ToString().GetInt();
            }
            return b;
        }
    }
}
