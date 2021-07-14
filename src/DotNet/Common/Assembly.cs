using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace System
{
    public static class ExtAssembly
    {
        public static T GetAssemblyAttribute<T>(this Assembly assembly) where T : Attribute
        {
            // Get attributes of this type.
            object[] attributes =
                assembly.GetCustomAttributes(typeof(T), true);

            // If we didn't get anything, return null.
            if ((attributes == null) || (attributes.Length == 0))
                return null;

            // Convert the first attribute value into
            // the desired type and return it.
            return (T)attributes[0];
        }
        

    }


}
