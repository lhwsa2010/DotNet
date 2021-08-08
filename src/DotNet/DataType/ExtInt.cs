namespace System
{
    /// <summary>
    /// Int Extends
    /// </summary>
    public static class ExtInt
    {
        /// <summary>
        /// 0 convert to false ，others convert to true
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool GetBool(this int i)
        {
            if (i == 0)
                return false;
            return true;
        }


        /// <summary>
        /// 0 or null convert to false,others convert to true
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool GetBool(this int? i)
        {
            i = i ?? 0;
            if (i == 0)
                return false;
            return true;
        }

        /// <summary>
        /// convert nullable int to int
        /// </summary>
        /// <param name="i">nullable</param>
        /// <param name="defaultvalue">defaultvalue</param>
        /// <returns></returns>
        public static int GetInt(this int? i, int defaultvalue=default)
        {
            return i ?? defaultvalue;
        }
    }
}
