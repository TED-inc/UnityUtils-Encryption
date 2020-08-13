using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using TEDinc.Utils.MathExt.Rand;

namespace TEDinc.Utils.Encrition
{
    public static class EncryptUtils
    {
        public const int keySize = 16;

        public static string EncryptString(string value, out string key)
        {
            key = RandomExt.NextString(keySize);
            return EncryptString(value, key);
        }

        public static string EncryptString(string value, string key)
        {
            byte[] iv = new byte[keySize];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        streamWriter.Write(value);

                    array = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string valueEncrypted, string key)
        {
            byte[] iv = new byte[keySize];
            byte[] buffer = Convert.FromBase64String(valueEncrypted);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (StreamReader streamReader = new StreamReader(cryptoStream))
                    return streamReader.ReadToEnd();
            }
        }
    }
}