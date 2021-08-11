using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class ExtByte
    {
        /// <summary>
        /// Changes the number of elements of a one-dimensional array to the specified new size.
        /// </summary>
        /// <param name="size">The size of the new array.</param>
        /// <returns></returns>
        public static byte[] Resize(this byte[] bytes,int size)
        {
            Array.Resize(ref bytes, size);
            return bytes;
        }
    }
}
