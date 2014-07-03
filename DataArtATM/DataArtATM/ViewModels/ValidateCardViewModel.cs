namespace DataArtATM.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using DataArtATM.ViewModels.Attributes;

    /// <summary>
    /// The validate card view model.
    /// </summary>
    public class ValidateCardViewModel
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        [Required]
        [MaxLength(19, ErrorMessage = "Invalid card format")]
        [MinLength(19, ErrorMessage = "Invalid card format")]
        [CardFormat(ErrorMessage = "Invalid card format")]
        [Display(Name = "Card number")]
        public string Number { get; set; }
    }
}