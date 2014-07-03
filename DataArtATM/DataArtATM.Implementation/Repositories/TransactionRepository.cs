namespace DataArtATM.Implementation.Repositories
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Transactions;

    using DataArtATM.Abstract.Repositories;
    using DataArtATM.DataContext;

    using Transaction = DataArtATM.Core.Models.Transaction;

    /// <summary>
    /// The transaction repository.
    /// </summary>
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public TransactionRepository(DataArtATMDataContext context)
            : base(context)
        {
        }

        /// <summary>
        /// The get async.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Transaction> GetAsync(int id)
        {
            return await this.Context.Transactions.Include(x => x.Card).FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task AddAsync(Transaction item)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                this.Context.Transactions.Add(item);
                await this.Context.SaveChangesAsync();

                scope.Complete();
            }
        }
    }
}
