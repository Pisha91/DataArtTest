namespace DataArtATM.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The report view model.
    /// </summary>
    public class ReportViewModel
    {
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [Display(Name = "Card number")]
        public long CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}