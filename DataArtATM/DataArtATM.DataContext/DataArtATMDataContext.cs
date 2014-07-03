namespace DataArtATM.DataContext
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;

    using DataArtATM.Core.Models;

    /// <summary>
    /// The data context.
    /// </summary>
    public class DataArtATMDataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataArtATMDataContext"/> class.
        /// </summary>
        public DataArtATMDataContext()
            : base("DataArtATMDB")
        {
        }

        /// <summary>
        /// Gets or sets the cards.
        /// </summary>
        public IDbSet<Card> Cards { get; set; }

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        public IDbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                     .Entity<Card>()
                     .Property(t => t.Number)
                     .IsRequired()
                     .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Number") { IsUnique = true }));
        }
    }
}
