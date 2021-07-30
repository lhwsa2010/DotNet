using System;
using System.Data;
using System.IO;

namespace System
{
    /// <summary>
    /// DataTable
    /// </summary>
    public static class ExtDataTable
    {
        /// <summary>
        /// replace dbnull
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataTable ReplaceDbNull(this DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (row.IsNull(i))
                    {
                        if (dt.Columns[i].DataType == typeof(string))
                            row[i] = "";
                        else if (dt.Columns[i].DataType == typeof(int))
                            row[i] = 0;
                        else if (dt.Columns[i].DataType == typeof(float))
                            row[i] = 0;
                        else if (dt.Columns[i].DataType == typeof(decimal))
                            row[i] = 0;
                        else if (dt.Columns[i].DataType == typeof(double))
                            row[i] = 0;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// sort the datatable order by param sort
        /// </summary>
        /// <param name="sort">i.e:id desc</param>
        /// <returns></returns>
        public static DataTable OrderBy(this DataTable dt, string sort)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = sort;
            return dv.ToTable();
        }

        /// <summary>
        /// filter the data
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static DataTable Where(this DataTable dt, string filter)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = filter;
            return dv.ToTable();
        }

        /// <summary>
        /// return the first column of first row data.If has not data,return null.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static object Rows00(this DataTable dt)
        {
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                return dt.Rows[0][0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// return the first column of first row data,and convert to int.If has not data,return 0.
        /// </summary>
        /// <returns></returns>
        public static int Rows00Int(this DataTable dt)
        {
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                return dt.Rows[0][0].GetString().GetInt();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// return the N'th column of M'th row data.If has not data,return null.
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="M">index of row</param>
        /// <param name="N">index of column</param>
        /// <returns></returns>
        public static object RowsMN(this  DataTable dt, int indexOfRow, int indexOfColumn)
        {
            if (dt.Rows.Count > indexOfRow && dt.Columns.Count > indexOfColumn)
            {
                return dt.Rows[indexOfRow][indexOfColumn];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// return the speical name of column of M'th row data.If has not data,return null. 
        /// </summary>
        /// <param name="M">index of row</param>
        /// <param name="N">column name</param>
        /// <returns></returns>
        public static object RowsMN(this DataTable dt, int indexOfRow, string columnName)
        {
            if (dt.Rows.Count > indexOfRow && dt.Columns.Contains(columnName))
            {
                return dt.Rows[indexOfRow][columnName];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// return the data,skip the num rows.If row count is less than num,return empty table.
        /// </summary>
        /// <param name="num">num rows</param>
        /// <returns></returns>
        public static DataTable Skip(this DataTable dt, int num)
        {
            DataTable table = dt.Copy();
            if (table.Rows.Count <= num)
            {
                table.Clear();
                return table;
            }
            for (int i = 0; i < num; i++)
            {
                table.Rows.RemoveAt(0);
            }
            return table;
        }

        /// <summary>
        /// Take the num rows of datatable.
        /// </summary>
        /// <param name="num">num rows</param>
        /// <returns></returns>
        public static DataTable Take(this DataTable dt, int num)
        {
            DataTable table = dt.Copy();
            int count = table.Rows.Count;
            for (int i = num; i < count; i++)
            {
                table.Rows.RemoveAt(count);
            }
            return table;
        }




    }
}