namespace DataArtATM.SetUp
{
    using DataArtATM.Abstract.Repositories;
    using DataArtATM.DataContext;
    using DataArtATM.Implementation.Repositories;

    using Ninject;

    /// <summary>
    /// The dependency injection manager.
    /// </summary>
    public class DependencyInjectionManager
    {
        /// <summary>
        /// The set up.
        /// </summary>
        /// <param name="kernel">
        /// The kernel.
        /// </param>
        public void SetUp(IKernel kernel)
        {
            kernel.Bind<DataArtATMDataContext>().ToSelf();
            kernel.Bind<ITransactionRepository>().To<TransactionRepository>();
            kernel.Bind<ICardRepository>().To<CardRepository>();
        }
    }
}
