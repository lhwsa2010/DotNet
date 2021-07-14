using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class Hex
    {
        public static byte[] FromHex(this string s)
        {
            return Enumerable.Range(0, s.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(s.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string ToHex(this byte[] bytes)
        {
            return string.Concat(bytes.Select(b => b.ToString("X2")));
        }
    }
}
