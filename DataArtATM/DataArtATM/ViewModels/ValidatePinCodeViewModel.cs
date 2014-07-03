namespace DataArtATM.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The validate pin code view model.
    /// </summary>
    public class ValidatePinCodeViewModel
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        public long CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the pin code.
        /// </summary>
        [MinLength(4, ErrorMessage = "Pin code must consist 4 symbols")]
        [MaxLength(4, ErrorMessage = "Pin code must consist 4 symbols")]
        [Required]
        [Display(Name = "PIN code")]
        public string PinCode { get; set; }
    }
}