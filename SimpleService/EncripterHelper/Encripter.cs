using System;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using SimpleService.Models;

namespace SimpleService.EncripterHelper
{
    public class Encripter : IEncripter
    {

        public void EncryptEmailAllUsers(ICollection<User> users)
        {
            foreach(var user in users)
            {
                user.Email = EncryptUserEmail(user.Email);
            }
        }

        public void EncryptEmailUser(User user)
        {
            user.Email = EncryptUserEmail(user.Email);

        }

        public string EncryptUserEmail(string email)
        {
            byte[] encrypted;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(email);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted);
        }
    }
}