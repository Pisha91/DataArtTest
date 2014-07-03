namespace DataArtATM.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The show balance view model.
    /// </summary>
    public class ShowBalanceViewModel
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [Display(Name = "Card number")]
        public long CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [Display(Name = "Balance")]
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}