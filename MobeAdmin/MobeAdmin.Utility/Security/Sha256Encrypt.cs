using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Utility.Security
{
    public static class Sha256Encrypt
    {
        private static string HMACSHA256_WORD = "Hello World!!";
        public static string HMACSHA256(this string message)
        {
            return GenerateHmacSha256(message, HMACSHA256_WORD);
        }

        /// <summary>
        /// 字串加密(Sha256)
        /// </summary>
        /// <param name="Source">加密前字串</param>
        /// <param name="CryptoKey">加密金鑰</param>
        /// <returns></returns>
        private static string GenerateHmacSha256(string SourceStr, string CryptoKey)
        {
            string result = "Error";
            try
            {
                //用微軟的System.Security.Cryptography，不相信微軟可以不要用!?;
                var encoding = new System.Text.UTF8Encoding();
                byte[] keyByte = encoding.GetBytes(CryptoKey);
                byte[] messageBytes = encoding.GetBytes(SourceStr);
                using (var hmacSHA256 = new HMACSHA256(keyByte))
                {
                    byte[] hashMessage = hmacSHA256.ComputeHash(messageBytes);
                    result = BitConverter.ToString(hashMessage).Replace("-", "").ToLower();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return result;
        }
    }
}
