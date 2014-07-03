namespace DataArtATM.Abstract.Repositories
{
    using System.Threading.Tasks;

    using DataArtATM.Core.Models;

    /// <summary>
    /// The TransactionRepository interface.
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<Transaction> GetAsync(int id);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task AddAsync(Transaction item);
    }
}
