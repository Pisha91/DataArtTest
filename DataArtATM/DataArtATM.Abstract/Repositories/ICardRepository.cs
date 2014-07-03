namespace DataArtATM.Abstract.Repositories
{
    using System.Threading.Tasks;

    using DataArtATM.Core.Models;

    /// <summary>
    /// The CardRepository interface.
    /// </summary>
    public interface ICardRepository
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="Card"/>.
        /// </returns>
        Task<Card> GetAsync(long number);

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task UpdateAsync(Card item);
    }
}
