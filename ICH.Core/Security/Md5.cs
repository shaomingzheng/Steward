using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ICH.Core.Security
{
    /// <summary>
    /// MD5加密帮助类
    /// 版本：2.0
    /// </summary>
    public class MD5
    {
        #region "MD5加密"

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="encryptStr"></param>
        /// <returns></returns>
        public static string EncryptMd5(string encryptStr)
        {
            var result = Encoding.Default.GetBytes(encryptStr.Trim());
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            var output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "").ToLower();
        }

        #endregion

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="fileName">文件名（带完整路径）</param>
        /// <returns></returns>
        public static string FileMD5(string fileName)
        {
            StringBuilder sb = new StringBuilder();
            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] retVal = md5.ComputeHash(file);
                foreach (byte t in retVal)
                {
                    sb.Append(t.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取流数据的MD5值
        /// </summary>
        /// <param name="stream">流数据对象</param>
        /// <returns></returns>
        public static string StreamMD5(Stream stream)
        {
            StringBuilder sb = new StringBuilder();
            using (System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] retVal = md5.ComputeHash(stream);
                foreach (byte t in retVal)
                {
                    sb.Append(t.ToString("x2"));
                }
            }
            return sb.ToString();
        }

    }
}
