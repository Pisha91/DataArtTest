namespace DataArtATM.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using DataArtATM.Abstract.Repositories;
    using DataArtATM.Core.Enums;
    using DataArtATM.Core.Models;
    using DataArtATM.ViewModels;

    /// <summary>
    /// The transactions controller.
    /// </summary>
    [Authorize]
    public class TransactionsController : BaseAuthenticateController
    {
        /// <summary>
        /// The card repository.
        /// </summary>
        private readonly ICardRepository cardRepository;

        /// <summary>
        /// The base repository.
        /// </summary>
        private readonly ITransactionRepository transactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsController"/> class.
        /// </summary>
        /// <param name="cardRepository">
        /// The card repository.
        /// </param>
        /// <param name="transactionRepository">
        /// The base Repository.
        /// </param>
        public TransactionsController(ICardRepository cardRepository, ITransactionRepository transactionRepository)
        {
            this.cardRepository = cardRepository;
            this.transactionRepository = transactionRepository;
        }

        /// <summary>
        /// The operations.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Operations()
        {
            return this.View();
        }

        /// <summary>
        /// The check balance.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckBalance()
        {
            Card card = await this.cardRepository.GetAsync(this.CardNumber);
            var transaction = new Transaction
                                  {
                                      CardId = card.Id,
                                      Code = TransactionCode.CheckBalance,
                                      Date = DateTime.Now
                                  };
            await this.transactionRepository.AddAsync(transaction);

            return this.RedirectToAction("ShowBalance");
        }

        /// <summary>
        /// The show balance.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public async Task<ActionResult> ShowBalance()
        {
            Card card = await this.cardRepository.GetAsync(this.CardNumber);
            var viewModel = new ShowBalanceViewModel
                                {
                                    CardNumber = this.CardNumber,
                                    Balance = card.Balance,
                                    Date = DateTime.Now
                                };

            return this.View(viewModel);
        }

        /// <summary>
        /// The withdraw money.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult WithdrawMoney()
        {
            return this.View();
        }

        /// <summary>
        /// The withdraw money.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> WithdrawMoney(WithdrawMoneyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Card card = await this.cardRepository.GetAsync(this.CardNumber);
                if (viewModel.Amount <= card.Balance)
                {
                    var transaction = new Transaction
                    {
                        CardId = card.Id,
                        Code = TransactionCode.WithdrawMoney,
                        Date = DateTime.Now,
                        Amount = viewModel.Amount
                    };

                    card.Balance -= viewModel.Amount;
                    card.Transactions.Add(transaction);

                    await this.cardRepository.UpdateAsync(card);

                    return this.RedirectToAction("Report", new { transactionId = transaction.Id });
                }

                return this.RedirectToAction("BigAmount", "Error");
            }

            return this.View(viewModel);
        }

        /// <summary>
        /// The report.
        /// </summary>
        /// <param name="transactionId">
        /// The transaction id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public async Task<ActionResult> Report(int transactionId)
        {
            Transaction transaction = await this.transactionRepository.GetAsync(transactionId);

            if (transaction == null)
            {
                return this.HttpNotFound();
            }

            var viewModel = new ReportViewModel
                                {
                                    CardNumber = transaction.Card.Number,
                                    Amount = transaction.Amount.HasValue ? transaction.Amount.Value : 0,
                                    Balance = transaction.Card.Balance,
                                    Date = transaction.Date
                                };

            return this.View(viewModel);
        }
    }
}