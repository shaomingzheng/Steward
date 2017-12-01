using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ICH.Core.Security
{
    /// <summary>
    /// 加密解密实用类。
    /// </summary>
    public class Encrypt
    {
        //密钥
        private static byte[] arrDESKey = { 42, 16, 93, 156, 78, 4, 218, 32 };
        private static byte[] arrDESIV = { 55, 103, 246, 79, 36, 99, 167, 3 };

        /// <summary>
        /// 加密。
        /// </summary>
        /// <param name="m_Need_Encode_String"></param>
        /// <returns></returns>
        public static string Encode(string m_Need_Encode_String)
        {
            if (string.IsNullOrEmpty(m_Need_Encode_String))
            {
                throw new Exception("Error: \n源字符串为空！！！");
            }
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            MemoryStream objMemoryStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(arrDESKey, arrDESIV), CryptoStreamMode.Write);
            StreamWriter objStreamWriter = new StreamWriter(objCryptoStream);
            objStreamWriter.Write(m_Need_Encode_String);
            objStreamWriter.Flush();
            objCryptoStream.FlushFinalBlock();
            objMemoryStream.Flush();
            return Convert.ToBase64String(objMemoryStream.GetBuffer(), 0, (int)objMemoryStream.Length);
        }

        /// <summary>
        /// 解密。
        /// </summary>
        /// <param name="m_Need_Encode_String"></param>
        /// <returns></returns>
        public static string Decode(string m_Need_Encode_String)
        {
            if (string.IsNullOrEmpty(m_Need_Encode_String))
            {
                throw new Exception("Error: \n源字符串为空！！");
            }
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            byte[] arrInput = Convert.FromBase64String(m_Need_Encode_String);
            MemoryStream objMemoryStream = new MemoryStream(arrInput);
            CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateDecryptor(arrDESKey, arrDESIV), CryptoStreamMode.Read);
            StreamReader objStreamReader = new StreamReader(objCryptoStream);
            return objStreamReader.ReadToEnd();
        }

        /// <summary>
        /// md5
        /// </summary>
        /// <param name="encypStr"></param>
        /// <returns></returns>
        public static string Md5(string str)
        {
            System.Security.Cryptography.MD5 md = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(str);//将字符串编码为一个字符序列
            byte[] md5Data = md.ComputeHash(data);//计算data的字节数组的hash值
            md.Clear();
            string s = string.Empty;
            for (int i = 0; i < md5Data.Length; i++)
            {
                s += md5Data[i].ToString("X").PadLeft(2, '0');
            }
            return s;
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Base64Code(string Message)
        {
            byte[] bytes = Encoding.Default.GetBytes(Message);
            return Convert.ToBase64String(bytes);
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Base64Decode(string Message)
        {
            byte[] bytes = Convert.FromBase64String(Message);
            return Encoding.Default.GetString(bytes);
        }
    }
}
