namespace DataArtATM.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The base authenticate controller.
    /// </summary>
    [Authorize]
    public class BaseAuthenticateController : Controller
    {
        /// <summary>
        /// Gets the card number.
        /// </summary>
        protected long CardNumber 
        {
            get
            {
                return long.Parse(this.User.Identity.Name);
            }
        }
    }
}