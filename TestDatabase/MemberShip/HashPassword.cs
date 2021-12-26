using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase.MemberShip
{
    class HashPassword
    {
        /*public static string Encrypt(string password)
        {
            if (password == null) throw new ArgumentNullException("password");
            //encrypt data
            var data = Encoding.Unicode.GetBytes(password);
            byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
            //return as base64 string
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string passwordHash)
        {
            if (passwordHash == null) throw new ArgumentNullException("passwordHash");
            //parse base64 string
            byte[] data = Convert.FromBase64String(passwordHash);
            //decrypt data
            byte[] decrypted = ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(decrypted);
        }*/

        private static string hash = "nhat-long";

        public static string Encrypt(string value)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = triple.CreateEncryptor();
                    byte[] res = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(res, 0, res.Length);
                }
            }
        }
        public static string Decrypt(string value)
        {
            //Console.WriteLine(value);
            byte[] data = Convert.FromBase64String(value);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider triple = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = triple.CreateDecryptor();
                    byte[] res = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(res);
                }
            }
        }
    }
}
