namespace DataArtATM.Implementation.Repositories
{
    using System.Threading.Tasks;
    using System.Transactions;

    using DataArtATM.DataContext;

    /// <summary>
    /// The base repository.
    /// </summary>
    public class BaseRepository 
    {
        /// <summary>
        /// The context.
        /// </summary>
        protected readonly DataArtATMDataContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public BaseRepository(DataArtATMDataContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="T">
        /// T type of entity for update.
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task AddAsync<T>(T item) where T : class
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                this.Context.Set<T>().Add(item);
                await this.Context.SaveChangesAsync();

                scope.Complete();
            }
        }
    }
}
