namespace DataArtATM.Implementation.Repositories
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Transactions;

    using DataArtATM.Abstract.Repositories;
    using DataArtATM.Core.Models;
    using DataArtATM.DataContext;

    /// <summary>
    /// The card repository.
    /// </summary>
    public class CardRepository : BaseRepository, ICardRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public CardRepository(DataArtATMDataContext context)
            : base(context)
        {
        }

        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Card> GetAsync(long number)
        {
            return await this.Context.Cards.FirstOrDefaultAsync(x => x.Number == number && !x.IsBlocked);
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task UpdateAsync(Card item)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                this.Context.Entry(item).State = EntityState.Modified;
                await this.Context.SaveChangesAsync();

                scope.Complete();
            }
        }
    }
}
