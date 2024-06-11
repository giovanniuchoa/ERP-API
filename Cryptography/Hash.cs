using System.Security.Cryptography;
using System.Text;

namespace CarQuery__Test.Cryptography
{
    public static class Hash
    {

        public static string GenerateHash(this string pass)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(pass);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();

        }

    }
}
