﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace System
{
    public static class ExtEnum
    {

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse<T>(this Enum e,string value,bool ignoreCase=true)
        {
            if (Enum.TryParse(typeof(T), value,ignoreCase,out object result))
                return (T)result;
            return default(T);
        }

        /// <summary>
        /// Get enum description. i.e:[Description("xx")]
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum e)
        {
            string enumName = e.ToString();
            Type t = e.GetType();
            System.Reflection.FieldInfo fi = t.GetField(enumName);
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return arrDesc[0].Description;
        }


    }
}
