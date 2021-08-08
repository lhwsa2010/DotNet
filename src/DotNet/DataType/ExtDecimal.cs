namespace System
{
    /// <summary>
    /// Decimal Extends
    /// </summary>
    public static class ExtDecimal
    {
        /// <summary>
        /// convert nullable decimal to decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal GetDecimal(this decimal? d)
        {
            return d ?? default;
        }

    }
}
