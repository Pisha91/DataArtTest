namespace DataArtATM.Controllers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using DataArtATM.Abstract.Repositories;
    using DataArtATM.Core.Models;
    using DataArtATM.Helpers;
    using DataArtATM.ModelBinder;
    using DataArtATM.ViewModels;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    /// <summary>
    /// The card controller.
    /// </summary>
    public class CardController : Controller
    {
        /// <summary>
        /// The card repository.
        /// </summary>
        private readonly ICardRepository cardRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CardController"/> class.
        /// </summary>
        /// <param name="cardRepository">
        /// The card repository.
        /// </param>
        public CardController(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }

        /// <summary>
        /// Gets the authentication manager.
        /// </summary>
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return this.HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// The validate card.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult ValidateCard()
        {
            return this.View();
        }

        /// <summary>
        /// The validate card.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ValidateCard(ValidateCardViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                long cardNumber = long.Parse(viewModel.Number.Replace("-", string.Empty));
                Card card = await this.cardRepository.GetAsync(cardNumber);
                if (card != null)
                {
                    return this.RedirectToAction("ValidatePinCode", new { cardNumber });
                }

                ModelState.AddModelError("Number", "Invalid card number");
            }

            return this.View(viewModel);
        }

        /// <summary>
        /// The validate pin code.
        /// </summary>
        /// <param name="cardNumber">
        /// The card number.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        public ActionResult ValidatePinCode(long cardNumber)
        {
            var viewModel = new ValidatePinCodeViewModel { CardNumber = cardNumber };

            return this.View(viewModel);
        }

        /// <summary>
        /// The validate pin code.
        /// </summary>
        /// <param name="viewModel">
        /// The view model.
        /// </param>
        /// <param name="codeCount">
        /// The code Count.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ValidatePinCode(ValidatePinCodeViewModel viewModel, [ModelBinder(typeof(InvalidCodeCountModelBinder))]int codeCount)
        {
            if (ModelState.IsValid)
            {
                Card card = await this.cardRepository.GetAsync(viewModel.CardNumber);
                if (CardValidationHelper.IsValidPinCode(card.PinCode, viewModel.PinCode))
                {
                    this.Authenticate(card.Number);

                    return this.RedirectToAction("Operations", "Transactions");
                }
                
                if (codeCount < 4)
                {
                    this.Session["InvalidCodeCount"] = codeCount + 1;
                    this.ModelState.AddModelError("PinCode", "Invalid PIN code");
                    viewModel.PinCode = string.Empty;
                }
                else
                {
                    card.IsBlocked = true;
                    await this.cardRepository.UpdateAsync(card);

                    return this.RedirectToAction("CardBlocked", "Error");
                }
            }

            return this.View(viewModel);
        }

        /// <summary>
        /// The log off.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.AuthenticationManager.SignOut();

            return this.RedirectToAction("ValidateCard");
        }

        /// <summary>
        /// The authenticate.
        /// </summary>
        /// <param name="cardNumber">
        /// The cardNumber.
        /// </param>
        private void Authenticate(long cardNumber)
        {
            this.AuthenticationManager.SignOut();
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, cardNumber.ToString(CultureInfo.InvariantCulture)) };
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            this.AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
        }
    }
}