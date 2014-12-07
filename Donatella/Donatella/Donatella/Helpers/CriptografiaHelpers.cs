using System;
using System.Security.Cryptography;
using System.Text;

namespace Donatella.Helpers
{
    public class CriptografiaHelpers
    {
        public static byte[] Criptografar(string texto, string salt)
        {
            salt = ConversaoHelper.ToInt64(salt).ToString();
            return CriptografarSHA512(texto, salt);
        }

        private static byte[] CriptografarSHA512(string texto, string salt)
        {
            while (salt.Length < 6)
            {
                salt += salt + "Z";
            }
            using (var sha = SHA512.Create())
            {
                salt = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(salt.Substring(salt.Length - 4))));
                return sha.ComputeHash(Encoding.UTF8.GetBytes(texto + salt));
            }
        }

        public static string ValidarChaveDeAcesso(string chave)
        {
            try
            {
                chave = new CryptHelpers(CryptProvider.Rijndael).Decrypt(chave.Replace(" ", "+"));

                if (!chave.StartsWith("120FEF0E-98A5-") || !chave.Contains("-44AF-8B43-") || !chave.EndsWith("-BB7166A7BA89"))
                    return "";

                var sChave = chave.Split('-');
                var dado = sChave[2];
                var data = new DateTime(Convert.ToInt64(sChave[5]));

                if (data < DateTime.Now && data > DateTime.Now.AddMinutes(-30))
                    return dado;

                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
