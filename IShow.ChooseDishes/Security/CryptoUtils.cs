using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Security
{
    public class CryptoUtils
    {

        public static string GetSalt() {
            Guid _Guid = Guid.NewGuid();
            string str = _Guid.ToString();
            return str.Substring(str.Length - 7);

        }
        public static string Hash(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return string.Empty;
            }
            else
            {
                MD5 md5 = MD5.Create();
                byte[] source = Encoding.UTF8.GetBytes(message);
                byte[] result = md5.ComputeHash(source);
                StringBuilder buffer = new StringBuilder(result.Length);

                for (int i = 0; i < result.Length; i++)
                {
                    buffer.Append(result[i].ToString("x"));//将byte值转换成十六进制字符串
                }
                return buffer.ToString();
            }

        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="encryptString"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string encryptString)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] encryptedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(encryptString));
                StringBuilder md5Builder = new StringBuilder();
                for (int i = 0; i < encryptedBytes.Length; i++)
                {
                    md5Builder.AppendFormat("{0:x2}", encryptedBytes[i]);
                }
                return md5Builder.ToString();
            }
        }

        public static string SHA256Encrypt(string input, string salt) { 
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256 
            byte[] source = Encoding.Default.GetBytes(input);//將字串轉為Byte[] 
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密 
            return Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串 
        }

        public static byte[] AESEncrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }

        public byte[] AESDecrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }
    }
}
