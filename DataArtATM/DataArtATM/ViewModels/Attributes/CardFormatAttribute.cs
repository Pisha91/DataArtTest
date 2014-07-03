namespace DataArtATM.ViewModels.Attributes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The card format attribute.
    /// </summary>
    public class CardFormatAttribute : ValidationAttribute
    {
        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var numberString = value.ToString().Replace("-", string.Empty);
                long number;
                if (numberString.Length == 16 && long.TryParse(numberString, out number))
                {
                    return true;
                }
            }

            return false;
        }
    }
}