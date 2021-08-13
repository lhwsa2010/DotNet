using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DotNet.Hex;

namespace DotNet.Cryptography
{
    /// <summary>
    /// 3DES
    /// </summary>
    public class DESCrypt
    {
        /// <summary>
        /// Encrypt data with the key and iv.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string Encrypt(string data, string key, string iv, string charset = "UTF-8")
        {
            byte[] dataInBytes = Encoding.GetEncoding(charset).GetBytes(data);
            byte[] btKey = key.FromHex();
            byte[] btIv = iv.FromHex();
            byte[] btEncryptedSecret = Encrypt(dataInBytes, btKey, btIv);
            return Convert.ToBase64String(btEncryptedSecret);
        }

        /// <summary>
        /// Decrypt data with the key and iv.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string Decrypt(string data, string key, string iv, string charset = "UTF-8")
        {
            byte[] dataInBytes = Convert.FromBase64String(data);
            byte[] btKey = key.FromHex();
            byte[] btIv = iv.FromHex();
            byte[] btEncryptedSecret = Decrypt(dataInBytes, btKey, btIv);
            return Encoding.GetEncoding(charset).GetString(btEncryptedSecret);
        }
        /// <summary>
        /// Encrypt data with the key and iv.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = key;
            tripleDES.IV = iv;
            tripleDES.Padding = PaddingMode.PKCS7;
            tripleDES.Mode = CipherMode.CBC;
            ICryptoTransform encrypt = tripleDES.CreateEncryptor();
            byte[] dataOutBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                }
                dataOutBytes = ms.ToArray();
            }
            return dataOutBytes;
        }
        /// <summary>
        /// Decrypt data with the key and iv.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = key;
            tripleDES.IV = iv;
            tripleDES.Padding = PaddingMode.PKCS7;
            tripleDES.Mode = CipherMode.CBC;
            ICryptoTransform decrypt = tripleDES.CreateDecryptor();
            byte[] dataOutBytes = new byte[data.Length];
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (CryptoStream cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Read))
                {
                    cs.Read(dataOutBytes, 0, dataOutBytes.Length);
                }
            }
            return dataOutBytes;
        }
    }
}
