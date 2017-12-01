using System;
using System.Security.Cryptography;
using System.Text;

namespace ICH.Core.Security
{
    public class PasswordEncrypt
    {
        private static string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        private static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }

        public static RSAKey GetRsaKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            RSAParameters parameter = rsa.ExportParameters(true);
            var privateKey = rsa.ToXmlString(true);
            return new RSAKey { PublicKeyExponent = BytesToHexString(parameter.Exponent), PublicKeyModulus = BytesToHexString(parameter.Modulus), PrivateKey = privateKey };
        }

        public static string Decrypt(string privateKey, string encryptPassword)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);
            byte[] result = rsa.Decrypt(HexStringToBytes(encryptPassword), false);
            System.Text.ASCIIEncoding enc = new ASCIIEncoding();
            return enc.GetString(result);
        }

    }

    public class RSAKey
    {
        public string PublicKeyExponent { get; set; }

        public string PublicKeyModulus { get; set; }

        public string PrivateKey { get; set; }
    }
}
