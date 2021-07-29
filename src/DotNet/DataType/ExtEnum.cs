using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotNet.DataType
{
    public static class ExtEnum
    {
        /// <summary>
        /// 用于字符串和枚举类型的转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T EnumParse<T>(string value)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 读取枚举类型Description信息 枚举需申明[Description("xx")]
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum e)
        {
            string enumName = e.ToString();
            Type t = e.GetType();
            System.Reflection.FieldInfo fi = t.GetField(enumName);
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return arrDesc[0].Description;
        }
    }
}
