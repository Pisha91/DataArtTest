namespace DataArtATM.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The withdraw money view model.
    /// </summary>
    public class WithdrawMoneyViewModel
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}