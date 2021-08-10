using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Tool
{
    /// <summary>
    /// undone
    /// </summary>
    public class WebUtil
    {
        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters, bool encode=true, string charset = "UTF-8")
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");

                    if (encode)
                    {
                        value = UrlEncoder.Encode(value, charset);
                    }

                    postData.Append(value);
                    hasParam = true;
                }
            }

            return postData.ToString();

        }

        public static string BuildQueryWithoutEncode(IDictionary<string, string> parameters, string charset = "UTF-8")
        {
            return BuildQuery(parameters, false, charset);
        }
    }
}
