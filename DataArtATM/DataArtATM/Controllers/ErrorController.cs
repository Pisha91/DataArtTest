namespace DataArtATM.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The error controller.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// The card blocked.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult CardBlocked()
        {
            return this.View();
        }

        /// <summary>
        /// The big amount.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult BigAmount()
        {
            return this.View();
        }
    }
}