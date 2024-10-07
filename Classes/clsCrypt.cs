using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FamilyApp.Crypt
{

    public partial class clsCrypt
    {
        public static string Encrypt(string AEncryptString, string AHashCode)
        {
            var rd = new RijndaelManaged();

            var md5 = new MD5CryptoServiceProvider();
            byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(AHashCode));

            try
            {
                md5.Clear();
                rd.Key = key;
                rd.GenerateIV();

                byte[] iv = rd.IV;
                var ms = new MemoryStream();

                ms.Write(iv, 0, iv.Length);

                var cs = new CryptoStream(ms, rd.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] data = Encoding.UTF8.GetBytes(AEncryptString);

                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                byte[] encdata = ms.ToArray();
                cs.Close();
                rd.Clear();
                return Convert.ToBase64String(encdata);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string Decrypt(string ADecstring, string AHashCode)
        {

            var rd = new RijndaelManaged();
            int rijndaelIvLength = 16;
            var md5 = new MD5CryptoServiceProvider();
            byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(AHashCode));

            md5.Clear();

            byte[] encdata = Convert.FromBase64String(ADecstring);
            var ms = new MemoryStream(encdata);
            var iv = new byte[16];

            ms.Read(iv, 0, rijndaelIvLength);
            rd.IV = iv;
            rd.Key = key;

            var cs = new CryptoStream(ms, rd.CreateDecryptor(), CryptoStreamMode.Read);

            var data = new byte[(int)(ms.Length - rijndaelIvLength + 1)];
            int i = cs.Read(data, 0, data.Length);

            cs.Close();
            rd.Clear();
            return Encoding.UTF8.GetString(data, 0, i);

        }

    }
}