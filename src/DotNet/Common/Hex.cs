using System;
using System.Linq;

namespace DotNet.Hex
{
    /// <summary>
    /// Hex
    /// </summary>
    public static class Hex
    {
        /// <summary>
        /// Convert hex string to byte array.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] FromHex(this string s)
        {
            return Enumerable.Range(0, s.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(s.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Convert byte array to hex string.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>

        public static string ToHex(this byte[] bytes)
        {
            return string.Concat(bytes.Select(b => b.ToString("X2")));
        }
    }
}
