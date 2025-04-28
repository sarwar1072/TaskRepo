using System.Security.Cryptography;
using System.Text;
namespace TestProjectAuthoAPI.Helper
{
    public static class EncryptionHelper
    {
        private static readonly string _secretKey = "this-ismyet-Key-Here123!"; // should be at least 16 characters

        public static string Encrypt(string plainText)
        {
            byte[] key = Encoding.UTF8.GetBytes(_secretKey.Substring(0, 16));
            using var aes = Aes.Create();
            aes.Key = key;
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            // Combine IV and cipher text
            byte[] combinedBytes = new byte[aes.IV.Length + cipherBytes.Length];
            Array.Copy(aes.IV, 0, combinedBytes, 0, aes.IV.Length);
            Array.Copy(cipherBytes, 0, combinedBytes, aes.IV.Length, cipherBytes.Length);

            return Convert.ToBase64String(combinedBytes);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] combinedBytes = Convert.FromBase64String(cipherText);
            byte[] key = Encoding.UTF8.GetBytes(_secretKey.Substring(0, 16));

            using var aes = Aes.Create();
            aes.Key = key;

            // Extract IV
            byte[] iv = new byte[16];
            Array.Copy(combinedBytes, 0, iv, 0, iv.Length);
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            byte[] cipherBytes = new byte[combinedBytes.Length - iv.Length];
            Array.Copy(combinedBytes, iv.Length, cipherBytes, 0, cipherBytes.Length);

            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}
