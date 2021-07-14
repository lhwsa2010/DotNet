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
        /// 替换dbnull
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
        /// 根据传入的排序条件讲datatable排序
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sort">id desc或者 id 等</param>
        /// <returns></returns>
        public static DataTable OrderBy(this DataTable dt, string sort)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = sort;
            return dv.ToTable();
        }

        /// <summary>
        /// 返回符合条件的数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static DataTable Where(this DataTable dt, string filter)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = filter;
            return dv.ToTable();
        }


        //----------------------2012-11-21 XYC添加------------------------------------------

        /// <summary>
        /// 返回表第一行第一列的值
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
        /// 返回表第一行第一列的值 int型 用于获取分页时的recordcount
        /// </summary>
        /// <param name="dt"></param>
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
        /// 返回datatable的第M行第N列
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="M">第M行</param>
        /// <param name="N">N为列数</param>
        /// <returns></returns>
        public static object RowsMN(this  DataTable dt, int M, int N)
        {
            if (dt.Rows.Count > M && dt.Columns.Count > N)
            {
                return dt.Rows[M][N];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回datatable的第M行第N列
        /// </summary>
        /// <param name="dt">datatable</param>
        /// <param name="M">第M行</param>
        /// <param name="N">N为列名</param>
        /// <returns></returns>
        public static object RowsMN(this DataTable dt, int M, string N)
        {
            if (dt.Rows.Count > M && dt.Columns.Contains(N))
            {
                return dt.Rows[M][N];
            }
            else
            {
                return null;
            }
        }



        public static DataTable Skip(this DataTable dt, int count)
        {
            DataTable table = dt.Copy();
            if (table.Rows.Count <= count)
            {
                table.Clear();
                return table;
            }
            for (int i = 0; i < count; i++)
            {
                table.Rows.RemoveAt(0);
            }
            return table;
        }

        public static DataTable Take(this DataTable dt, int count)
        {
            DataTable table = dt.Copy();
            int num = table.Rows.Count;
            for (int i = count; i < num; i++)
            {
                table.Rows.RemoveAt(count);
            }
            return table;
        }




    }
}