using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StreetWatch.Authentication
{
    public class Enc
    {


            public string Encrypt(string data, string pw_mod, string salt)
            {
                byte[] utfdata = UTF8Encoding.UTF8.GetBytes(data);
                byte[] saltBytes =
                    UTF8Encoding.UTF8.GetBytes(salt);

                // Our symmetric encryption algorithm
                AesManaged aes = new AesManaged();

                // We're using the PBKDF2 standard for password-based key generation
                Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(pw_mod, saltBytes);

                // Setting our parameters
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                // Encryption
                ICryptoTransform encryptTransf = aes.CreateEncryptor();

                // Output stream, can be also a FileStream
                MemoryStream encryptStream = new MemoryStream();
                CryptoStream encryptor = new CryptoStream(encryptStream, encryptTransf, CryptoStreamMode.Write);

                encryptor.Write(utfdata, 0, utfdata.Length);
                encryptor.Flush();
                encryptor.Close();

                // Showing our encrypted content
                byte[] encryptBytes = encryptStream.ToArray();
                string encryptedString = Convert.ToBase64String(encryptBytes);
                return encryptedString;
            }

            public string Decrypt(string base64Input, string pw, string salt)
            {
                byte[] encryptBytes = Convert.FromBase64String(base64Input);
                byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

                // Our symmetric encryption algorithm
                AesManaged aes = new AesManaged();

                // We're using the PBKDF2 standard for password-based key generation
                Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(pw, saltBytes);

                // Setting our parameters
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                // Now, decryption
                ICryptoTransform decryptTrans = aes.CreateDecryptor();

                // Output stream, can be also a FileStream
                MemoryStream decryptStream = new MemoryStream();
                CryptoStream decryptor = new CryptoStream(decryptStream, decryptTrans, CryptoStreamMode.Write);

                decryptor.Write(encryptBytes, 0, encryptBytes.Length);
                decryptor.Flush();
                decryptor.Close();

                // Showing our decrypted content
                byte[] decryptBytes = decryptStream.ToArray();
                string decryptedString = UTF8Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
                return decryptedString;
            }

            public virtual string Decode(string data, string p)
            {
                return Decrypt(data, p, "abaawaaba");
            }

            public virtual string Encode(string data, string p)
            {
                return Encrypt(data, p, "abaawaaba");
            }

        
    }
}