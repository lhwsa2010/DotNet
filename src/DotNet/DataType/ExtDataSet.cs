namespace System.Data
{
    /// <summary>
    /// DataSet Extends
    /// </summary>
    public static class ExtDataSet
    {
        /// <summary>
        /// replace dbnull
        /// </summary>
        /// <param name="ds">dataset</param>
        /// <returns></returns>
        public static DataSet ReplaceDbNull(this DataSet ds)
        {
            foreach (DataTable t in ds.Tables)
            {
                foreach (DataRow row in t.Rows)
                {
                    for (int i = 0; i < t.Columns.Count; i++)
                    {
                        if (row.IsNull(i))
                        {
                            if (t.Columns[i].DataType == typeof(string))
                                row[i] = "";
                            else if (t.Columns[i].DataType == typeof(int))
                                row[i] = 0;
                            else if (t.Columns[i].DataType == typeof(float))
                                row[i] = 0;
                            else if (t.Columns[i].DataType == typeof(decimal))
                                row[i] = 0;
                            else if (t.Columns[i].DataType == typeof(double))
                                row[i] = 0;
                        }
                    }
                }
            }
            return ds;
        }
    }
}