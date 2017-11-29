using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ICH.Steward.Domain.DEncrypt
{
    /// <summary>
    ///DES 的摘要说明
    /// </summary>
    public class DES
    {

        private static readonly string DEFAULT_SECRET = "#fulu.sup.inventory.secretcard#@";

        public DES()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private static byte[] GetKey()
        {
            return GetKey(null);
        }

        private static byte[] GetKey(string sKey)
        {
            if (!string.IsNullOrEmpty(sKey))
                sKey = DEFAULT_SECRET;

            byte[] DESKey = new byte[sKey.Length];
            char[] cKey = sKey.ToCharArray();
            for (int i = 0; i < sKey.Length; i++)
                DESKey[i] = (byte)cKey[i];

            return DESKey;
        }


        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource">待加密的字串</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string strSource)
        {
            return DESEncrypt(strSource, DEFAULT_SECRET);
        }


        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource">待加密字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string strSource, string sKey)
        {
            if (string.IsNullOrEmpty(strSource))
                return null;

            SymmetricAlgorithm sa = Rijndael.Create();
            sa.Key = GetKey(sKey);
            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.Zeros;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] byt = Encoding.Unicode.GetBytes(strSource);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }


        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strSource">待解密的字串</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string strSource)
        {
            return DESDecrypt(strSource, DEFAULT_SECRET);
        }


        ///<summary>
        /// DES解密
        /// </summary>
        /// <param name="strSource">待解密的字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string strSource, string sKey)
        {
            if (string.IsNullOrEmpty(strSource))
                return null;

            SymmetricAlgorithm sa = Rijndael.Create();
            sa.Key = GetKey(sKey);
            sa.Mode = CipherMode.ECB;
            sa.Padding = PaddingMode.Zeros;
            ICryptoTransform ct = sa.CreateDecryptor();
            byte[] byt = Convert.FromBase64String(strSource);
            MemoryStream ms = new MemoryStream(byt);
            CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs, Encoding.Unicode);
            return sr.ReadToEnd().Replace("\0", string.Empty);
        }
    }
}
