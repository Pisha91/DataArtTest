namespace DataArtATM.Helpers
{
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// The card validation helper.
    /// </summary>
    public class CardValidationHelper
    {
        /// <summary>
        /// The is valid pin code.
        /// </summary>
        /// <param name="hash">
        /// The hash.
        /// </param>
        /// <param name="pinCode">
        /// The pin code.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsValidPinCode(string hash, string pinCode)
        {
            string pinCodeHash = GetHash(pinCode);

            return hash == pinCodeHash;
        }

        /// <summary>
        /// The get hash.
        /// </summary>
        /// <param name="pinCode">
        /// The pin code.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetHash(string pinCode)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pinCode));

                var stringBuilder = new StringBuilder();

                foreach (byte byteData in data)
                {
                    stringBuilder.Append(byteData.ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}