namespace System
{
    /// <summary>
    /// Bool Extends
    /// </summary>
    public static class ExtBool
    {
        /// <summary>
        /// true convert to 1,false convert to 0
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetInt(this bool b)
        {
            if (b)
                return 1;
            return 0;
        }
    }
}
