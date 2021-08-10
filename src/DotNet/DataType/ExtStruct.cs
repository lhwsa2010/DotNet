using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System
{
    public static class ExtStruct
    {
        /// <summary>
        /// Serializes the struct to a byte array.
        /// </summary>
        /// <typeparam name="T">Struct type</typeparam>
        /// <param name="t">The struct to serialize.</param>
        /// <returns></returns>
        public static byte[] Serialize<T>(this T t) where T : struct
        {
            int size = Marshal.SizeOf(t);
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size); //分配结构体大小的内存空间
            Marshal.StructureToPtr(t, structPtr, false); //将结构体拷到分配好的内存空间
            Marshal.Copy(structPtr, bytes, 0, size);       //从内存空间拷到byte数组
            Marshal.FreeHGlobal(structPtr);                //释放内存空间
            return bytes;
        }
        /// <summary>
        /// Deserializes the byte array to a struct.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes">The byte array to deserialize.</param>
        /// <returns></returns>
        public static T Deserialize<T>(this byte[] bytes) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            if (size > bytes.Length)
                return default(T);
            IntPtr structPtr = Marshal.AllocHGlobal(size); //分配结构大小的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);       //将byte数组拷到分配好的内存空间
            var t = (T)Marshal.PtrToStructure(structPtr, typeof(T));
            Marshal.FreeHGlobal(structPtr);
            return t;
        }



    }
}
