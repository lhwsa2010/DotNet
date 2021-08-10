using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Tool
{
    /// <summary>
    /// undone
    /// </summary>
    public class Pub
    {
        /// <summary>
        /// 获取二进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string get_to_2(string s)
        {
            var len = s.Length;

            #region 做到s的长度可以被2整除

            if (len != (len / 2) * 2)
            {
                s = "0" + s;
                len++;
            }

            #endregion 做到s的长度可以被2整除

            var res = "";
            for (int i = 0; i < len; i++)
            {
                var a = Convert.ToInt32(s[i].ToString(), 16);
                var b = Convert.ToString(a, 2);
                res = res + b.PadLeft(4, '0');
            }
            return res;

            //var b = Convert.ToString(Convert.ToInt64(s, 16), 2);
            //return b.PadLeft(s.Length * 4, '0');
        }

        /// <summary>
        /// 16进制字符串转换为10进制
        /// </summary>
        /// <param name="x16"></param>
        /// <returns></returns>
        public static long x16_to_10(string x16)
        {
            return Convert.ToInt64(x16, 16);
        }

        /// <summary>
        /// 16进制字符串转换为2进制(自动补齐8位)
        /// </summary>
        /// <param name="x16"></param>
        /// <returns></returns>
        public static string x16_to_2(string x16)
        {
            //x16.Lenght/2*8
            return Convert.ToString(Convert.ToInt64(x16, 16), 2).PadLeft(x16.Length * 4, '0');
        }

        /// <summary>
        /// 2进制转换为10进制
        /// </summary>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static int x2_to_10(string x2)
        {
            return Convert.ToInt32(x2, 2);
        }

        /// <summary>
        /// 10进制转换为2进制（默认为8位整数倍）
        /// </summary>
        /// <param name="x10"></param>
        /// <param name="rlen">取右侧多少位</param>
        /// <returns></returns>
        public static string x10_to_2(long x10, int rlen = 0)
        {
            var s = Convert.ToString(x10, 2);
            if (s.Length % 8 > 0)
            {
                s = s.PadLeft(s.Length + (8 - s.Length % 8), '0');
            }
            if (rlen > 0)
            {
                s = s.Right(rlen).PadLeft(rlen, '0');
            }
            return s;
        }
    }
}
