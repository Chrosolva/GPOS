using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MilenialPark.Master
{
    public class ClsCrypthography
    {
        #region Private variables

        /// <summary>
        /// 16 karakter salt untuk enkripsi dan dekripsi
        /// </summary>
        private string Salt = "@1a2B3c4D5e6F7g8";

        /// <summary>
        /// Password rahasia untuk enkripsi dan dekripsi
        /// </summary>
        private string passPhrase = "P@d@s@6Ut@m@";

        /// <summary>
        /// Jumlah iterasi untuk memperoleh key untuk AES
        /// </summary>
        private int iteration = 1000;

        #endregion

        #region Constructors

        /// <summary>
        /// Inisialisasi ClsCryptography baru
        /// </summary>
        public ClsCrypthography()
        {

        }

        #endregion

        #region Fungsi - fungsi

        /// <summary>
        /// Mengambil salt dalam format array of byte
        /// </summary>
        /// <returns></returns>
        private byte[] GetSaltByteArray()
        {
            byte[] SaltByte = new byte[Salt.Length];
            for (int i = 0; i < Salt.Length; i++)
            {
                SaltByte[i] = Convert.ToByte(Salt[i]);
            }
            return SaltByte;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Convert array of byte menjadi hexa string
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public string ConvertByteArrayToHexaString(byte[] byteArray)
        {
            uint[] ConvertTable = new uint[256];
            string AsciiCharacter;
            for (int i = 0; i < 256; i++)
            {
                AsciiCharacter = i.ToString("X2");
                ConvertTable[i] = ((uint)AsciiCharacter[0]) + ((uint)AsciiCharacter[1] << 16);
            }

            char[] HexaArray = new char[byteArray.Length * 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                HexaArray[i * 2] = (char)ConvertTable[byteArray[i]];
                HexaArray[i * 2 + 1] = (char)(ConvertTable[byteArray[i]] >> 16);
            }
            return new string(HexaArray);
        }

        /// <summary>
        /// Hashing string dengan menggunakan teknik SHA512
        /// </summary>
        /// <param name="textToHash">Teks yang akan di hash</param>
        /// <returns>String yang sudah di hashing dengan format Hexa string</returns>
        public string HashString(string textToHash)
        {
            string HashedText = "";
            textToHash += Salt;
            using (SHA512Managed SHA = new SHA512Managed())
            {
                byte[] HashedByteArray = SHA.ComputeHash(Encoding.Unicode.GetBytes(textToHash));
                HashedText = ConvertByteArrayToHexaString(HashedByteArray);
            }
            return HashedText;
        }

        /// <summary>
        /// Enkripsi string dengan menggunakan teknik Advanced Encryption Standart (AES)
        /// </summary>
        /// <param name="textToEncrypt">Teks yang akan di enkripsi</param>
        /// <returns>String yang sudah di enkripsi dengan format Base64String</returns>
        public string EncryptString(string textToEncrypt)
        {
            return EncryptString(textToEncrypt, passPhrase);
        }

        /// <summary>
        /// Enkripsi string dengan menggunakan teknik Advanced Encryption Standart (AES)
        /// </summary>
        /// <param name="textToEncrypt">Teks yang akan di enkripsi</param>
        /// <param name="secretPhrase">Kata rahasia untuk proses enkripsi dan dekripsi</param>
        /// <returns>String yang sudah di enkripsi dengan format Base64String</returns>
        public string EncryptString(string textToEncrypt, string secretPhrase)
        {
            string EncryptedText = "";
            byte[] TextBytes = Encoding.Unicode.GetBytes(textToEncrypt);
            byte[] SaltByte = GetSaltByteArray();
            using (Aes Encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes DeriveBytes = new Rfc2898DeriveBytes(secretPhrase, SaltByte, iteration);
                Encryptor.Key = DeriveBytes.GetBytes(32);
                Encryptor.IV = DeriveBytes.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, Encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(TextBytes, 0, TextBytes.Length);
                        cs.Close();
                    }
                    EncryptedText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return EncryptedText;
        }

        /// <summary>
        /// Dekripsi string dengan menggunakan teknik Advanced Encryption Standart (AES)
        /// </summary>
        /// <param name="textToEncrypt">Teks yang akan di dekripsi</param>
        /// <returns>String yang sudah di dekripsi dengan format unicode</returns>
        public string DecryptString(string textToDecrypt)
        {
            return DecryptString(textToDecrypt, passPhrase);
        }

        /// <summary>
        /// Dekripsi string dengan menggunakan teknik Advanced Encryption Standart (AES)
        /// </summary>
        /// <param name="textToEncrypt">Teks yang akan di dekripsi</param>
        /// <param name="secretPhrase">Kata rahasia untuk proses enkripsi dan dekripsi</param>
        /// <returns>String yang sudah di dekripsi dengan format unicode</returns>
        public string DecryptString(string textToDecrypt, string secretPhrase)
        {
            string DecryptedText = "";
            byte[] CipherBytes = Convert.FromBase64String(textToDecrypt);
            byte[] SaltByte = GetSaltByteArray();
            using (Aes Encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes DeriveBytes = new Rfc2898DeriveBytes(secretPhrase, SaltByte, iteration);
                Encryptor.Key = DeriveBytes.GetBytes(32);
                Encryptor.IV = DeriveBytes.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, Encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(CipherBytes, 0, CipherBytes.Length);
                        cs.Close();
                    }
                    DecryptedText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return DecryptedText;
        }

        #endregion
    }
}
