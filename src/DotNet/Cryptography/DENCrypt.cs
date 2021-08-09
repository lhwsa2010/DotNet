using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DotNet.Cryptography
{
    /// <summary>
    /// Encrypt&Decrypt
    /// </summary>
    public class DENCrypt
    {
        /// <summary>
        /// sha1+md5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sha1Md5(string s)
        {
            return Md5(Sha1(s));
        }

        /// <summary>
        /// md5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Md5(string s, bool upperCase = default)
		{
            string result = default;
			using (var md5 = MD5.Create())
			{
				byte[] bytes= md5.ComputeHash(Encoding.ASCII.GetBytes(s));
				result = BitConverter.ToString(bytes);
                result=result.Replace("-", "");
            }
            if (upperCase)
                result = result.ToUpper();
            else
                result = result.ToLower();
            return result;
        }

        /// <summary>
        /// sha1
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Sha1(string s, bool upperCase = default)
        {
            string result=default;
            using (var sha1 = SHA1.Create())
            {
                byte[] bytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(s));
                result = BitConverter.ToString(bytes);
                result = result.Replace("-", "");
            }
            if (upperCase)
                result = result.ToUpper();
            else
                result = result.ToLower();
            return result;
        }

        /// <summary>
        /// Encrypt data.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Encrypt(string text, string sKey= "dotnet")
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(text);
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Md5(sKey).Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(Md5(sKey).Substring(0, 8));
            MemoryStream expr_5B = new MemoryStream();
            CryptoStream expr_68 = new CryptoStream(expr_5B, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            expr_68.Write(bytes, 0, bytes.Length);
            expr_68.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = expr_5B.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                byte b = array[i];
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Decrypt data.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string Decrypt(string text, string sKey="dotnet")
        {
            DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
            int num = text.Length / 2;
            byte[] array = new byte[num];
            for (int i = 0; i < num; i++)
            {
                int num2 = Convert.ToInt32(text.Substring(i * 2, 2), 16);
                array[i] = (byte)num2;
            }
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(Md5(sKey).Substring(0, 8));
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(Md5(sKey).Substring(0, 8));
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream expr_94 = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
            expr_94.Write(array, 0, array.Length);
            expr_94.FlushFinalBlock();
            return Encoding.Default.GetString(memoryStream.ToArray());
        }

    }
}
