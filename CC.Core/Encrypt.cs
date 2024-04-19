namespace CC.Core
{
    using System.Security.Cryptography;
    using System.Text;

    public static class Encrypt
    {
        public static string EncryptText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return Encoding.Default.GetString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(text)));
        }
    }
}
