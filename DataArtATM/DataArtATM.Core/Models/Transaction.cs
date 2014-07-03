namespace DataArtATM.Core.Models
{
    using System;

    using DataArtATM.Core.Enums;

    /// <summary>
    /// The transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the card id.
        /// </summary>
        public long CardId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public TransactionCode Code { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the card.
        /// </summary>
        public virtual Card Card { get; set; } 
    }
}
