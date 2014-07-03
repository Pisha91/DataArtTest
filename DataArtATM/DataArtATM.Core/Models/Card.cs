namespace DataArtATM.Core.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The card.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public long Number { get; set; }

        /// <summary>
        /// Gets or sets the pin code.
        /// </summary>
        public string PinCode { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        public decimal Balance { get; set; } 

        /// <summary>
        /// Gets or sets a value indicating whether card is blocked.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; } 
    }
}
